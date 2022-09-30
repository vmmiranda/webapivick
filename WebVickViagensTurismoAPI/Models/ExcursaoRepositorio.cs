using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebVickViagensTurismoAPI.Models
{
    public class ExcursaoRepositorio : IExcursaoRepositorio
    {
        private List<Excursao> lst_excursao = new List<Excursao>();
        public ExcursaoRepositorio()
        {
            Conectar();
        }

        public IEnumerable<Excursao> GetAll()
        {
            return lst_excursao;
        }
        public Excursao Get(int id)
        {
            return lst_excursao.Find(s => s.IDEXCURSAO == id);
        }
        public void Conectar()
        {
            string conexao = @"Server=tcp:serv002.database.windows.net,1433;Initial Catalog=dbViagem;Persist Security Info=False;User ID=dbvitu;Password=vV963852;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;";
            string selectQuery = "select IDEXCURSAO,  ex.IDEVENTO,ex.IDPESSOA , ev.NOME_EVENTO,pe.NOME from EXCURSAO ex inner join EVENTO ev on ev.IDEVENTO = ex.IDEVENTO inner join pessoas pe on pe.IDPESSOA = ex.IDPESSOA";

            try
            {
                using (SqlConnection connection = new SqlConnection(conexao))
                {
                    //open connection
                    connection.Open();

                    SqlCommand command = new SqlCommand(selectQuery, connection);

                    command.Connection = connection;
                    command.CommandText = selectQuery;
                    var result = command.ExecuteReader();

                    while (result.Read())
                    {
                        lst_excursao.Add(new Excursao { IDEXCURSAO = (decimal)result["IDEXCURSAO"], IDEVENTO = (decimal)result["IDEVENTO"], IDPESSOA = (decimal)result["IDPESSOA"], NOME_EVENTO = (string)result["NOME_EVENTO"], NOME = (string)result["NOME"] });
                    }

                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}