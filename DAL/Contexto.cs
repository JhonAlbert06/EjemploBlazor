using Microsoft.EntityFrameworkCore;
using EjemploBlazor.Entidad;

namespace EjemploBlazor.DAL;

public class Contexto : DbContext
{
    public DbSet<Persona> Persona { get; set; }

    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

}
