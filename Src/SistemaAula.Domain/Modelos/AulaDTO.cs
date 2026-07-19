namespace SistemaAula.Domain.Modelos
{
    public class AulaDTO
    {
        public string Nombre { get; set; } = string.Empty;

        public int Capacidad { get; set; }

        public string Ubicacion { get; set; } = string.Empty;
    }
}