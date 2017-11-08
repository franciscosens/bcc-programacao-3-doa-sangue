using DAL;
using DTO;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DoacaoBLL : BaseValidator<Doacao>, IEntityBase<Doacao>
    {
        DoacaoDAL doacaoDAL = new DoacaoDAL();

        public bool Delete(int id)
        {
            return doacaoDAL.Delete(id);
        }

        public bool Exists(Doacao item)
        {
            throw new NotImplementedException();
        }

        public List<Doacao> GetAll()
        {
            return doacaoDAL.GetAll();
        }

        public Doacao GetById(int id)
        {
            return doacaoDAL.GetById(id);
        }

        public int Insert(Doacao item)
        {
            if (!IsValid(item))
            {
                throw new Exception(GetErros());
            }
            return doacaoDAL.Insert(item);
        }

        public override bool IsValid(Doacao item)
        {
            if (item.IdDoador == 0)
            {
                AddError("Código do Doador deve ser informado.");
            }

            if (string.IsNullOrWhiteSpace(item.Atendente))
            {
                AddError("Atendente deve ser informado(a).");
            }
            else if (item.Atendente.Length < 5 || item.Atendente.Length > 100)
            {
                AddError("Atendente deve ter no mínimo 5 caracteres e no máximo 100 caracteres.");
            }


            if (item.Quantidade == 0)
            {
                AddError("Quantidade deve ser informada.");
            }
            else if (item.Quantidade < 0)
            {
                AddError("Quantidade não pode ser negativa.");
            } 
            else if(item.Quantidade > 500)
            {
                AddError("Quantidade não pode ser maior que 500 ml.");
            }

            return base.HasErrors();
        }

        // TODO implementar validação do update da doação
        public override bool IsValidUpdate(Doacao item)
        {
            throw new NotImplementedException();
        }

        public int Update(Doacao item)
        {
            if (!IsValidUpdate(item))
            {
                throw new Exception(GetErros());
            }
            return doacaoDAL.Update(item);
        }
    }
}