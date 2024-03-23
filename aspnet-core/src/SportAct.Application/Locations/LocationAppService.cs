using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using SportAct.Cities;
using SportAct.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace SportAct.Locations
{
    public class LocationAppService :
        CrudAppService<
            Location, //The Book entitycity
            LocationDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateLocationDto>, //Used to create/update a book
        ILocationAppService //implement the IBookAppService
    {
        private readonly ICityRepository _cityRepository;

        public LocationAppService(IRepository<Location, Guid> repository, ICityRepository cityRepository)
            : base(repository)
        {
            _cityRepository = cityRepository;
            GetPolicyName = SportActPermissions.Locations.Default;
            GetListPolicyName = SportActPermissions.Locations.Default;
            CreatePolicyName = SportActPermissions.Locations.Create;
            UpdatePolicyName = SportActPermissions.Locations.Edit;
            DeletePolicyName = SportActPermissions.Locations.Delete;
        }
        public override async Task<LocationDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and citys
            var query = from location in queryable
                        join city in await _cityRepository.GetQueryableAsync() on location.City.Id equals city.Id
                        where location.Id == id
                        select new { location, city };

            //Execute the query and get the book with city
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Location), id);
            }

            var locationDto = ObjectMapper.Map<Location, LocationDto>(queryResult.location);
            locationDto.CityName = queryResult.city.CityName;
            return locationDto;
        }

        public override async Task<PagedResultDto<LocationDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and citys
            var query = from location in queryable
                        join city in await _cityRepository.GetQueryableAsync() on location.City.Id equals city.Id
                        select new { location, city };

            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var locationDtos = queryResult.Select(x =>
            {
                var locationDto = ObjectMapper.Map<Location, LocationDto>(x.location);
                locationDto.CityName = x.city.CityName;
                return locationDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<LocationDto>(
                totalCount,
                locationDtos
            );
        }

        public async Task<ListResultDto<CityLookupDto>> GetCityLookupAsync()
        {
            var cities = await _cityRepository.GetListAsync();

            return new ListResultDto<CityLookupDto>(
                ObjectMapper.Map<List<City>, List<CityLookupDto>>(cities)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"location.{nameof(Location.LocationName)}";
            }

            if (sorting.Contains("cityName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "cityName",
                    "city.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"location.{sorting}";
        }
    }
}

