using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SportAct.ActivityTypes
{
    public class ActivityTypeAppService :
        CrudAppService<
            ActivityType, //The Book entity
            ActivityTypeDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateActivityTypeDto>, //Used to create/update a book
         IActivityTypeAppService //implement the IBookAppService
    {
        public ActivityTypeAppService(IRepository<ActivityType, Guid> repository)
            : base(repository)
        {

        }
    }
}
