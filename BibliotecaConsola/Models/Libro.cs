namespace BibliotecaConsola.Models;

// SRP: esta clase solamente representa los datos de un libro.
public class Libro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string Autor { get; set; } = string.Empty;

    public int Existencias { get; set; }
}
