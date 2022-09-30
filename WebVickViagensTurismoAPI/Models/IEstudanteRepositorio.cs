using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebVickViagensTurismoAPI.Models
{
    public interface IEstudanteRepositorio
    {
        IEnumerable<Estudante> GetAll();
        Estudante Get(int id);
        bool Add(Estudante estudante);
        void Remove(int id);
        bool Update(Estudante estudante);
    }
}