using AquaQuality.BLL.DTO;
using AquaQuality.DAL.DataContext;
using AquaQuality.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using AquaQuality.DAL.Interfaces.WaterStorages;
using System.Threading.Tasks;

namespace AquaQuality.BLL.Services
{
    public class WaterStorageService : IWaterStorageService
    {
        private readonly IWaterStorageRepository _waterStorageRepository;

        public WaterStorageService(IWaterStorageRepository waterStorageRepository)
        {
            _waterStorageRepository = waterStorageRepository;
        }
        public IEnumerable<WaterStorage> Get()
        {
            return _waterStorageRepository.Get();
        }
        public WaterStorage Create(WaterStorage waterStorage)
        {
            if (_waterStorageRepository.Search(c => c.Name == waterStorage.Name).Any())
                return null;
            _waterStorageRepository.Create(waterStorage);
            return waterStorage;
        }
        public WaterStorage Update(WaterStorage waterStorage)
        {
            if (_waterStorageRepository.Search(c => c.Name == waterStorage.Name && c.Id != waterStorage.Id).Any())
                return null;
            _waterStorageRepository.Update(waterStorage);
            return waterStorage;
        }
        public void Remove(WaterStorage waterStorage)
        {
            _waterStorageRepository.Remove(waterStorage);

        }
        public IEnumerable<WaterStorage> Search(string waterStorageName)
        {
            return _waterStorageRepository.Search(c => c.Name.Contains(waterStorageName));
        }

        public WaterStorage FindById(int id)
        {
            return _waterStorageRepository.FindById(id);
        }
        public void Dispose()
        {
            _waterStorageRepository?.Dispose();
        }

    }
}
