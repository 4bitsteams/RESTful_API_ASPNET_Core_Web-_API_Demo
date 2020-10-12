using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NationalParkDemo.Models;
using NationalParkDemo.Models.Dtos;
using NationalParkDemo.Repository;
using NationalParkDemo.Repository.IRepository;

namespace NationalParkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : Controller
    {
        private INationalParkRepository _npRepo;
        private readonly IMapper _mapper;
        public NationalParksController(INationalParkRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var NationalParkList = _npRepo.GetNationalParks();
            var objDto = new List<NationalParkDto>();
            foreach (var item in NationalParkList)
            {
                objDto.Add(_mapper.Map<NationalParkDto>(item));
            }
            return Ok(objDto);
        }

        [HttpGet("{Id:int}")]

        public IActionResult GetNationalPark(int Id)
        {
            var NationalPark = _npRepo.GetNationalPark(Id);
            if (NationalPark == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<NationalParkDto>(NationalPark);

            return Ok(objDto);
        }


        [HttpPost]

        public IActionResult Create([FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null)
            {
                return BadRequest(ModelState);
            }


            if (_npRepo.NationalParkExists(nationalParkDto.Name))
            {
                ModelState.AddModelError("", "National Park Already Exist!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nationalparkobj = _mapper.Map<NationalPark>(nationalParkDto);

            if (!_npRepo.CreateNationalPark(nationalparkobj))
            {
                ModelState.AddModelError("", $"Something Wrong!!! {nationalparkobj.Name}");

                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetNationalPark",new {Id=nationalparkobj.Id },nationalparkobj);
        }

        [HttpPatch( "{Id:int}")]
        public IActionResult Update(int Id,[FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null || Id!=nationalParkDto.Id)
            {
                return BadRequest(ModelState);
            }

            var nationalparkobj = _mapper.Map<NationalPark>(nationalParkDto);

            if (!_npRepo.UpdateNationalPark(nationalparkobj))
            {
                ModelState.AddModelError("", $"Something Wrong!!! {nationalparkobj.Name}");

                return StatusCode(500, ModelState);
            }
            return NoContent();
        }


        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int Id)
        {
            if (_npRepo.NationalParkExists(Id))
            {
                return NotFound();
            }

            //var nationalparkobj = _mapper.Map<NationalPark>(nationalParkDto);
            var nationalparkobj = _npRepo.GetNationalPark(Id);
            if (!_npRepo.DeleteNationalPark(nationalparkobj))
            {
                ModelState.AddModelError("", $"Something Wrong!!! {nationalparkobj.Name}");

                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
