using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using SmartSchool.Data;

namespace SmartSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    { 
        private readonly SchoolContext _context;

        public ProfessorController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest($"O Professor de ID \"{id}\" não foi encontrado.");

            return Ok(professor);
        }
        [HttpGet("byName")]
        public IActionResult GetByNome(string nome)
        {
            var professor = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Nome.ToLower().Contains(nome.ToLower()));
            if (professor == null) return BadRequest($"O Professor \"{nome}\" não foi encontrado.");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var ProfessorExist = _context.Professores.FirstOrDefault(a => a.Id == id);

            if (ProfessorExist == null) return BadRequest($"O Professor de ID \"{id}\" não foi encontrado.");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var ProfessorExist = _context.Professores.FirstOrDefault(a => a.Id == id);

            if (ProfessorExist == null) return BadRequest($"O Professor de ID \"{id}\" não foi encontrado.");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);

            if (professor == null) return BadRequest($"O aluno de ID \"{id}\" não foi encontrado.");

            _context.Remove(professor);
            _context.SaveChanges();

            return Ok();
        }
    }
}
