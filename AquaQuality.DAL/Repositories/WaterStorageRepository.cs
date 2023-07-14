using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaQuality.DAL.DataContext;
using AquaQuality.DAL.Entities;
using AquaQuality.DAL.Interfaces.WaterStorages;

namespace AquaQuality.DAL.Repositories
{
    public class WaterStorageRepository : GenericRepository<WaterStorage>, IWaterStorageRepository
    {
        public WaterStorageRepository(DatabaseContext context) : base(context) { }

    }
}
