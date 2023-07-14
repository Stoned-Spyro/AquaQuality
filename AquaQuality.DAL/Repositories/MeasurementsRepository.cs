using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AquaQuality.DAL.Interfaces.Measurements;
using AquaQuality.DAL.Entities;
using AquaQuality.DAL.DataContext;

namespace AquaQuality.DAL.Repositories
{
    public class MeasurementsRepository : GenericRepository<Measurement>, IMeasurementsRepository
    {
        public MeasurementsRepository(DatabaseContext context) : base(context) { }

        public override List<Measurement> Get()
        {
            return Db.Measurements.AsNoTracking().Include(m => m.WaterStorage).ToList();
        }
        public override Measurement FindById(int id)
        {
            return Db.Measurements.AsNoTracking().Include(m => m.WaterStorage).FirstOrDefault(m => m.Id == id);
        }
        public IEnumerable<Measurement> GetMeasurementByStorage(int waterStorageId)
        {
            return Search(m => m.WaterStorageId == waterStorageId);
        }

        public IEnumerable<Measurement> FindMeasurementByStorageName(string waterStorageName)
        {
            return Db.Measurements.AsNoTracking()
               .Include(m => m.WaterStorage)
               .Where(m => m.WaterStorage.Name.Contains(waterStorageName))
               .ToList();
        }
    }
}
