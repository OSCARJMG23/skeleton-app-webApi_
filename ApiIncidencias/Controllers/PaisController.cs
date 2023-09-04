using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiIncidencias.Dtos;
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiIncidencias.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class PaisController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<PaisesDto>>> Get()
        {
            var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<PaisesDto>>(paises);
        }
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pager<PaisDto>>> Get11([FromQuery]Params paisParams)
        {
            var paises = await _unitOfWork.Paises.GetAllAsync(paisParams.PageIndex,paisParams.PageSize, paisParams.Search);
            var lstPaisDto = _mapper.Map<List<PaisDto>>(paises.registros);
            return new Pager<PaisDto>(lstPaisDto,paises.totalRegistros,paisParams.PageIndex,paisParams.PageSize, paisParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            var paises = await _unitOfWork.Paises.GetByIdAsync(id);
            return _mapper.Map<PaisDto>(paises);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<Pais>> Post(Pais pais){


            _unitOfWork.Paises.Add(pais);
            await _unitOfWork.SaveAsync();

            if(pais == null)
            {
                return BadRequest();
            }
            pais.Id = pais.Id;
            return CreatedAtAction(nameof(Post),new {id =pais.Id},pais);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<Pais>> Put(int id, [FromBody]Pais pais){

            if(pais == null)
            {
                return NotFound();
            }

            _unitOfWork.Paises.Update(pais);
            await _unitOfWork.SaveAsync();
            return pais;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<IActionResult> Delete(int id)
        {
            var paises = await _unitOfWork.Paises.GetByIdAsync(id);
            if (paises == null)
            {
                return NotFound();
            }
            _unitOfWork.Paises.Remove(paises);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
}
