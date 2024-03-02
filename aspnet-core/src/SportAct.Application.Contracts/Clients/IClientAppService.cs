using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SportAct.Domain
{
    public interface IClientAppService :
        ICrudAppService< //Defines CRUD methods
            ClientDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateClientDto> //Used to create/update a book
    {

    }
}