using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext context)
        {
            _context = context;

        }
        // GET: api/<AlunoController>
        /*    [HttpGet]
           public IEnumerable<string> Get()
           {
               return new string[] { "value1", "value2" };
           } */

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(aluno => aluno.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");
            return Ok(aluno);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var aluno = _context.Alunos.FirstOrDefault(aluno => aluno.Nome.Contains(nome));
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
             _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null) return BadRequest("Aluno Não Encontrado");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null) return BadRequest("Aluno Não Encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alu = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if(alu == null) return BadRequest("Aluno Não Encontrado");

            _context.Remove(alu);
            _context.SaveChanges();
            return Ok();
        }


        // GET api/<AlunoController>/5
        /*  [HttpGet("{id}")]
          public string Get(int id)
          {
              return "value";
          }

          // POST api/<AlunoController>
          [HttpPost]
          public void Post([FromBody] string value)
          {

          }


          // PUT api/<AlunoController>/5
          [HttpPut("{id}")]
          public void Put(int id, [FromBody] string value)
          {
          }

          // DELETE api/<AlunoController>/5
          [HttpDelete("{id}")]
          public void Delete(int id)
          {
          }
          */
    }
}
