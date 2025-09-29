using LoginSIME.Models;
using LoginSIME.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoginSIME.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService _uService;
        public ICommand LoginCommand { get; set; }
        public ICommand LoginApiCommand { get; set; }

        public ICommand VoltarCommand { get; set; }

        public UsuarioViewModel()
        { 
            _uService = new UsuarioService();
            InicializarCommands();
        }

        public void InicializarCommands()
        {
            LoginCommand = new Command(() => LoginUsuario());
            LoginApiCommand = new Command(async () => await LoginApiUsuario());
            VoltarCommand = new Command(() => VoltarPaginaLogin());
        }

        #region variáveis de login

        int tipoPerfil = 1; //Gestor Geral
        string codigoEscola = "E01";
        string rmUsuario = "123456";
        string senhaUsuario = "senha123";

        #endregion

        #region AtributosPropriedades
        private string rm = string.Empty;
        private string senha = string.Empty;
        private string codEscola = string.Empty;
        private int idTipoPerfil;

        public string Rm
        {
            get => rm;
            set
            {
                rm = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get => senha;
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }

        public string CodEscola
        {
            get => codEscola;
            set
            {
                codEscola = value;
                OnPropertyChanged();
            }
        }

        public int IdTipoPerfil
        {
            get => idTipoPerfil;
            set
            {
                idTipoPerfil = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Métodos

        public async void LoginUsuario()
        {
            if (IdTipoPerfil == tipoPerfil) { 
                if(CodEscola == codigoEscola)
                {
                    if(Rm == rmUsuario)
                    {
                        if(Senha == senhaUsuario)
                        {
                           await Application.Current.MainPage
                                .DisplayAlert("Informação", "Bem-vindo(a) user!", "Ok");

                            Shell.Current.GoToAsync("//Home");
                        }
                        else
                        {
                            Application.Current.MainPage
                                .DisplayAlert("Informação", "Senha incorreta!", "Ok");
                        }

                    }
                    else
                    {
                        Application.Current.MainPage
                        .DisplayAlert("Informação", "Usuário com esse rm não encontrado!", "Ok");
                    }
                }
                else
                {
                    Application.Current.MainPage
                        .DisplayAlert("Informação", "Código da escola não encontrado!", "Ok");
                }
            }
            else
            {
                if (tipoPerfil == 0)
                {
                    Application.Current.MainPage
                           .DisplayAlert("Informação", "Insira o seu de tipo perfil!", "Ok");
                }
                else
                {
                    Application.Current.MainPage
                        .DisplayAlert("Informação", "Usuário com esse tipo perfil não encontrado!", "Ok");
                }
            }
        }

        public async Task LoginApiUsuario()
        {
            try
            {

                LoginDTO loginDTO = new LoginDTO();
                loginDTO.Rm = Rm;
                loginDTO.Senha = Senha;
                loginDTO.CodEscola = CodEscola;
                
                if (IdTipoPerfil == 0) {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Insira o seu de tipo perfil!", "Ok");
                }

                loginDTO.IdTipoPerfil = IdTipoPerfil;

                TokenDTO token = await _uService.PostLoginUsuario(loginDTO);


                if (token != null)
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Bem-vindo(a) user!", "Ok");

                    await Shell.Current.GoToAsync("//Home");
                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos!", "Ok");
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação",
                        ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public void VoltarPaginaLogin()
        {
            Shell.Current.GoToAsync("//MainPage");
        }

        #endregion
    }
}
