using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebVickViagensTurismoAPI.Models
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        private List<Pagamento> lst_pagamento = new List<Pagamento>();
        public PagamentoRepositorio()
        {
            Conectar();
        }

        public IEnumerable<Pagamento> GetAll()
        {
            return lst_pagamento;
        }
        public Pagamento Get(int id)
        {
            return lst_pagamento.Find(s => s.IDPAGAMENTO == id);
        }
        public void Conectar()
        {
            string conexao = @"Server=tcp:serv002.database.windows.net,1433;Initial Catalog=dbViagem;Persist Security Info=False;User ID=dbvitu;Password=vV963852;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;";
            string selectQuery = "select p.IDPAGAMENTO,p.IDEVENTO,p.VALOR,p.IDRESERVA,pe.NOME from pagamento p inner join RESERVA_EXCURSAO rs on rs.IDRESERVA = p.IDRESERVA inner join PESSOAS pe on pe.IDPESSOA = rs.IDPESSOA";

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
                        lst_pagamento.Add(new Pagamento { IDEVENTO= (decimal)result["IDEVENTO"], IDPAGAMENTO = (decimal)result["IDPAGAMENTO"], IDRESERVA = (decimal)result["IDRESERVA"],  VALOR = (decimal)result["VALOR"], NOME_PESSOA= (string) result["NOME"] });
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