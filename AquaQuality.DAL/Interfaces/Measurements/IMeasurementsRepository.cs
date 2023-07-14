using System;
using AquaQuality.DAL.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AquaQuality.DAL.Interfaces.Measurements
{
    public interface IMeasurementsRepository : IGenericRepository<Measurement>
    {
        new IEnumerable<Measurement> Get();
        new Measurement FindById(int id);
        IEnumerable<Measurement> GetMeasurementByStorage(int waterStorageId);
        IEnumerable<Measurement> FindMeasurementByStorageName(string waterStorageName);
    }
}
