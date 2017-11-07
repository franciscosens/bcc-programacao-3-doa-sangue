using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Doacao : Model
    {
        public int IdDoador { get; set; }
        public Doador Doador { get; set; }
        public double Litros { get; set; }
        public EStatusDoacao Status { get; set; }
        public string Atendente { get; set; }
        public string StatusExtenso
        {
            get
            {
                return Status == EStatusDoacao.AGUARDANDO_ANALISE ? "Aguardando Análise" :
                    Status == EStatusDoacao.EM_ANALISE ? "Em Análise" :
                    Status == EStatusDoacao.ACEITO ? "Aceito" :
                    "Rejeitado";
            }
        }
    }

    public enum EStatusDoacao
    {
        AGUARDANDO_ANALISE,
        EM_ANALISE,
        ACEITO,
        REJEITADO
    }

}