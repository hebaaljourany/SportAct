using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace SportAct.Locations
{
    public class LocationManager : DomainService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationManager(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Location> CreateAsync(
            [NotNull] string locationname
           )
        {
            Check.NotNullOrWhiteSpace(locationname, nameof(locationname));

            var existingLocation = await _locationRepository.FindByLocationNameAsync(locationname);
            if (existingLocation != null)
            {
                throw new LocationAlreadyExistsException(locationname);
            }

            return new Location(
                GuidGenerator.Create(),
                locationname
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Location location,
            [NotNull] string newName)
        {
            Check.NotNull(location, nameof(location));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingLocation = await _locationRepository.FindByLocationNameAsync(newName);
            if (existingLocation != null && existingLocation.Id != location.Id)
            {
                throw new LocationAlreadyExistsException(newName);
            }

            location.ChangeName(newName);
        }
    }
}
