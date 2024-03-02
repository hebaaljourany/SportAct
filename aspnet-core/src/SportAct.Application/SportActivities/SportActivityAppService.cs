using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using SportAct.Locations;
using SportAct.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using SportAct.ActivityTypes;

namespace SportAct.SportActivities

{
    public class SportActivityAppService :
        CrudAppService<
            SportActivity, //The Book entity
            SportActivityDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateSportActivityDto>, //Used to create/update a book
            ISportActivityAppService //implement the IBookAppService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IActivityTypeRepository _activitytypeRepository;

        public SportActivityAppService(
            IRepository<SportActivity, Guid> repository,
            ILocationRepository locationRepository,
            IActivityTypeRepository activitytypeRepository)
            : base(repository)
        {
            _locationRepository = locationRepository;
            _activitytypeRepository = activitytypeRepository;

        }
        ///////////////////////////////////////////
        public override async Task<SportActivityDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and locations
            var query = from sportactivity in queryable
                       join location in await _locationRepository.GetQueryableAsync() on sportactivity.LocationId equals location.Id
                         join activitytype in await _activitytypeRepository.GetQueryableAsync() on sportactivity.ActivityTypeId equals activitytype.Id
                                where sportactivity.Id == id
                        select new { sportactivity, location, activitytype };

            //Execute the query and get the book with location
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(SportActivity), id);
            }

         
            var sportactivityDto = ObjectMapper.Map<SportActivity, SportActivityDto>(queryResult.sportactivity);
            sportactivityDto.LocationName = queryResult.location.LocationName;
            sportactivityDto.ActivityTypeName = queryResult.activitytype.ActivityTypeName;
            return sportactivityDto;
        }

        public override async Task<PagedResultDto<SportActivityDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and locations
            var query = from sportactivity in queryable
                        join location in await _locationRepository.GetQueryableAsync() on sportactivity.LocationId equals location.Id
                        join activitytype in await _activitytypeRepository.GetQueryableAsync() on sportactivity.ActivityTypeId equals activitytype.Id
                        where sportactivity.StartedTime.Date > DateTime.Now.AddDays(1).Date
                        select new { sportactivity, location, activitytype };     


            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var sportactivityDtos = queryResult.Select(x =>
            {
                var sportactivityDto = ObjectMapper.Map<SportActivity, SportActivityDto>(x.sportactivity);
                sportactivityDto.LocationName = x.location.LocationName;
                sportactivityDto.ActivityTypeName = x.activitytype.ActivityTypeName;

                return sportactivityDto;
            }).ToList();

            

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<SportActivityDto>(
                totalCount,
                sportactivityDtos
            );
        }

        public async Task<ListResultDto<LocationLookupDto>> GetLocationLookupAsync()
        {
            var locations = await _locationRepository.GetListAsync();

            return new ListResultDto<LocationLookupDto>(
                ObjectMapper.Map<List<Location>, List<LocationLookupDto>>(locations)
            );
        }
         public async Task<ListResultDto<ActivityTypeLookupDto>> GetActivityTypeLookupAsync()
        {
            var activitytypes = await _activitytypeRepository.GetListAsync();

            return new ListResultDto<ActivityTypeLookupDto>(
                ObjectMapper.Map<List<ActivityType>, List<ActivityTypeLookupDto>>(activitytypes)
            );
        }
        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"sportactivity.{nameof(SportActivity.ActivityName)}";
            }

            if (sorting.Contains("locationName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "locationName",
                    "location.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }
            if (sorting.Contains("activitytypeName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "activitytypeName",
                    "activitytype.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"sportactivity.{sorting}";
        }
        //////////////////////
        
    }
}
