using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebVickViagensTurismoAPI.Models
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private List<Cliente> lst_clientes = new List<Cliente>();
        public ClienteRepositorio()
        {
            Conectar();
        }

        public IEnumerable<Cliente> GetAll()
        {           
            return lst_clientes;
        }
        public Cliente Get(int id)
        {
            return lst_clientes.Find(s => s.IDPESSOA == id);
        }
        public void Conectar()
        {
            string conexao = @"Server=tcp:serv002.database.windows.net,1433;Initial Catalog=dbViagem;Persist Security Info=False;User ID=dbvitu;Password=vV963852;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;";
            string selectQuery = "select * from pessoas";

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
                        lst_clientes.Add(new Cliente { IDPESSOA  = (decimal) result["IDPESSOA"] , CIDADE = (string) result["CIDADE"] , NOME = (string) result["NOME"],SEXO = (string) result["SEXO"],DATA_NASCIMENTO = (DateTime) result["DATA_NASCIMENTO"]  });                   
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