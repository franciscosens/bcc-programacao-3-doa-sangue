using DTO.Infraestrutura;
using DTO;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class DoadorDAL : IEntityBase<Doador>
    {
        Conexao conexao = new Conexao();

        public bool Delete(int id)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "DELETE FROM doadores WHER id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery() == 1;
        }

        public bool Exists(Doador item)
        {
            throw new NotImplementedException();
        }

        public List<Doador> GetAll()
        {
            List<Doador> doadores = new List<Doador>();
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM doadores";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Doador doador = new Doador();
                doador.Id = (int)table.Rows[i]["id"];
                doador.IdHemocentro = (int)table.Rows[i]["id_hemocentro"];
                doador.Hemocentro = new HemocentroDAL().GetById(doador.IdHemocentro);


                doador.Nome = (string)table.Rows[i]["nome"];
                doador.Sobrenome = (string)table.Rows[i]["sobrenome"];
                doador.TipoSanguineo = (DTO.ETipoSanguineo)Enum.ToObject(typeof(DTO.ETipoSanguineo), table.Rows[i]["tipo_sanguineo"]);

                doador.Peso = (double)table.Rows[i]["peso"];
                doador.Altura = (double)table.Rows[i]["altura"];

                doador.FatorRH = (bool)table.Rows[i]["fator_rh"];

                doador.DataNascimento = (DateTime)table.Rows[i]["data_nascimento"];
                doador.DataCriacao = (DateTime)table.Rows[i]["data_criacao"];



                //doador.DataAlteracao table.Rows[i]["data_alteracao"] != DBNull.Value ? (DateTime)table.Rows[i]["data_alteracao"] : null;
                doadores.Add(doador);
            }
            conexao.Close();
            return doadores;
        }

        public bool ExistsById(int id)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM doadores WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            return table.Rows.Count == 1;
        }

        public Doador GetByIdComplete(int id)
        {
            Doador doador = GetById(id);
            doador.Doacoes = new DoacaoDAL().GetByDoadorId(doador.Id);
            return doador;
        }

        public Doador GetById(int id)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = "SELECT * FROM doadores WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            Doador doador = new Doador();
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            conexao.Close();
            doador.Id = id;
            doador.IdHemocentro = (int)table.Rows[0]["id_hemocentro"];
            doador.Hemocentro = new HemocentroDAL().GetById(doador.IdHemocentro);

            doador.Nome = (string)table.Rows[0]["nome"];
            doador.Sobrenome = (string)table.Rows[0]["sobrenome"];
            doador.TipoSanguineo = (DTO.ETipoSanguineo)Enum.ToObject(typeof(DTO.ETipoSanguineo), table.Rows[0]["tipo_sanguineo"]);

            doador.Peso = (double)table.Rows[0]["peso"];
            doador.Altura = (double)table.Rows[0]["altura"]; ;

            doador.FatorRH = (bool)table.Rows[0]["fator_rh"];

            doador.DataNascimento = (DateTime)table.Rows[0]["data_nascimento"];
            doador.DataCriacao = (DateTime)table.Rows[0]["data_criacao"];
            //doador.DataAlteracao = (DateTime)table.Rows[0]["data_alteracao"];
            return doador;
        }

        public int Insert(Doador item)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = @"INSERT INTO doadores (id_hemocentro, nome, sobrenome, tipo_sanguineo, peso, altura, fator_rh, data_nascimento, data_criacao) 
                                        OUTPUT INSERTED.ID
                                        VALUES (@ID_HEMOCENTRO, @NOME, @SOBRENOME, @TIPO_SANGUINEO, @PESO, @ALTURA, @FATOR_RH, @DATA_NASCIMENTO, @DATA_CRIACAO)";
            command.Parameters.AddWithValue("@ID_HEMOCENTRO", item.IdHemocentro);
            command.Parameters.AddWithValue("@NOME", item.Nome);
            command.Parameters.AddWithValue("@SOBRENOME", item.Sobrenome);
            command.Parameters.AddWithValue("@TIPO_SANGUINEO", item.TipoSanguineo);
            command.Parameters.AddWithValue("@PESO", item.Peso);
            command.Parameters.AddWithValue("@ALTURA", item.Altura);
            command.Parameters.AddWithValue("@FATOR_RH", item.FatorRH);

            command.Parameters.AddWithValue("@DATA_NASCIMENTO", item.DataNascimento.Date);
            command.Parameters.AddWithValue("@DATA_CRIACAO", DateTime.Now);
            return (int)command.ExecuteScalar();
        }

        public int Update(Doador item)
        {
            SqlCommand command = conexao.GetCommand();
            command.CommandText = @"UPDATE doadores SET
	                                    id_hemocentro = @ID_HEMOCENTRO, 
	                                    nome = @NOME, 
	                                    sobrenome = @SOBRENOME, 
	                                    tipo_sanguineo = @TIPO_SANGUINEO, 
	                                    peso = @PESO, 
	                                    altura = @ALTURA, 
                                        fator_rh = @FATOR_RH,
	                                    data_nascimento = @DATA_NASCIMENTO, 
	                                    data_alteracao = @DATA_ALTERACAO
                                    WHERE id = @ID";
            command.Parameters.AddWithValue("@ID_HEMOCENTRO", item.IdHemocentro);
            command.Parameters.AddWithValue("@NOME", item.Nome);
            command.Parameters.AddWithValue("@SOBRENOME", item.Sobrenome);
            command.Parameters.AddWithValue("@TIPO_SANGUINEO", item.TipoSanguineo);
            command.Parameters.AddWithValue("@PESO", item.Peso);
            command.Parameters.AddWithValue("@ALTURA", item.Altura);
            command.Parameters.AddWithValue("@FATOR_RH", item.FatorRH);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", item.DataNascimento.Date);
            command.Parameters.AddWithValue("@DATA_ALTERACAO", DateTime.Now);
            command.Parameters.AddWithValue("@ID", item.Id);
            return command.ExecuteNonQuery();
        }
    }
}
