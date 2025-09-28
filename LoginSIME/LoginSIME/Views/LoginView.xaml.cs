using LoginSIME.ViewModels.Usuarios;

namespace LoginSIME.Views;

public partial class LoginView : ContentPage
{
    UsuarioViewModel usuarioViewModel;
    public LoginView()
    {
        InitializeComponent();

        usuarioViewModel = new UsuarioViewModel();
        BindingContext = usuarioViewModel;

    }
}