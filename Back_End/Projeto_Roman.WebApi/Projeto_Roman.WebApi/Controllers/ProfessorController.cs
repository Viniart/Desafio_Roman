using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Roman.WebApi.Domains;
using Projeto_Roman.WebApi.Interfaces;
using Projeto_Roman.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private IProfessorRepository _professorRepository { get; set; }

        public ProfessorController()
        {
            _professorRepository = new ProfessorRepository();
        }

        /// <summary>
        /// Lista todos os Professors
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_professorRepository.Listar().OrderBy(c => c.IdProfessor));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um Professor pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_professorRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo Professor
        /// </summary>
        /// <param name="novoProfessor"></param>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Professor novoProfessor)
        {
            try
            {
                _professorRepository.Cadastrar(novoProfessor);

                return StatusCode(201);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);

            }

        }

        /// <summary>
        /// Deleta um Professor pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _professorRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);

            }
        }

        /// <summary>
        /// Atualiza um Professor pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="professorAtualizado"></param>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, Professor professorAtualizado)
        {
            try
            {
                _professorRepository.Atualizar(id, professorAtualizado);

                return StatusCode(200);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }
    }
}
