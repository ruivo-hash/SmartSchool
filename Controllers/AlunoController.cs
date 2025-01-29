using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;

namespace SmartSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno()
            {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Almeida",
                Telefone = "123456789"
            },
            new Aluno()
            {
                Id = 2,
                Nome = "Lucas",
                Sobrenome = "Maria",
                Telefone = "123456789"
            },
            new Aluno()
            {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Kent",
                Telefone = "123456789"
            },
        };
        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest($"O aluno de ID \"{id}\" não foi encontrado.");

            return Ok(aluno);
        }
        [HttpGet("byName")]
        public IActionResult GetByNome(string nome, string sobreNome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.ToLower().Contains(nome.ToLower()) && a.Sobrenome.ToLower().Contains(sobreNome.ToLower()));
            if (aluno == null) return BadRequest($"O aluno \"{nome + " " + sobreNome}\" não foi encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {

            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok();
        }
    }
}
