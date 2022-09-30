using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebVickViagensTurismoAPI.Models
{
    interface IClienteRepositorio
    {
        IEnumerable<Cliente> GetAll();
        Cliente Get(int id);
    }
}
