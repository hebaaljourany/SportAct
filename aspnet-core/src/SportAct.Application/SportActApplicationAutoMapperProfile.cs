using AutoMapper;
using SportAct.ActivityTypes;
using SportAct.Cities;
using SportAct.Domain;
using SportAct.Locations;
using SportAct.Reservations;
using SportAct.SportActivities;

namespace SportAct;

public class SportActApplicationAutoMapperProfile : Profile
{
    public SportActApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Client, ClientDto>();
        CreateMap<CreateUpdateClientDto, Client>();
        CreateMap<City, CityDto>();
        CreateMap<CreateUpdateCityDto, City>();
        CreateMap<Location, LocationDto>();
        CreateMap<CreateUpdateLocationDto, Location>();
        CreateMap<SportActivity, SportActivityDto>();
        CreateMap<CreateUpdateSportActivityDto, SportActivity>();
        CreateMap<ActivityType, ActivityTypeDto>();
        CreateMap<CreateUpdateActivityTypeDto, ActivityType>();
        CreateMap<Reservation, ReservationDto>();
        CreateMap<CreateUpdateReservationDto, Reservation>();
        CreateMap<City, CityLookupDto>();
        CreateMap<Location, LocationLookupDto>();
        CreateMap<ActivityType, ActivityTypeLookupDto>();
        CreateMap<SportActivity, SportActivityLookupDto>();
        CreateMap<Client, ClientLookupDto>();








    }
}
