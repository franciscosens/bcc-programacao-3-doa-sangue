using DTO.Infraestrutura;

using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsuarioDAL : IEntityBase<Usuario>
    {
        private Conexao conexao = new Conexao();

        public bool Delete(int id)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "DELETE FROM usuarios WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            int quantidade = command.ExecuteNonQuery();
            conexao.Close();
            return quantidade == 1;
        }

        public Usuario VerifyLogin(string login, string senha)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT id FROM usuarios WHERE login = @LOGIN AND senha = @SENHA";
            command.Parameters.AddWithValue("@LOGIN", login);
            command.Parameters.AddWithValue("@SENHA", Utils.GetCrypt512(senha));
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            conexao.Close();
            if(table.Rows.Count == 1)
            {
                return GetById((int)table.Rows[0]["id"]);
            }
            return null;
        }

        public bool Exists(Usuario item)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT id FROM usuarios WHERE login = @LOGIN";
            command.Parameters.AddWithValue("@LOGIN", item.Login);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            conexao.Close();
            return table.Rows.Count == 1;
        }

        public bool ExistsById(int id)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT id FROM usuarios WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            conexao.Close();
            return table.Rows.Count == 1;
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM usuarios";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            foreach (DataRow row in table.Rows)
            {
                Usuario usuario = new Usuario()
                {
                    Id = (int)row["id"],
                    Nome = (string)row["nome"],
                    Sobrenome = (string)row["sobrenome"],
                    Login = (string)row["login"],
                    Senha = (string)row["senha"],
                    Privilegio = (DTO.EPrivilegio)Enum.ToObject(typeof(DTO.EPrivilegio), row["privilegio"]),

                    DataNascimento = (DateTime)row["data_nascimento"],
                    DataCriacao = (DateTime)row["data_criacao"]
                    //DataAlteracao = (DateTime)row["data_alteracao"]
                };
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        public Usuario GetById(int id)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM usuarios WHERE id = @ID";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            DataRow row = table.Rows[0];
            Usuario usuario = new Usuario()
            {
                Id = (int)row["id"],
                Nome = (string)row["nome"],
                Sobrenome = (string)row["sobrenome"],
                Login = (string)row["login"],
                Privilegio = (DTO.EPrivilegio)Enum.ToObject(typeof(DTO.EPrivilegio), row["privilegio"]),

                DataNascimento = (DateTime)row["data_nascimento"],
                DataCriacao = (DateTime)row["data_criacao"]
                //DataAlteracao = (DateTime)row["data_alteracao"]
            };
            return usuario;
        }

        public int Insert(Usuario item)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = @"INSERT INTO usuarios 
                                    (nome, sobrenome, login, senha, privilegio, data_nascimento, data_criacao) 
                                    VALUES 
                                    (@NOME, @SOBRENOME, @LOGIN, @SENHA, @PRIVILEGIO, @DATA_NASCIMENTO, @DATA_CRIACAO)";

            command.Parameters.AddWithValue("@NOME", item.Nome);
            command.Parameters.AddWithValue("@SOBRENOME", item.Sobrenome);
            command.Parameters.AddWithValue("@LOGIN", item.Login);
            command.Parameters.AddWithValue("@SENHA", Utils.GetCrypt512(item.Senha));
            command.Parameters.AddWithValue("@PRIVILEGIO", item.Privilegio);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", item.DataNascimento);
            command.Parameters.AddWithValue("@DATA_CRIACAO", DateTime.Now);
            return command.ExecuteNonQuery();
        }

        public int Update(Usuario item)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = @"UPDATE usuarios SET 
                                    nome = @NOME, sobrenome = @SOBRENOME, senha = @SENHA, privilegio = @PRIVILEGIO, 
                                    data_nascimento = @DATA_NASCIMENTO, data_alteracao = @DATA_ALTERACAO
                                    WHERE ID = @ID";

            command.Parameters.AddWithValue("@NOME", item.Nome);
            command.Parameters.AddWithValue("@SOBRENOME", item.Sobrenome);
            command.Parameters.AddWithValue("@SENHA", SHA512.Create(item.Senha));
            command.Parameters.AddWithValue("@PRIVILEGIO", item.Privilegio);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", item.DataNascimento);
            command.Parameters.AddWithValue("@DATA_ALTECAO", DateTime.Now);
            command.Parameters.AddWithValue("@ID", item.Id);
            return command.ExecuteNonQuery();
        }


    }
}
