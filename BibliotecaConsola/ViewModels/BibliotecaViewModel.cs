using System.Collections.ObjectModel;
using BibliotecaConsola.Models;
using BibliotecaConsola.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BibliotecaConsola.ViewModels;


public partial class BibliotecaViewModel : ObservableObject
{
    
    private readonly RepositorioLibrosEnMemoria _repositorio = new RepositorioLibrosEnMemoria();

    public BibliotecaViewModel()
    {
        VerExistencias();
    }

    
    [ObservableProperty]
    private int _id;

    [ObservableProperty]
    private string _titulo = string.Empty;

    [ObservableProperty]
    private string _autor = string.Empty;

    [ObservableProperty]
    private int _existencias;

    [ObservableProperty]
    private string _mensaje = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Libro> _libros = new ObservableCollection<Libro>();

    
    [RelayCommand]
    private void AgregarLibro()
    {
        if (!DatosValidos())
        {
            return;
        }

        Libro libro = CrearLibroDesdeDatos();
        bool agregado = _repositorio.Agregar(libro);
        Mensaje = agregado ? "Libro agregado correctamente." : "Ya existe un libro con ese ID.";

        if (agregado)
        {
            LimpiarDatos();
            VerExistencias();
        }
    }

    
    [RelayCommand]
    private void ModificarLibro()
    {
        if (!DatosValidos())
        {
            return;
        }

        bool modificado = _repositorio.Modificar(CrearLibroDesdeDatos());
        Mensaje = modificado ? "Libro modificado correctamente." : "No existe un libro con ese ID.";

        if (modificado)
        {
            LimpiarDatos();
            VerExistencias();
        }
    }

    
    [RelayCommand]
    private void EliminarLibro()
    {
        if (Id <= 0)
        {
            Mensaje = "El ID debe ser mayor que cero.";
            return;
        }

        bool eliminado = _repositorio.Eliminar(Id);
        Mensaje = eliminado ? "Libro eliminado correctamente." : "No existe un libro con ese ID.";

        if (eliminado)
        {
            LimpiarDatos();
            VerExistencias();
        }
    }

    
    [RelayCommand]
    private void VerExistencias()
    {
        Libros = new ObservableCollection<Libro>(_repositorio.ObtenerTodos());
    }

    private bool DatosValidos()
    {
        if (Id <= 0 || string.IsNullOrWhiteSpace(Titulo) || string.IsNullOrWhiteSpace(Autor) || Existencias < 0)
        {
            Mensaje = "Complete todos los datos. El ID debe ser mayor que cero y las existencias no pueden ser negativas.";
            return false;
        }

        return true;
    }

    private Libro CrearLibroDesdeDatos()
    {
        return new Libro
        {
            Id = Id,
            Titulo = Titulo,
            Autor = Autor,
            Existencias = Existencias
        };
    }

    private void LimpiarDatos()
    {
        Id = 0;
        Titulo = string.Empty;
        Autor = string.Empty;
        Existencias = 0;
    }
}
