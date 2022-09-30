using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebVickViagensTurismoAPI.Models
{
    interface IPagamentoRepositorio
    {
        IEnumerable<Pagamento> GetAll();
        Pagamento Get(int id);
    }
}
