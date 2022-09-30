using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebVickViagensTurismoAPI.Models;

namespace WebVickViagensTurismoAPI.Controllers
{
    public class EstudantesController : ApiController
    {
        static readonly IEstudanteRepositorio estudanteRepositorio = new EstudanteRepositorio();
        public HttpResponseMessage GetAllEstudantes()
        {
            List<Estudante> listaEstudantes = estudanteRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Estudante>>(HttpStatusCode.OK, listaEstudantes);
        }
        public HttpResponseMessage GetEstudante(int id)
        {
            Estudante estudante = estudanteRepositorio.Get(id);
            if (estudante == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Estudante não localizado para o Id informado");
            }
            else
            {
                return Request.CreateResponse<Estudante>(HttpStatusCode.OK, estudante);
            }
        }
        public IEnumerable<Estudante> GetEstudantesPorGenero(string genero)
        {
            return estudanteRepositorio.GetAll().Where(
                e => string.Equals(e.genero, genero, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<Estudante> GetEstudantesPorIdade(int idade)
        {
            return estudanteRepositorio.GetAll().Where(
                e => string.Equals(e.idade.ToString(), idade.ToString(), StringComparison.OrdinalIgnoreCase));
        }
        public HttpResponseMessage PostEstudante(Estudante estudante)
        {
            bool result = estudanteRepositorio.Add(estudante);
            if (result)
            {
                var response = Request.CreateResponse<Estudante>(HttpStatusCode.Created, estudante);
                string uri = Url.Link("DefaultApi", new { id = estudante.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Estudante não foi incluído com sucesso");
            }
        }
        public HttpResponseMessage PutEstudante(int id, Estudante estudante)
        {
            estudante.id = id;
            if (!estudanteRepositorio.Update(estudante))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não foi possível atualizar o estudante para o id informado");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        public HttpResponseMessage DeleteEstudante(int id)
        {
            estudanteRepositorio.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
