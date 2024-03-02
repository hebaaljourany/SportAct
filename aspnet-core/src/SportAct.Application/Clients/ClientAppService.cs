using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SportAct.Domain
{
    public class ClientAppService :
        CrudAppService<
            Client, //The Book entity
            ClientDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateClientDto>, //Used to create/update a book
        IClientAppService //implement the IBookAppService
    {
        public ClientAppService(IRepository<Client, Guid> repository)
            : base(repository)
        {

        }
    }
}
