using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SportAct.Reservations
{
    public interface IReservationAppService :
        ICrudAppService< //Defines CRUD methods
            ReservationDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateReservationDto> //Used to create/update a book
    {
        Task<ListResultDto<SportActivityLookupDto>> GetSportActivityLookupAsync();
        Task<ListResultDto<ClientLookupDto>> GetClientLookupAsync();


    }
}