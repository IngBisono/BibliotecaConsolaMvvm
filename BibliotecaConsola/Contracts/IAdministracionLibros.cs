using BibliotecaConsola.Models;

namespace BibliotecaConsola.Contracts;

// ISP: las operaciones que cambian existencias viven en un contrato separado.
public interface IAdministracionLibros
{
    bool Agregar(Libro libro);

    bool Modificar(Libro libro);

    bool Eliminar(int id);
}
