using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisGed_Backend.Models;
using SisGed_Backend.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SisGed_Backend.Controllers
{
    [Route("api/escolas")]
    public class EscolaController : Controller
    {

        private readonly ICrudOperation<Escola> escolaRepository;

        public EscolaController(ICrudOperation<Escola> escolaRepository)
        {
            this.escolaRepository = escolaRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Escola> Get()
        {
            return this.escolaRepository.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Escola Get(int id)
        {
            return this.escolaRepository.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Escola escola)
        {
            this.escolaRepository.Save(escola);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Escola escola)
        {
            Escola escolaDB = this.escolaRepository.GetById(id);

            escolaDB.Nome = escola.Nome;
            escolaDB.Local = escola.Local;
            escolaDB.Contato = escola.Contato;
            escolaDB.Diretor = escola.Diretor;

            this.escolaRepository.Save(escolaDB);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Escola escola = this.escolaRepository.GetById(id);
            this.escolaRepository.Delete(escola);
        }
    }
}
