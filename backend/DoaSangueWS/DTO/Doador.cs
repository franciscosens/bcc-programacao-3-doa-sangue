using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class Doador : Model
    {

        public int IdHemocentro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public ETipoSanguineo TipoSanguineo { get; set; }
        public bool FatorRH { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public DateTime DataNascimento { get; set; }
        public Hemocentro Hemocentro { get; set; }
        public string TipoSanguineoFatorRH { get { return Enum.GetName(typeof(ETipoSanguineo), TipoSanguineo)+ (FatorRH ? "+" : "-"); } }
        public string NomeCompleto { get { return Nome + " " + Sobrenome; } }
        public List<Doacao> Doacoes { get; set; }

    }

    public  enum ETipoSanguineo
    {
        A = 1,
        B = 2,
        AB = 3,
        O = 4
    }

}