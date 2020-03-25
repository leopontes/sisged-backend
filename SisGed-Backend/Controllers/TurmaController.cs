using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisGed_Backend.Business;
using SisGed_Backend.Exception;
using SisGed_Backend.Models;
using SisGed_Backend.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SisGed_Backend.Controllers
{
    [Route("api/turmas")]
    public class TurmaController : Controller
    {

        private readonly ITurmaBusiness turmaBusiness;

        public TurmaController(ITurmaBusiness turmaBusiness)
        {
            this.turmaBusiness = turmaBusiness;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Turma> Get()
        {
            return this.turmaBusiness.Listar();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Turma Get(int id)
        {
            return this.turmaBusiness.BuscarPor(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Turma turma)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                this.turmaBusiness.CadastrarTurma(turma);
                return Ok();
            }
            catch(BusinessException e)
            {
                return BadRequest(e.Message);
            }
                     
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Turma turma)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try { 
                this.turmaBusiness.Editar(id, turma);
                return Ok();
            }
            catch(BusinessException e)
            {
               return BadRequest(e.Message);
            }
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.turmaBusiness.Excluir(id);
                return Ok();

            }catch(BusinessException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
