using DTO;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class HemocentroBLL : BaseValidator<Hemocentro>, IEntityBase<Hemocentro>
    {
        HemocentroDAL hemocentroDAL = new HemocentroDAL();

        public bool Delete(int id)
        {
            return hemocentroDAL.Delete(id);
        }

        public bool Exists(Hemocentro item)
        {
            throw new NotImplementedException();
        }

        public List<Hemocentro> GetAll()
        {
            return hemocentroDAL.GetAll();
        }

        public Hemocentro GetById(int id)
        {
            return hemocentroDAL.GetById(id);
        }

        public int Insert(Hemocentro item)
        {
            if (!IsValid(item))
            {
                throw new Exception(GetErros());
            }
            return hemocentroDAL.Insert(item);
        }

        public int Update(Hemocentro item)
        {
            if (!IsValidUpdate(item))
            {
                throw new Exception(GetErros());
            }
            return hemocentroDAL.Update(item);
        }

        public override bool IsValid(Hemocentro item)
        {
            if (string.IsNullOrWhiteSpace(item.Nome))
                AddError("Nome deve ser preenchido.");
            else if (item.Nome.Length < 3 || item.Nome.Length > 100)
                AddError("Nome deve ter no mínimo 3 caracteres e no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(item.Estado))
                AddError("Estado deve ser preenchido.");
            else if (item.Nome.Length != 2)
                AddError("Nome deve ter no mínimo 2 caracteres e no máximo 2 caracteres.");

            if (string.IsNullOrWhiteSpace(item.Cidade))
                AddError("Cidade deve ser preenchida.");
            else if (item.Cidade.Length < 3 || item.Cidade.Length > 100)
                AddError("Cidade deve ter no mínimo 3 caracteres e no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(item.Bairro))
                AddError("Bairro deve ser preenchido.");
            else if (item.Bairro.Length < 3 || item.Bairro.Length > 100)
                AddError("Bairro deve ter no mínimo 3 caracteres e no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(item.Numero))
                AddError("Número deve ser preenchido.");

            if (string.IsNullOrWhiteSpace(item.Logradouro))
                AddError("Logradouro deve ser preenchido.");
            else if (item.Logradouro.Length < 3 || item.Logradouro.Length > 100)
                AddError("Logradouro deve ter no mínimo 3 caracteres e no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(item.CEP))
                AddError("CEP deve ser preenchido.");
            else if (item.CEP.Length != 9)
                AddError("CEP deve ter no mínimo 8 caracteres e no máximo 8 caracteres.");

            return base.HasErrors();
        }

        public override bool IsValidUpdate(Hemocentro item)
        {

            if (item.Id == 0)
                AddError("Código do hemocentro deve ser informado.");
            else if (!hemocentroDAL.ExistsById(item.Id))
                AddError("Hemocentro informado não existe.");

            if (string.IsNullOrWhiteSpace(item.Nome))
                AddError("Nome deve ser preenchido.");
            else if (item.Nome.Length < 3 || item.Nome.Length > 100)
                AddError("Nome deve ter no mínimo 3 caracteres e no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(item.Estado))
                AddError("Estado deve ser preenchido.");
            else if (item.Nome.Length != 2)
                AddError("Nome deve ter no mínimo 2 caracteres e no máximo 2 caracteres.");

            if (string.IsNullOrWhiteSpace(item.Cidade))
                AddError("Cidade deve ser preenchida.");
            else if (item.Cidade.Length < 3 || item.Cidade.Length > 100)
                AddError("Cidade deve ter no mínimo 3 caracteres e no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(item.Bairro))
                AddError("Bairro deve ser preenchido.");
            else if (item.Bairro.Length < 3 || item.Bairro.Length > 100)
                AddError("Bairro deve ter no mínimo 3 caracteres e no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(item.Numero))
                AddError("Número deve ser preenchido.");

            if (string.IsNullOrWhiteSpace(item.Logradouro))
                AddError("Logradouro deve ser preenchido.");
            else if (item.Logradouro.Length < 3 || item.Logradouro.Length > 100)
                AddError("Logradouro deve ter no mínimo 3 caracteres e no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(item.CEP))
                AddError("CEP deve ser preenchido.");
            else if (item.CEP.Length != 9)
                AddError("CEP deve ter no mínimo 8 caracteres e no máximo 8 caracteres.");

            return base.HasErrors();
        }
    }
}
