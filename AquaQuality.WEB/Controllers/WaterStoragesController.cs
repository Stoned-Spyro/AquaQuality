using AquaQuality.BLL.DTO.Measurement;
using AquaQuality.BLL.DTO.WaterStorage;
using AquaQuality.DAL.Entities;
using System.Collections.Generic;
using AquaQuality.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AquaQuality.DAL.Interfaces.WaterStorages;
using System.Linq;
using AutoMapper;

namespace AquaQuality.WEB.Controllers
{
    [Route("api/water-storages")]
    public class WaterStoragesController : MainController
    {
        private readonly IWaterStorageService _waterStorageService;
        private readonly IMapper _mapper;

        public WaterStoragesController(IMapper mapper, IWaterStorageService waterStorageService)
        {
            _waterStorageService = waterStorageService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var waterStorages = _waterStorageService.Get();
            return Ok(_mapper.Map<IEnumerable<WaterStorageGetDTO>>(waterStorages));
        }
        [HttpGet("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult FindById(int id) 
        {
            var waterStorage = _waterStorageService.FindById(id);
            if (waterStorage == null) return NotFound();
            return Ok(_mapper.Map<WaterStorageGetDTO>(waterStorage));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(WaterStoragePostDTO waterStorageDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var waterStorage = _mapper.Map<WaterStorage>(waterStorageDto);
            var result = _waterStorageService.Create(waterStorage);

            if(result == null) return BadRequest();

            return Ok(_mapper.Map<WaterStorageGetDTO>(result));

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, WaterStorageUpdateDTO waterStorageDto)
        {
            if(id!=waterStorageDto.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _waterStorageService.Update(_mapper.Map<WaterStorage>(waterStorageDto));
            return Ok(waterStorageDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var waterStorage = _waterStorageService.FindById(id);
            if(waterStorage == null) return NotFound();
            _waterStorageService.Remove(waterStorage);
            return Ok();
        }
        [HttpGet]
        [Route("search/{waterStorage}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<WaterStorage>> Search(string waterStorageName)
        {
            var waterStorages = _mapper.Map<List<WaterStorage>>(_waterStorageService.Search(waterStorageName));
            if (waterStorages == null || waterStorages.Count == 0) return NotFound("None water storage founded");

            return Ok(waterStorages);

        }
    }
}
