using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class Usuario: Model
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public EPrivilegio Privilegio { get; set; }
    }

    public enum EPrivilegio
    {
        Atendente = 1,
        Gerente = 2
    }
}