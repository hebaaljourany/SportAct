using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SportAct.Cities
{
    public interface ICityAppService :
        ICrudAppService< //Defines CRUD methods
            CityDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateCityDto> //Used to create/update a book
    {
        //Task<CityDto> GetAsync(Guid id);

        //Task<PagedResultDto<CityDto>> GetListAsync(GetCityListDto input);

      //Task<AuthorDto> CreateAsync(CreateAuthorDto input);

        //Task UpdateAsync(Guid id, UpdateAuthorDto input);

       // Task DeleteAsync(Guid id);
    }
}