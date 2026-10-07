using BibliotecaConsola.Models;

namespace BibliotecaConsola.Contracts;

// ISP: quien solo necesita consultar no depende de operaciones para cambiar datos.
public interface IConsultaLibros
{
    List<Libro> ObtenerTodos();

    Libro? ObtenerPorId(int id);
}
