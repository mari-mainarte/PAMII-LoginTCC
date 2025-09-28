using LoginSIME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSIME.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "http://localhost:8080/usuarios";

        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<TokenDTO> PostLoginUsuario(LoginDTO login)
        {
            string urlComplementar = "/login";

            TokenDTO tokenDTO = await _request.PostLoginAsync<LoginDTO, TokenDTO>(_apiUrlBase + urlComplementar, login);

            return tokenDTO;
            
        }
    }
}
