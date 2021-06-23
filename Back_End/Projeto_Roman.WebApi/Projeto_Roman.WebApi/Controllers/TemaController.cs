using Microsoft.AspNetCore.Authorization;
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
    public class TemaController : ControllerBase
    {
        private ITemaRepository _temaRepository { get; set; }

        public TemaController()
        {
            _temaRepository = new TemaRepository();
        }

        /// <summary>
        /// Lista todos os Temas
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_temaRepository.Listar().OrderBy(c => c.IdTema));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um Tema pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_temaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo Tema
        /// </summary>
        /// <param name="novoTema"></param>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Tema novoTema)
        {
            try
            {
                _temaRepository.Cadastrar(novoTema);

                return StatusCode(201);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);

            }

        }

        /// <summary>
        /// Deleta um Tema pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _temaRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);

            }
        }

        /// <summary>
        /// Atualiza um Tema pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="temaAtualizado"></param>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, Tema temaAtualizado)
        {
            try
            {
                _temaRepository.Atualizar(id, temaAtualizado);

                return StatusCode(200);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }
    }
}
