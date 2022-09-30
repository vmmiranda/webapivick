using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebVickViagensTurismoAPI.Models
{
    interface IExcursaoRepositorio
    {
        IEnumerable<Excursao> GetAll();
        Excursao Get(int id);
    }
}
