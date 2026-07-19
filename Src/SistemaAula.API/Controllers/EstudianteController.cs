using Microsoft.AspNetCore.Mvc;
using SistemaAula.Infrastructure.Repositorio;
using SistemaAula.Domain.Entidades;

namespace SistemaAula.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly GenericRepositorio<Estudiante> _repositorio;

        public EstudianteController(GenericRepositorio<Estudiante> repositorio)
        {
            _repositorio = repositorio;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var estudiantes = _repositorio.ObtenerTodos();

            return Ok(estudiantes);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var estudiante = _repositorio.ObtenerPorId(id);

            if (estudiante == null)
                return NotFound();

            return Ok(estudiante);
        }


        [HttpPost]
        public IActionResult Post(Estudiante estudiante)
        {
            _repositorio.Agregar(estudiante);

            return Ok(estudiante);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Estudiante estudiante)
        {
            estudiante.Id = id;

            _repositorio.Actualizar(estudiante);

            return Ok("Estudiante actualizado");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositorio.Eliminar(id);

            return Ok("Estudiante eliminado");
        }
    }
}