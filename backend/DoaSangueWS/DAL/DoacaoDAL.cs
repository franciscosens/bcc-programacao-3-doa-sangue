using DTO;
using DTO.Infraestrutura;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DoacaoDAL : IEntityBase<Doacao>
    {
        Conexao conexao = new Conexao();

        public bool Delete(int id)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "DELETE FROM doacoes WHER id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery() == 1;
        }

        public bool Exists(Doacao item)
        {
            throw new NotImplementedException();
        }

        public List<Doacao> GetAll()
        {
            List<Doacao> doacoes = new List<Doacao>();
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM doacoes";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            conexao.Close();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                doacoes.Add(new Doacao()
                {
                    Id = (int)table.Rows[0]["id"],
                    Atendente = (string)table.Rows[0]["atendente"],
                    Litros = Convert.ToDouble(table.Rows[0]["litros"]),
                    IdDoador = (int)table.Rows[0]["id_doador"],
                    Doador = new DoadorDAL().GetById((int)table.Rows[0]["id_doador"]),
                    Status = (EStatusDoacao)Enum.ToObject(typeof(EStatusDoacao), table.Rows[0]["status"]),
                    DataCriacao = (DateTime)table.Rows[0]["data_criacao"]
                });
            }
            return doacoes;
        }

        public Doacao GetById(int id)
        {
            List<Doacao> doacoes = new List<Doacao>();
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM doacoes WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            conexao.Close();
            return new Doacao()
            {
                Id = (int)table.Rows[0]["id"],
                Atendente = (string)table.Rows[0]["atendente"],
                Litros = Convert.ToDouble(table.Rows[0]["litros"]),
                IdDoador = (int)table.Rows[0]["id_doador"],
                Doador = new DoadorDAL().GetById((int)table.Rows[0]["id_doador"]),
                Status = (EStatusDoacao)Enum.ToObject(typeof(EStatusDoacao), table.Rows[0]["status"]),
                DataCriacao = (DateTime)table.Rows[0]["data_criacao"]
            };
        }

        public int Insert(Doacao item)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = @"INSERT INTO doacoes (id_doador, litros, atendente, status, data_criacao)
                                    VALUES
                                    (@ID_DOADOR, @LITROS, @ATENDETE, @STATUS, @DATA_CRIACAO)";
            command.Parameters.AddWithValue("@ID_DOADOR", item.IdDoador);
            command.Parameters.AddWithValue("@LITROS", item.Litros);
            command.Parameters.AddWithValue("@ATENDETE", item.Atendente);
            command.Parameters.AddWithValue("@STATUS", EStatusDoacao.AGUARDANDO_ANALISE);
            command.Parameters.AddWithValue("@DATA_CRIACAO", DateTime.Now);
            return command.ExecuteNonQuery();
        }

        public int Update(Doacao item)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "UPDATE doacoes SET status = @STATUS, data_alteracao = @DATA_ALTERACAO WHERE id = @ID";
            command.Parameters.AddWithValue("@STATUS", item.Status);
            command.Parameters.AddWithValue("@DATA_ALTERACAO", DateTime.Now);
            command.Parameters.AddWithValue("@ID", item.Id);
            return command.ExecuteNonQuery();
        }

        public List<Doacao> GetByDoadorId(int idDoador)
        {
            List<Doacao> doacoes = new List<Doacao>();
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM doacoes WHERE ID_DOADOR = @ID_DOADOR";
            command.Parameters.AddWithValue("@ID_DOADOR", idDoador);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            conexao.Close();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                doacoes.Add(new Doacao()
                {
                    Id = (int)table.Rows[0]["id"],
                    Atendente = (string)table.Rows[0]["atendente"],
                    Litros = Convert.ToDouble(table.Rows[0]["litros"]),
                    IdDoador = (int)table.Rows[0]["id_doador"],
                    Doador = new DoadorDAL().GetById((int)table.Rows[0]["id_doador"]),
                    Status = (EStatusDoacao)Enum.ToObject(typeof(EStatusDoacao), table.Rows[0]["status"]),
                    DataCriacao = (DateTime)table.Rows[0]["data_criacao"]
                });
            }
            return doacoes;
        }
    }
}