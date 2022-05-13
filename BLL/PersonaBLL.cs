using Microsoft.EntityFrameworkCore;
using EjemploBlazor.DAL;
using EjemploBlazor.Entidad;
using System.Linq.Expressions;

namespace EjemploBlazor.BLL;

public class PersonaBLL
{
    private Contexto _contexto;

    public PersonaBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Guardar(Persona persona)
    {
        if (!Existe(persona.PersonaId))
            return Insertar(persona);
        else
            return Modificar(persona);
    }

    private bool Insertar(Persona persona)
    {
        bool paso = false;

        try
        {
            _contexto.Persona.Add(persona).State = EntityState.Added;
            paso = _contexto.SaveChanges() > 0;
        }
        catch (Exception)
        {
            throw;
        }

        return paso;
    }

    private bool Modificar(Persona persona)
    {
        bool paso = false;

        try
        {
            _contexto.Entry(persona).State = EntityState.Modified;
            paso = _contexto.SaveChanges() > 0;
        }
        catch (Exception)
        {
            throw;
        }
        return paso;
    }

    public bool Eliminar(int Id)
    {
        bool paso = false;

        try
        {
            var persona = _contexto.Persona.Find(Id);

            if (persona != null)
            {
                _contexto.Persona.Remove(persona);
                paso = _contexto.SaveChanges() > 0;
            }
        }
        catch (Exception)
        {
            throw;
        }

        return paso;
    }

    public Persona Buscar(int Id)
    {
        Persona? persona;

        try
        {
            persona = _contexto.Persona
                .Where(p => p.PersonaId == Id)
                .AsNoTracking()
                .SingleOrDefault();
        }
        catch (Exception)
        {
            throw;
        }

        return persona;
    }

    public bool Existe(int Id)
    {
        bool paso = false;

        try
        {
            paso = _contexto.Persona.Any(p => p.PersonaId == Id);
        }
        catch (Exception)
        {
            throw;
        }

        return paso;
    }

    public List<Persona> GetList(Expression<Func<Persona, bool>> critero)
    {
        List<Persona> lista = new List<Persona>();

        try
        {
            lista = _contexto.Persona
                .Where(critero)
                .AsNoTracking()
                .ToList();
        }
        catch (Exception)
        {
            throw;
        }

        return lista;
    }
}