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
    [ApiController]
    [Route("api/alunos")]
    public class AlunoController : Controller
    {
        
        private ICrudOperation<Aluno> alunoRepository;

        public AlunoController(ICrudOperation<Aluno> alunoRepository)
        {
            this.alunoRepository = alunoRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return this.alunoRepository.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            Aluno aluno = this.alunoRepository.GetById(id);
             
            return aluno;
        }

        // POST api/values
        [HttpPost]
        public void Post(Aluno aluno)
        {
            this.alunoRepository.Save(aluno);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Aluno aluno)
        {
            aluno.Id = id;
            this.alunoRepository.Save(aluno);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Aluno aluno = this.alunoRepository.GetById(id);
            this.alunoRepository.Delete(aluno);
        }
    }
}
