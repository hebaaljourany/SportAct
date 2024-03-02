using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SportAct.SportActivities
{
    public interface ISportActivityAppService :
        ICrudAppService< //Defines CRUD methods
            SportActivityDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateSportActivityDto> //Used to create/update a book
    {
        Task<ListResultDto<LocationLookupDto>> GetLocationLookupAsync();
        Task<ListResultDto<ActivityTypeLookupDto>> GetActivityTypeLookupAsync();


    }
}