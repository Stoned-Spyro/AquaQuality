using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaQuality.DAL.Entities; 

namespace AquaQuality.DAL.Interfaces.WaterStorages
{
    public interface IWaterStorageService : IDisposable
    {
        IEnumerable<WaterStorage> Get();
        WaterStorage FindById(int id);
        WaterStorage Create(WaterStorage waterStorage);
        WaterStorage Update(WaterStorage waterStorage);
        void Remove(WaterStorage waterStorage);
        IEnumerable<WaterStorage> Search(string waterStorageName);
    }
}
