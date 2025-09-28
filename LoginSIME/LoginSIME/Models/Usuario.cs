using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSIME.Models
{
    public class Usuario
    {
        public string Rm { get; set; } = string.Empty;
        public string ChamadosAbertos { get; set; } = string.Empty;
        public string ChamadosConcluidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public int IdTipoPerfil { get; set; }

    }
}
