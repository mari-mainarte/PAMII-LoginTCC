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

        public UsuarioViewModel()
        {
            _uService = new UsuarioService();
            InicializarCommands();
        }

        public void InicializarCommands()
        {
            LoginCommand = new Command(async () => await LoginUsuario());
        }

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

        public async Task LoginUsuario()
        {
            try
            {

                LoginDTO loginDTO = new LoginDTO();
                loginDTO.Rm = this.Rm;
                loginDTO.Senha = this.Senha;
                loginDTO.CodEscola = this.CodEscola;
                loginDTO.IdTipoPerfil = this.IdTipoPerfil + 1;

                TokenDTO token = await _uService.PostLoginUsuario(loginDTO);


                if (token != null)
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Bem-vindo usuário!", "Ok");

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

        #endregion
    }
}
