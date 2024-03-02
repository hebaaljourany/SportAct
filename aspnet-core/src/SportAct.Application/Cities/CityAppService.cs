using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SportAct.Cities
{
    public class CityAppService :
        CrudAppService<
            City, //The Book entity
            CityDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateCityDto>, //Used to create/update a book
        ICityAppService //implement the IBookAppService
    {
        public CityAppService(IRepository<City, Guid> repository)
            : base(repository)
        {

        }
    }
}
