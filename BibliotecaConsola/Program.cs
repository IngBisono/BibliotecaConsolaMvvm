using BibliotecaConsola.ViewModels;
using BibliotecaConsola.Views;

// La Vista recibe el ViewModel. Program solo conecta las piezas de la aplicación.
// Esto evita colocar reglas de biblioteca directamente en la consola.
BibliotecaViewModel viewModel = new BibliotecaViewModel();
ConsolaBibliotecaView vista = new ConsolaBibliotecaView(viewModel);

vista.Iniciar();
