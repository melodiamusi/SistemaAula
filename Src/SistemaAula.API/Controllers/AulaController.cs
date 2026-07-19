using Microsoft.AspNetCore.Mvc;
using SistemaAula.Infrastructure.Repositorio;
using SistemaAula.Domain.Entidades;

namespace SistemaAula.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AulaController : ControllerBase
    {
        private readonly GenericRepositorio<Aula> _repositorio;

        public AulaController(GenericRepositorio<Aula> repositorio)
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
            var aula = _repositorio.ObtenerPorId(id);

            if (aula == null)
                return NotFound();

            return Ok(aula);
        }


        [HttpPost]
        public IActionResult Post(Aula aula)
        {
            _repositorio.Agregar(aula);

            return Ok(aula);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Aula aula)
        {
            aula.Id = id;

            _repositorio.Actualizar(aula);

            return Ok("Aula actualizada");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositorio.Eliminar(id);

            return Ok("Aula eliminada");
        }
    }
}
