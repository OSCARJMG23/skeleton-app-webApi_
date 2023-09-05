using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using ApiIncidencias.Dtos;


namespace ApiIncidencias.Controllers;

    
    public class CiudadController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

    public CiudadController(IUnitOfWork unitOfWork,  IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        
    }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<CiudadDto>>> Get()
        {
            var ciudad = await _unitOfWork.Ciudades.GetAllAsync();
            return _mapper.Map<List<CiudadDto>>(ciudad);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<CiudaddesDto>> Get(int id)
        {
            var ciudad = await _unitOfWork.Ciudades.GetByIdAsync(id);
            return _mapper.Map<CiudaddesDto>(ciudad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<Ciudad>> Post(CiudaddesDto ciudaddesDto){

            var ciudad = _mapper.Map<Ciudad>(ciudaddesDto);
            _unitOfWork.Ciudades.Add(ciudad);
            await _unitOfWork.SaveAsync();

            if(ciudad == null)
            {
                return BadRequest();
            }
            ciudad.Id = ciudad.Id;
            return CreatedAtAction(nameof(Post),new {id =ciudad.Id},ciudad);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<CiudaddesDto>> Put(int id, [FromBody]CiudaddesDto ciudaddesDto){

            if(ciudaddesDto == null)
            {
                return NotFound();
            }
            var ciudad = _mapper.Map<Ciudad>(ciudaddesDto);
            _unitOfWork.Ciudades.Update(ciudad);
            await _unitOfWork.SaveAsync();
            return ciudaddesDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<ActionResult<CiudaddesDto>> Delete(int id)
        {
            var ciudades = await _unitOfWork.Ciudades.GetByIdAsync(id);
            if (ciudades == null)
            {
                return NotFound();
            }
            _unitOfWork.Ciudades.Remove(ciudades);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

}
