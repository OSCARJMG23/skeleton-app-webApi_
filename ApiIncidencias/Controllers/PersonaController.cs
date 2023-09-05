using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiIncidencias.Controllers
{
    public class PersonaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
        {
            var personas = await _unitOfWork.Personas.GetAllAsync();
            return _mapper.Map<List<PersonaDto>>(personas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var personas = await _unitOfWork.Personas.GetByIdAsync(id);
            return _mapper.Map<PersonaDto>(personas);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<Persona>> Post(PersonaDto personaDto){
            var persona = _mapper.Map<Persona>(personaDto);

            _unitOfWork.Personas.Add(persona);
            await _unitOfWork.SaveAsync();

            if(persona == null)
            {
                return BadRequest();
            }
            personaDto.Id = persona.Id;
            return CreatedAtAction(nameof(Post),new {id =personaDto.Id},personaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody]PersonaDto personaDto){

            if(personaDto == null)
            {
                return NotFound();
            }
            var persona = _mapper.Map<Persona>(personaDto);
            _unitOfWork.Personas.Update(persona);
            await _unitOfWork.SaveAsync();
            return personaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<ActionResult<PersonaDto>> Delete(int id)
        {
            var persona = await _unitOfWork.Ciudades.GetByIdAsync(id);
            if (persona== null)
            {
                return NotFound();
            }
            _unitOfWork.Ciudades.Remove(persona);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}