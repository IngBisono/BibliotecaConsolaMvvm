# Biblioteca CRUD por consola

Proyecto C# muy simple para Visual Studio Community. Permite hacer CRUD de libros sin base de datos: los datos se guardan temporalmente en una lista mientras el programa está abierto.

## Abrir y ejecutar

1. Abra `BibliotecaConsola.sln` con Visual Studio Community.
2. Presione `Ctrl + F5` para ejecutar sin depurar.
3. Use el menú: agregar, eliminar, modificar y ver existencias.

## Estructura MVVM

- `Models/Libro.cs`: datos de un libro.
- `Views/ConsolaBibliotecaView.cs`: menú, entrada y salida por consola.
- `ViewModels/BibliotecaViewModel.cs`: conecta la Vista con el repositorio y expone los comandos.
- `Services/RepositorioLibrosEnMemoria.cs`: guarda los libros en una `List` mientras la aplicación está abierta.

La consola no tiene enlaces visuales como WPF, pero conserva la separación MVVM: la Vista no guarda datos, el ViewModel no escribe por consola y el repositorio no conoce el menú.

## CommunityToolkit.Mvvm

El paquete `CommunityToolkit.Mvvm` 8.4.0 está instalado. En el ViewModel:

- `[ObservableProperty]` genera las propiedades como `Id`, `Titulo` y `Mensaje` desde campos privados.
- `[RelayCommand]` genera comandos como `AgregarLibroCommand` y `EliminarLibroCommand`.

## SOLID para explicar

1. **S - Responsabilidad única:** cada clase tiene una tarea: `Libro` representa datos, el repositorio almacena, el ViewModel coordina y la Vista conversa con el usuario.
2. **O - Abierto/cerrado:** si luego se quiere agregar un repositorio de archivo, se crea una clase nueva sin modificar `RepositorioLibrosEnMemoria`.
3. **L - Sustitución de Liskov:** `RepositorioLibrosEnMemoria` cumple lo que prometen `IConsultaLibros` e `IAdministracionLibros`; otra clase que respete esos contratos puede ocupar su lugar cuando se trabaje con ellos.
4. **I - Segregación de interfaces:** `IConsultaLibros` solo consulta; `IAdministracionLibros` solo modifica. Una clase no depende de métodos que no necesita.

## Flujo sencillo para presentar

1. Agrega un libro con ID `1`, título `C# básico`, autor `Ana` y existencias `5`.
2. Elige **Ver existencias**.
3. Elige **Modificar** y usa el mismo ID con existencias `8`.
4. Elige **Eliminar** con el ID `1`.

Al cerrar el programa, la lista se pierde intencionalmente porque no hay base de datos.
