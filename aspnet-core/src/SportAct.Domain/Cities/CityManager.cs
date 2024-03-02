using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace SportAct.Cities
{
    public class CityManager : DomainService
    {
        private readonly ICityRepository _cityRepository;

        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<City> CreateAsync(
            [NotNull] string cityname
           )
        {
            Check.NotNullOrWhiteSpace(cityname, nameof(cityname));

            var existingCity = await _cityRepository.FindByCityNameAsync(cityname);
            if (existingCity != null)
            {
                throw new CityAlreadyExistsException(cityname);
            }

            return new City(
                GuidGenerator.Create(),
                cityname
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] City city,
            [NotNull] string newName)
        {
            Check.NotNull(city, nameof(city));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingCity = await _cityRepository.FindByCityNameAsync(newName);
            if (existingCity != null && existingCity.Id != city.Id)
            {
                throw new CityAlreadyExistsException(newName);
            }

            city.ChangeName(newName);
        }
    }
}
