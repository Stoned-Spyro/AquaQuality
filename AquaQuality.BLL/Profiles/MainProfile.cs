using AquaQuality.BLL.DTO.Measurement;
using AquaQuality.BLL.DTO.WaterStorage;
using AquaQuality.DAL.Entities;
using AutoMapper;

namespace AquaQuality.BLL.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<WaterStorageGetDTO, WaterStorage>();
            CreateMap<WaterStorage, WaterStorageGetDTO>();

            CreateMap<WaterStoragePostDTO, WaterStorage>();
            CreateMap<WaterStorage, WaterStoragePostDTO>();

            CreateMap<WaterStorageUpdateDTO, WaterStorage>();
            CreateMap<WaterStorage, WaterStorageUpdateDTO>();


            CreateMap<MeasurementPostDTO, Measurement>();
            CreateMap<Measurement, MeasurementPostDTO>();

            CreateMap<MeasurementGetDTO, Measurement>();
            CreateMap<Measurement, MeasurementGetDTO>();

            CreateMap<MeasurementUpdateDTO, Measurement>();
            CreateMap<Measurement, MeasurementUpdateDTO>();
        }
    }
}
