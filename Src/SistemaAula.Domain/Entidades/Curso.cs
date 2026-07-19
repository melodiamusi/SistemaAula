namespace SistemaAula.Domain.Entidades
{
    public class Curso
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Profesor { get; set; } = string.Empty;

        public string Horario { get; set; } = string.Empty;
    }
}