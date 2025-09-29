using LoginSIME.ViewModels.Usuarios;

namespace LoginSIME.Views;

public partial class HomeView : ContentPage
{
    UsuarioViewModel usuarioViewModel;
    public HomeView()
	{
		InitializeComponent();

        usuarioViewModel = new UsuarioViewModel();
        BindingContext = usuarioViewModel;
    }
}