using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SportAct.ActivityTypes
{
    public interface IActivityTypeAppService :
        ICrudAppService< //Defines CRUD methods
            ActivityTypeDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateActivityTypeDto> //Used to create/update a book
    {

    }
}