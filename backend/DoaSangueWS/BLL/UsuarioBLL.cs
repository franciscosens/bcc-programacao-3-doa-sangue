using DTO;
using DTO;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL : BaseValidator<Usuario>, IEntityBase<Usuario>
    {
        UsuarioDAL usuarioDAL = new UsuarioDAL();

        public bool Delete(int id)
        {
            return usuarioDAL.Delete(id);
        }

        public bool Exists(Usuario item)
        {
            return usuarioDAL.Exists(item);
        }

        public List<Usuario> GetAll()
        {
            return usuarioDAL.GetAll();
        }

        public Usuario GetById(int id)
        {
            return usuarioDAL.GetById(id);
        }

        public Usuario VerifyLogin(string login, string senha)
        {
            return usuarioDAL.VerifyLogin(login, senha);
        }

        public int Insert(Usuario item)
        {
            if (!IsValid(item))
            {
                throw new Exception(GetErros());
            }
            return usuarioDAL.Insert(item);
        }

        public int Update(Usuario item)
        {
            if (!IsValidUpdate(item))
            {
                throw new Exception(GetErros());
            }
            return usuarioDAL.Update(item);
        }

        public override bool IsValid(Usuario item)
        {

            if (string.IsNullOrWhiteSpace(item.Nome))
                AddError("Nome deve ser preenchido.");
            else if (item.Nome.Length < 3 || item.Nome.Length > 100)
                AddError("Nome deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            if (string.IsNullOrWhiteSpace(item.Sobrenome))
                AddError("Sobrenome deve ser preenchido.");
            else if (item.Sobrenome.Length < 3 || item.Sobrenome.Length > 100)
                AddError("Sobrenome deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            if (string.IsNullOrWhiteSpace(item.Login))
                AddError("Login deve ser preenchido.");
            else if (item.Login.Length < 3 || item.Login.Length > 100)
                AddError("Login deve ter no mínimo 6 caracteres e no máximo 30 caracteres");

            if (string.IsNullOrWhiteSpace(item.Senha))
                AddError("Senha deve ser preenchida.");
            else
            {
                if (item.Senha.Length < 3 || item.Senha.Length > 100)
                    AddError("Senha deve ter no mínimo 6 caracteres e no máximo 20 caracteres");
                if (!VerificarSenhaValida(item.Senha))
                    AddError("Senha deve ter no mínimo 6 caracteres e no máximo 20 caracteres");
            }

            if (item.Privilegio <= 0)
                AddError("Privilégio deve ser informado.");
            else if (!Enum.IsDefined(typeof(DTO.EPrivilegio), item.Privilegio))
                AddError("Privilégio informado não é um valor válido");

            if (item.DataNascimento == DateTime.MinValue)
                AddError("Data de Nascimento deve ser preenchida.");
            else if (item.DataNascimento.Date >= DateTime.Now.Date)
                AddError("Data de Nascimento deve ser inferior a data atual.");

            return base.HasErrors();
        }

        // TODO implementar para senha ter no uma letra maíuscula, minuscula, número
        private bool VerificarSenhaValida(string senha)
        {
            return true;
        }

        public override bool IsValidUpdate(Usuario item)
        {

            if (item.Id == 0)
                AddError("Código do Usuário deve ser informado");
            else if (!usuarioDAL.ExistsById(item.Id))
                AddError("Usuário informado não existe");

            if (string.IsNullOrWhiteSpace(item.Nome))
                AddError("Nome deve ser preenchido.");
            else if (item.Nome.Length < 3 || item.Nome.Length > 100)
                AddError("Nome deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            if (string.IsNullOrWhiteSpace(item.Sobrenome))
                AddError("Sobrenome deve ser preenchido.");
            else if (item.Sobrenome.Length < 3 || item.Sobrenome.Length > 100)
                AddError("Sobrenome deve ter no mínimo 3 caracteres e no máximo 100 caracteres");

            if (!string.IsNullOrWhiteSpace(item.Login))
                AddError("Não é possível alterar o Login.");


            if (string.IsNullOrWhiteSpace(item.Senha))
                AddError("Senha deve ser preenchida.");
            else
            {
                if (item.Senha.Length < 3 || item.Senha.Length > 100)
                    AddError("Senha deve ter no mínimo 6 caracteres e no máximo 20 caracteres");
                if (!VerificarSenhaValida(item.Senha))
                    AddError("Senha deve ter no mínimo 6 caracteres e no máximo 20 caracteres");
            }

            if (item.Privilegio <= 0)
                AddError("Privilégio deve ser informado.");
            else if (!Enum.IsDefined(typeof(DTO.EPrivilegio), item.Privilegio))
                AddError("Privilégio informado não é um valor válido");

            if (item.DataNascimento == DateTime.MinValue)
                AddError("Data de Nascimento deve ser preenchida.");
            else if (item.DataNascimento.Date >= DateTime.Now.Date)
                AddError("Data de Nascimento deve ser inferior a data atual.");

            return base.HasErrors();
        }
    }
}
