using AquaQuality.BLL.DTO.Measurement;
using AquaQuality.BLL.DTO.WaterStorage;
using AquaQuality.DAL.Entities;
using System.Collections.Generic;
using AquaQuality.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AquaQuality.DAL.Interfaces.Measurements;
using System.Linq;
using AutoMapper;

namespace AquaQuality.WEB.Controllers
{
    [Route("api/measurements")]
    public class MeasurementsController : MainController
    {
        private readonly IMeasurementService _measurementService;
        private readonly IMapper _mapper;

        public MeasurementsController(IMapper mapper, IMeasurementService measurementService)
        {
            _measurementService = measurementService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var measurement = _measurementService.Get();
            return Ok(_mapper.Map<IEnumerable<MeasurementGetDTO>>(measurement));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var measurement = _measurementService.FingById(id);
            if (measurement == null) return NotFound();
            return Ok(_mapper.Map<MeasurementGetDTO>(measurement));
        }

        [HttpGet]
        [Route("get-measurements-by-storage/{waterStorageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMeasurementsByStorage(int waterStorageId)
        {
            var measurement = _measurementService.GetMeasurementsByStorage(waterStorageId);
            if (!measurement.Any()) return NotFound();
            return Ok(_mapper.Map<IEnumerable<MeasurementGetDTO>>(measurement));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(MeasurementPostDTO measurementDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var measurement = _mapper.Map<Measurement>(measurementDto);
            var result = _measurementService.Create(measurement);

            if (result == null) return BadRequest();

            return Ok(_mapper.Map<MeasurementGetDTO>(result));

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, MeasurementUpdateDTO measurementDTO)
        {
            if (id != measurementDTO.Id || !ModelState.IsValid) return BadRequest();

            _measurementService.Update(_mapper.Map<Measurement>(measurementDTO));
            return Ok(measurementDTO);
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Remove(int id)
        {
            var measurement = _measurementService.FingById(id);
            if (measurement == null) return NotFound();
            _measurementService.Remove(measurement);
            return Ok();
        }

        [HttpGet]
        [Route("search-measurement-with-storage/{storageName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Measurement>> SearchMeasurementWithStorage(string storageName)
        {
            var measurements = _mapper.Map<List<Measurement>>(_measurementService.FindMeasurementByStorageName(storageName));
            if (!measurements.Any()) return NotFound("No measurements found");
            return Ok(_mapper.Map<IEnumerable<MeasurementGetDTO>>(measurements));
        }
    }
}
