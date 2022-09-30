using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebVickViagensTurismoAPI.Models;

namespace WebVickViagensTurismoAPI.Controllers
{
    public class PagamentoController : ApiController
    {
        static readonly IPagamentoRepositorio pagamentoRepositorio = new PagamentoRepositorio();
        public HttpResponseMessage GetAllPagamentos()
        {
            List<Pagamento> listaClientes = pagamentoRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Pagamento>>(HttpStatusCode.OK, listaClientes);
        }
        public HttpResponseMessage GetPagamento(int id)
        {
            Pagamento pagamento = pagamentoRepositorio.Get(id);
            if (pagamento == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Pagamento não localizado para o Id informado");
            }
            else
            {
                return Request.CreateResponse<Pagamento>(HttpStatusCode.OK, pagamento);
            }
        }
        public IEnumerable<Pagamento> GetPagamentoPorEvento(decimal idEvento)
        {
            return pagamentoRepositorio.GetAll().Where(
                e => e.IDEVENTO == idEvento);
        }
    }
}
