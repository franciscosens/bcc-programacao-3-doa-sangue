using DTO.Infraestrutura;
using DTO;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HemocentroDAL : IEntityBase<Hemocentro>
    {
        Conexao conexao = new Conexao();

        public bool Delete(int id)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "DELETE FROM hemocentros WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery() == 1;
        }

        public bool Exists(Hemocentro item)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM hemocentros WHERE nome = @NOME";
            command.Parameters.AddWithValue("@NOME", item.Nome);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            return table.Rows.Count == 1;
        }


        public bool ExistsById(int id)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM hemocentros WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            return table.Rows.Count == 1;
        }

        public List<Hemocentro> GetAll()
        {
            List<Hemocentro> hemocentros = new List<Hemocentro>();

            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM hemocentros";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Hemocentro hemocentro = new Hemocentro();
                hemocentro.Id = (int)table.Rows[i]["Id"];
                hemocentro.Nome = (string)table.Rows[i]["nome"];
                hemocentro.Descricao = table.Rows[i]["descricao"] == DBNull.Value ? string.Empty :(string)table.Rows[i]["descricao"] ;
                hemocentro.Estado = (string)table.Rows[i]["estado"];
                hemocentro.Cidade = (string)table.Rows[i]["cidade"];
                hemocentro.Bairro = (string)table.Rows[i]["bairro"];
                hemocentro.Logradouro = (string)table.Rows[i]["logradouro"];
                hemocentro.Numero = (string)table.Rows[i]["numero"];
                hemocentro.CEP = (string)table.Rows[i]["cep"];
                hemocentro.Complemento = table.Rows[i]["complemento"] == DBNull.Value ? string.Empty : (string)table.Rows[i]["complemento"];
                hemocentro.DataCriacao = (DateTime)table.Rows[i]["data_criacao"];
                hemocentros.Add(hemocentro);
            }
            conexao.Close();
            return hemocentros;
        }

        public Hemocentro GetById(int id)
        {
            Hemocentro hemocentro = null;
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM hemocentros WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            if(table.Rows.Count == 1)
            {
                hemocentro = new Hemocentro();
                hemocentro.Id = (int)table.Rows[0]["Id"];
                hemocentro.Nome = (string)table.Rows[0]["nome"];
                hemocentro.Descricao = table.Rows[0]["descricao"] == DBNull.Value ? string.Empty : (string)table.Rows[0]["descricao"];
                hemocentro.Estado = (string)table.Rows[0]["estado"];
                hemocentro.Cidade = (string)table.Rows[0]["cidade"];
                hemocentro.Bairro = (string)table.Rows[0]["bairro"];
                hemocentro.Logradouro = (string)table.Rows[0]["logradouro"];
                hemocentro.Numero = (string)table.Rows[0]["numero"];
                hemocentro.CEP = (string)table.Rows[0]["cep"];
                hemocentro.Complemento = table.Rows[0]["complemento"] == DBNull.Value ? string.Empty : (string)table.Rows[0]["complemento"];
            }
            conexao.Close();
            return hemocentro;
        }

        public int Insert(Hemocentro item)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = @"INSERT INTO hemocentros (bairro, cep, cidade, complemento, descricao, estado, logradouro, nome, numero, data_criacao)
                                    VALUES (@BAIRRO, @CEP, @CIDADE, @COMPLEMENTO, @DESCRICAO, @ESTADO, @LOGRADOURO, @NOME, @NUMERO, @DATA_CRIACAO)";
            command.Parameters.AddWithValue("@BAIRRO", item.Bairro);
            command.Parameters.AddWithValue("@CEP", item.CEP);
            command.Parameters.AddWithValue("@CIDADE", item.Cidade);
            command.Parameters.AddWithValue("@COMPLEMENTO", item.Complemento == null ? "" : item.Complemento);
            command.Parameters.AddWithValue("@DESCRICAO", item.Descricao == null ? "" : item.Descricao);
            command.Parameters.AddWithValue("@ESTADO", item.Estado);
            command.Parameters.AddWithValue("@LOGRADOURO", item.Logradouro);
            command.Parameters.AddWithValue("@NOME", item.Nome);
            command.Parameters.AddWithValue("@NUMERO", item.Numero);
            command.Parameters.AddWithValue("@DATA_CRIACAO", DateTime.Now);
            return command.ExecuteNonQuery();
        }

        public int Update(Hemocentro item)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = @"UPDATE hemocentros SET
                                        bairro = @BAIRRO, 
                                        cep = @CEP, 
                                        cidade = @CIDADE, 
                                        complemento = @COMPLEMENTO, 
                                        descricao = @DESCRICAO,
                                        estado = @ESTADO, 
                                        logradouro = @LOGRADOURO, 
                                        nome = @NOME, 
                                        numero = @NUMERO,
                                        data_alteracao = @DATA_ALTERACAO
                                        WHERE id = @ID";
            command.Parameters.AddWithValue("@BAIRRO", item.Bairro);
            command.Parameters.AddWithValue("@CEP", item.CEP);
            command.Parameters.AddWithValue("@CIDADE", item.Cidade);
            command.Parameters.AddWithValue("@COMPLEMENTO", item.Complemento == null ? "" : item.Complemento);
            command.Parameters.AddWithValue("@DESCRICAO", item.Descricao == null ? "" : item.Descricao);
            command.Parameters.AddWithValue("@ESTADO", item.Estado);
            command.Parameters.AddWithValue("@LOGRADOURO", item.Logradouro);
            command.Parameters.AddWithValue("@NOME", item.Nome);
            command.Parameters.AddWithValue("@NUMERO", item.Numero);
            command.Parameters.AddWithValue("@DATA_ALTERACAO", DateTime.Now);
            command.Parameters.AddWithValue("@ID", item.Id);
            return command.ExecuteNonQuery();
        }
    }
}