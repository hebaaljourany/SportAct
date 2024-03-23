using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using SportAct.SportActivities;
using SportAct.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;
using Volo.Abp;
using SportAct.Domain;
using Microsoft.EntityFrameworkCore;

namespace SportAct.Reservations
{

    public class ReservationAppService :
        CrudAppService<
            Reservation, //The Book entity
            ReservationDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateReservationDto>, //Used to create/update a book
        IReservationAppService //implement the IBookAppService
    {
        private readonly ISportActivityRepository _sportactivityRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IClientRepository _clientRepository;



        public ReservationAppService(IRepository<Reservation, Guid> repository, IClientRepository clientRepository, ISportActivityRepository sportactivityRepository, ICurrentUser currentUser)
            : base(repository)
        {
            _clientRepository = clientRepository;
            _sportactivityRepository = sportactivityRepository;
            _currentUser = currentUser;
            GetPolicyName = SportActPermissions.Reservations.Default;
            GetListPolicyName = SportActPermissions.Reservations.Default;
            CreatePolicyName = SportActPermissions.Reservations.Create;
            UpdatePolicyName = SportActPermissions.Reservations.Edit;
            DeletePolicyName = SportActPermissions.Reservations.Delete;
        }
        public override async Task<ReservationDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Reservation> from the repository
            var queryable = await Repository.GetQueryableAsync();
            var currAcc = _currentUser.Roles;
            //Prepare a query to join Reservations and authors
            var query = from reservation in queryable
                        join sportactivity in await _sportactivityRepository.GetQueryableAsync() on reservation.SportActivity.Id equals sportactivity.Id
                        where reservation.Id == id
                        select new { reservation, sportactivity };

            //Execute the query and get the reservation with sportactivity
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Reservation), id);
            }

            var reservationDto = ObjectMapper.Map<Reservation, ReservationDto>(queryResult.reservation);
            reservationDto.ActivityName = queryResult.sportactivity.ActivityName;
            return reservationDto;
        }

        public Task<ListResultDto<ClientLookupDto>> GetClientLookupAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task<PagedResultDto<ReservationDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<reservation> from the repository
            var queryable = await Repository.GetQueryableAsync();
            var roles = _currentUser.Roles;
            var query = from reservation in queryable
                        join sportactivity in await _sportactivityRepository.GetQueryableAsync() on reservation.SportActivity.Id equals sportactivity.Id
                        select new { reservation, sportactivity };
            if (!roles.Contains("admin"))
            {       
                //Prepare a query join reservations and authors
                query = from reservation in queryable
                        join sportactivity in await _sportactivityRepository.GetQueryableAsync() on reservation.SportActivity.Id equals sportactivity.Id
                        join client in await _clientRepository.GetQueryableAsync() on reservation.Client.Id equals client.Id
                        where _currentUser.Id == client.UserId
                        select new { reservation, sportactivity }; 
            }
            

            //Paging
            query = query
                //.OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of reservationDto objects
            var reservationDtos = queryResult.Select(x =>
            {
                var reservationDto = ObjectMapper.Map<Reservation, ReservationDto>(x.reservation);
                reservationDto.ActivityName = x.sportactivity.ActivityName;
                return reservationDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ReservationDto>(
                totalCount,
                reservationDtos
            );
        }

        public async Task<ListResultDto<SportActivityLookupDto>> GetSportActivityLookupAsync()
        {
            var sportactivities = await _sportactivityRepository.GetListAsync();

            return new ListResultDto<SportActivityLookupDto>(
                ObjectMapper.Map<List<SportActivity>, List<SportActivityLookupDto>>(sportactivities)
            );
        }
        public override async Task<ReservationDto> CreateAsync(CreateUpdateReservationDto input)
        {
            // Retrieve the current user's ID
            var userId = _currentUser.Id;

            // Get the IQueryable<Reservation> from the repository
            var queryable = await Repository.GetQueryableAsync();

            // Modify the query to include the client search logic and retrieve only the ClientId
            var clientId = from client in await _clientRepository.GetQueryableAsync()
                           where client.UserId == userId
                           select client.Id;
           

            /*  if (clientId == Guid.Empty)
              {
                  throw new BusinessException("Client not found for the current user.");
              }*/

            // Set the ClientId property of the reservation entity
            input.ClientId = await clientId.FirstOrDefaultAsync();

            // Call the base CreateAsync method to create the reservation
            return await base.CreateAsync(input);
        }

        /*public override async Task<ReservationDto> CreateAsync(CreateUpdateReservationDto input)
        {
            // Retrieve the current user's ID
            var userId = _currentUser.Id;

            // Get the IQueryable<Reservation> from the repository
            var queryable = await Repository.GetQueryableAsync();

            // Modify the query to include the client search logic
            var query = from client in queryable
                        where client.ClientId==userId
            // Execute the query and get the result
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

            if (queryResult == null)
            {
                throw new BusinessException("Client not found for the current user.");
            }

            // Set the ClientId property of the reservation entity
            input.ClientId = queryResult.client.Id;

            // Call the base CreateAsync method to create the reservation
            return await base.CreateAsync(input);
        }*/

        /*private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"reservation.{sorting}";
                //return $"reservation.{nameof(Reservation.Name)}";
            }

            if (sorting.Contains("activityName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "activityName",
                    "activity.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"reservation.{sorting}";
        }*/
    }
}
