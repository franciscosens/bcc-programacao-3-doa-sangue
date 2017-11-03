using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class Hemocentro : Model
    {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public string EnderecoCompleto
        {
            get
            {
                return Estado + " - " + Cidade + " - " + Bairro + " - " + Logradouro + " - " + Numero;
            }
        }
    }
}