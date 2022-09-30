using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVickViagensTurismoAPI.Models
{
    public class Excursao
    {       
        public decimal IDEXCURSAO { get; set; }
        public decimal IDEVENTO { get; set; }
        public decimal IDPESSOA { get; set; }
        public string NOME_EVENTO { get; set; }
        public string NOME { get; set; }

    }
}