using Microsoft.AspNetCore.Mvc;
using SistemaAula.Infrastructure.Repositorio;
using SistemaAula.Domain.Entidades;

namespace SistemaAula.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly GenericRepositorio<Curso> _repositorio;

        public CursoController(GenericRepositorio<Curso> repositorio)
        {
            _repositorio = repositorio;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositorio.ObtenerTodos());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var curso = _repositorio.ObtenerPorId(id);

            if (curso == null)
                return NotFound();

            return Ok(curso);
        }


        [HttpPost]
        public IActionResult Post(Curso curso)
        {
            _repositorio.Agregar(curso);

            return Ok(curso);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Curso curso)
        {
            curso.Id = id;

            _repositorio.Actualizar(curso);

            return Ok("Curso actualizado");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositorio.Eliminar(id);

            return Ok("Curso eliminado");
        }
    }
}