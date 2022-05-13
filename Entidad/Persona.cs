using System.ComponentModel.DataAnnotations;

namespace EjemploBlazor.Entidad;

public class Persona
{
    [Key]
    public int PersonaId { get; set; }
    public string? Nombre { get; set; }
    public string? Ocupacion { get; set; }
}