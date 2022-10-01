using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebVickViagensTurismoAPI.Models;
using System.Web.Http.Cors;

namespace WebVickViagensTurismoAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {
        static readonly IClienteRepositorio clienteRepositorio = new ClienteRepositorio();
        public HttpResponseMessage GetAllClientes()
        {
            List<Cliente> listaClientes = clienteRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Cliente>>(HttpStatusCode.OK, listaClientes);
        }
        public HttpResponseMessage GetCliente(int id)
        {
            Cliente cliente = clienteRepositorio.Get(id);
            if (cliente == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cliente não localizado para o Id informado");
            }
            else
            {
                return Request.CreateResponse<Cliente>(HttpStatusCode.OK, cliente);
            }
        }
        public IEnumerable<Cliente> GetEstudantesPorSexo(string sexo)
        {
            return clienteRepositorio.GetAll().Where(
                e => string.Equals(e.SEXO, sexo, StringComparison.OrdinalIgnoreCase));
        }
    }
}
