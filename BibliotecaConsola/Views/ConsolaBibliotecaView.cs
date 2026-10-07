using BibliotecaConsola.Models;
using BibliotecaConsola.ViewModels;

namespace BibliotecaConsola.Views;

// Vista de consola: muestra el menú y captura los datos del usuario.
// SRP: aquí no se guarda ni se modifica la lista directamente.
public class ConsolaBibliotecaView
{
    private readonly BibliotecaViewModel _viewModel;

    public ConsolaBibliotecaView(BibliotecaViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public void Iniciar()
    {
        int opcion;

        do
        {
            MostrarMenu();
            opcion = LeerEntero("Seleccione una opción: ");

            switch (opcion)
            {
                case 1:
                    AgregarLibro();
                    break;
                case 2:
                    EliminarLibro();
                    break;
                case 3:
                    ModificarLibro();
                    break;
                case 4:
                    MostrarExistencias();
                    break;
                case 0:
                    Console.WriteLine("Programa finalizado.");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (opcion != 0)
            {
                Pausar();
            }
        }
        while (opcion != 0);
    }

    private static void MostrarMenu()
    {
        Console.WriteLine("=== BIBLIOTECA ALEJANDRIA ===");
        Console.WriteLine("1. Agregar libro");
        Console.WriteLine("2. Eliminar libro");
        Console.WriteLine("3. Modificar libro");
        Console.WriteLine("4. Ver existencias");
        Console.WriteLine("0. Salir");
        Console.WriteLine();
    }

    private void AgregarLibro()
    {
        LeerDatosLibro();
        _viewModel.AgregarLibroCommand.Execute(null);
        Console.WriteLine(_viewModel.Mensaje);
    }

    private void EliminarLibro()
    {
        _viewModel.Id = LeerEntero("ID del libro a eliminar: ");
        _viewModel.EliminarLibroCommand.Execute(null);
        Console.WriteLine(_viewModel.Mensaje);
    }

    private void ModificarLibro()
    {
        Console.WriteLine("Escriba los nuevos datos del libro.");
        LeerDatosLibro();
        _viewModel.ModificarLibroCommand.Execute(null);
        Console.WriteLine(_viewModel.Mensaje);
    }

    private void MostrarExistencias()
    {
        _viewModel.VerExistenciasCommand.Execute(null);

        if (_viewModel.Libros.Count == 0)
        {
            Console.WriteLine("No hay libros registrados.");
            return;
        }

        Console.WriteLine("ID | TÍTULO | AUTOR | EXISTENCIAS");
        Console.WriteLine("---------------------------------------");

        foreach (Libro libro in _viewModel.Libros)
        {
            Console.WriteLine($"{libro.Id} | {libro.Titulo} | {libro.Autor} | {libro.Existencias}");
        }
    }

    private void LeerDatosLibro()
    {
        _viewModel.Id = LeerEntero("ID: ");
        _viewModel.Titulo = LeerTexto("Título: ");
        _viewModel.Autor = LeerTexto("Autor: ");
        _viewModel.Existencias = LeerEntero("Existencias: ");
    }

    private static int LeerEntero(string mensaje)
    {
        int numero;

        do
        {
            Console.Write(mensaje);
        }
        while (!int.TryParse(Console.ReadLine(), out numero));

        return numero;
    }

    private static string LeerTexto(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine() ?? string.Empty;
    }

    private static void Pausar()
    {
        Console.WriteLine();
        Console.WriteLine("Presione ENTER para continuar...");
        Console.ReadLine();
    }
}
