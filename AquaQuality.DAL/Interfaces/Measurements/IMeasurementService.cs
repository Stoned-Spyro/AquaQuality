using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaQuality.DAL.Entities;

namespace AquaQuality.DAL.Interfaces.Measurements
{
    public interface IMeasurementService: IDisposable
    {
        IEnumerable<Measurement> Get();
        Measurement FingById(int id);
        Measurement Create(Measurement measurement);
        Measurement Update(Measurement measurement);  
        void Remove(Measurement measurement);
        IEnumerable<Measurement> GetMeasurementsByStorage(int waterStorageId);
        IEnumerable<Measurement> FindMeasurementByStorageName(string waterStorageName);
    }
}
