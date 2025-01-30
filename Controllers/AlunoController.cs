using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using SmartSchool.Data;

namespace SmartSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SchoolContext _context;

        public AlunoController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest($"O aluno de ID \"{id}\" não foi encontrado.");

            return Ok(aluno);
        }
        [HttpGet("byName")]
        public IActionResult GetByNome(string nome, string sobreNome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.ToLower().Contains(nome.ToLower()) && a.Sobrenome.ToLower().Contains(sobreNome.ToLower()));
            if (aluno == null) return BadRequest($"O aluno \"{nome + " " + sobreNome}\" não foi encontrado.");

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
            var alunoExist = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (alunoExist == null) return BadRequest($"O aluno de ID \"{id}\" não foi encontrado.");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alunoExist = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (alunoExist == null) return BadRequest($"O aluno de ID \"{id}\" não foi encontrado.");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest($"O aluno de ID \"{id}\" não foi encontrado.");

            _context.Remove(aluno);
            _context.SaveChanges();

            return Ok();
        }
    }
}
