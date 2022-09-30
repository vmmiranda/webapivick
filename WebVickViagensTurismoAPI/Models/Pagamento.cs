using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVickViagensTurismoAPI.Models
{
    public class Pagamento
    {      
        public decimal IDPAGAMENTO { get; set; }
        public decimal IDEVENTO { get; set; }
        public decimal VALOR { get; set; }
        public decimal IDRESERVA { get; set; }

        public string NOME_PESSOA { get; set; }


    }
}