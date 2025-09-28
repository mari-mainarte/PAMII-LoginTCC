using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace LoginSIME.Models
{
    public class LoginDTO
    {
        [JsonProperty("rmUsuario")]
        public string Rm { get; set; } = string.Empty;

        [JsonProperty("idTipoPerfil")]
        public int IdTipoPerfil { get; set; }

        [JsonProperty("senhaUsuario")]
        public string Senha { get; set; } = string.Empty;

        [JsonProperty("codEscola")]
        public string CodEscola { get; set; } = string.Empty;

    }
}
