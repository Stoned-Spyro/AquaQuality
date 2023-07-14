using AquaQuality.BLL.DTO;
using AquaQuality.DAL.DataContext;
using AquaQuality.DAL.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using AquaQuality.DAL.Interfaces.Measurements;

namespace AquaQuality.BLL.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementsRepository _measurementsRepository;

        public MeasurementService(IMeasurementsRepository measurementsRepository)
        {
            _measurementsRepository = measurementsRepository;
        }

        public IEnumerable<Measurement> Get()
        {
            return _measurementsRepository.Get();
        }
        public Measurement Create(Measurement measurement)
        {
            _measurementsRepository.Create(measurement);
            return measurement;
        }
        public Measurement Update(Measurement measurement)
        {
            _measurementsRepository.Update(measurement);
            return measurement;
        }
        public void Remove(Measurement measurement)
        {
            _measurementsRepository.Remove(measurement);
        }
        public IEnumerable<Measurement> GetMeasurementsByStorage(int storageId)
        {
            return _measurementsRepository.GetMeasurementByStorage(storageId);
        }

        public Measurement FingById(int id)
        {
            return _measurementsRepository.FindById(id);
        }

        public IEnumerable<Measurement> FindMeasurementByStorageName(string waterStorageName)
        {
            return _measurementsRepository.FindMeasurementByStorageName(waterStorageName);
        }
        public void Dispose()
        {
            _measurementsRepository?.Dispose();
        }
    }
}
