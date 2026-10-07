using BibliotecaConsola.Contracts;
using BibliotecaConsola.Models;

namespace BibliotecaConsola.Services;

// SRP: esta clase solo administra la lista temporal de libros.
// OCP: se puede agregar otro repositorio (por ejemplo, de archivo) sin cambiar esta clase.
// LSP: cumple los resultados esperados por los contratos de consulta y administración.
public class RepositorioLibrosEnMemoria : IConsultaLibros, IAdministracionLibros
{
    private readonly List<Libro> _libros = new List<Libro>();

    public bool Agregar(Libro libro)
    {
        if (ObtenerPorId(libro.Id) != null)
        {
            return false;
        }

        _libros.Add(libro);
        return true;
    }

    public bool Modificar(Libro libro)
    {
        Libro? libroActual = ObtenerPorId(libro.Id);

        if (libroActual is null)
        {
            return false;
        }

        libroActual.Titulo = libro.Titulo;
        libroActual.Autor = libro.Autor;
        libroActual.Existencias = libro.Existencias;
        return true;
    }

    public bool Eliminar(int id)
    {
        Libro? libro = ObtenerPorId(id);

        if (libro is null)
        {
            return false;
        }

        _libros.Remove(libro);
        return true;
    }

    public List<Libro> ObtenerTodos()
    {
        return _libros.ToList();
    }

    public Libro? ObtenerPorId(int id)
    {
        return _libros.FirstOrDefault(libro => libro.Id == id);
    }
}
