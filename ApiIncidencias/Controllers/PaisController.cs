using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiIncidencias.Controllers;

public class PaisController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public PaisController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Pais>>> Get()
        {
            var paises = await _unitOfWork.Paises.GetAllAsync();
            return Ok(paises);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pais>> Get(int id)
        {
            var paises = await _unitOfWork.Paises.GetByIdAsync(id);
            return Ok(paises);
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
