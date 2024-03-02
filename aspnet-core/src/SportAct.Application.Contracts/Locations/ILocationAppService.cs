using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SportAct.Locations
{
    public interface ILocationAppService :
        ICrudAppService< //Defines CRUD methods
            LocationDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateLocationDto> //Used to create/update a book
    {
        // ADD the NEW METHOD
        Task<ListResultDto<CityLookupDto>> GetCityLookupAsync();
    }
}