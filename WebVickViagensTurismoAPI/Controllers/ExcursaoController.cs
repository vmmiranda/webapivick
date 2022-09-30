using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebVickViagensTurismoAPI.Models;

namespace WebVickViagensTurismoAPI.Controllers
{
    public class ExcursaoController : ApiController
    {
        static readonly IExcursaoRepositorio excursaoRepositorio = new ExcursaoRepositorio();
        public HttpResponseMessage GetAllExcursao()
        {
            List<Excursao> listaExcursao = excursaoRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Excursao>>(HttpStatusCode.OK, listaExcursao);
        }
        public HttpResponseMessage GetExcursao(int id)
        {
            Excursao excursao = excursaoRepositorio.Get(id);
            if (excursao == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Excursão não localizada para o Id informado");
            }
            else
            {
                return Request.CreateResponse<Excursao>(HttpStatusCode.OK, excursao);
            }
        }
        public IEnumerable<Excursao> GetExcursaoPorEvento(decimal idEvento)
        {
            return excursaoRepositorio.GetAll().Where(
                e => e.IDEVENTO == idEvento);
        }

        public IEnumerable<Excursao> GetExcursaoPorNomeEvento(string nome_evento)
        {
            return excursaoRepositorio.GetAll().Where(
                e => string.Equals(e.NOME_EVENTO, nome_evento, StringComparison.OrdinalIgnoreCase));
        }
    }
}
