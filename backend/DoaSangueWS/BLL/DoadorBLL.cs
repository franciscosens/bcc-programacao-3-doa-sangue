using DTO;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DoadorBLL : BaseValidator<Doador>, IEntityBase<Doador>
    {
        DoadorDAL doadorDAL = new DoadorDAL();

        public bool Delete(int id)
        {
            return doadorDAL.Delete(id);
        }

        public bool Exists(Doador item)
        {
            return doadorDAL.Exists(item);
        }

        public List<Doador> GetAll()
        {
            return doadorDAL.GetAll();
        }

        public Doador GetById(int id)
        {
            return doadorDAL.GetById(id);
        }

        public int Insert(Doador item)
        {
            if (!IsValid(item))
            {
                throw new Exception(GetErros());
            }
            return doadorDAL.Insert(item);
        }

        public override bool IsValid(Doador item)
        {
            if (item.IdHemocentro <= 0)
                AddError("Hemocentro deve ser informado.");
            else if (!new HemocentroDAL().ExistsById(item.IdHemocentro))
                AddError("Hemocentro informado não existe");

            if (string.IsNullOrWhiteSpace(item.Nome))
                AddError("Nome deve ser preenchido.");
            else if (item.Nome.Length < 3 || item.Nome.Length > 100)
                AddError("Nome deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            if (string.IsNullOrWhiteSpace(item.Sobrenome))
                AddError("Sobrenome deve ser preenchido.");
            else if (item.Sobrenome.Length < 3 || item.Sobrenome.Length > 100)
                AddError("Sobrenome deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            if (item.Peso == 0)
                AddError("Peso deve ser preenchido.");
            else if (item.Peso < 0)
                AddError("Peso não pode ser negativo.");

            if (item.Altura == 0)
                AddError("Altura deve ser preenchida.");
            else if (item.Altura < 0)
                AddError("Altura não pode ser negativa.");
            else if (item.Altura >= 3)
                AddError("Altura não pode ser superior a 3 metros.");

            if (item.TipoSanguineo <= 0)
                AddError("Tipo Sanguíneo deve ser informado.");
            else if (!Enum.IsDefined(typeof(DTO.ETipoSanguineo), item.TipoSanguineo))
                AddError("Tipo Sanguíneo informado não é um valor válido");

            if (item.DataNascimento == DateTime.MinValue)
                AddError("Data de Nascimento deve ser preenchida.");
            else if (item.DataNascimento.Date >= DateTime.Now.Date)
                AddError("Data de Nascimento deve ser inferior a data atual.");

            return base.HasErrors();
        }

        public object GetByIdComplete(int id)
        {
            return doadorDAL.GetByIdComplete(id);
        }

        public override bool IsValidUpdate(Doador item)
        {
            if (item.Id <= 0)
                AddError("Código de doador deve ser informado.");
            if (!doadorDAL.ExistsById(item.Id))
                AddError("Doador informado não existe");

            if (item.IdHemocentro <= 0)
                AddError("Hemocentro deve ser informado.");
            if (!new HemocentroDAL().ExistsById(item.IdHemocentro))
                AddError("Hemocentro informado não existe");

            if (string.IsNullOrWhiteSpace(item.Nome))
                AddError("Nome deve ser preenchido.");
            else if (item.Nome.Length < 3 || item.Nome.Length > 100)
                AddError("Nome deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            if (string.IsNullOrWhiteSpace(item.Sobrenome))
                AddError("Sobrenome deve ser preenchido.");
            else if (item.Sobrenome.Length < 3 || item.Sobrenome.Length > 100)
                AddError("Sobrenome deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            if (item.Peso == 0)
                AddError("Peso deve ser preenchido.");
            else if (item.Peso < 0)
                AddError("Peso não pode ser negativo.");

            if (item.Altura == 0)
                AddError("Altura deve ser preenchida.");
            else if (item.Altura < 0)
                AddError("Altura não pode ser negativa.");
            else if (item.Altura >= 3)
                AddError("Altura não pode ser superior a 3 metros.");

            if (item.TipoSanguineo <= 0)
                AddError("Tipo Sanguíneo deve ser informado.");
            else if (!Enum.IsDefined(typeof(DTO.ETipoSanguineo), item.TipoSanguineo))
                AddError("Tipo Sanguíneo informado não é um valor válido");

            if (item.DataNascimento == DateTime.MinValue)
                AddError("Data de Nascimento deve ser preenchida.");
            else if (item.DataNascimento.Date >= DateTime.Now.Date)
                AddError("Data de Nascimento deve ser inferior a data atual.");

            return base.HasErrors();
        }

        public int Update(Doador item)
        {
            if (!IsValidUpdate(item))
            {
                throw new Exception(GetErros());
            }
            return doadorDAL.Update(item);
        }

    }
}
