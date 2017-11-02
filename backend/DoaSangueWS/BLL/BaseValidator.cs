using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class BaseValidator<T>
    {
        List<string> erros = new List<string>();

        public void AddError(string erro)
        {
            erros.Add(erro);
        }

        public bool HasErrors()
        {
            return erros.Count == 0;
        }

        public String GetErros()
        {
            return String.Join("|", erros);
        }

        public abstract bool IsValid(T item);

        public abstract bool IsValidUpdate(T item);
    }
}
