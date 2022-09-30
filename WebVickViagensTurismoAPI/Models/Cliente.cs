using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVickViagensTurismoAPI.Models
{
    public class Cliente
    {        
       
        public decimal IDPESSOA { get; set; }
        public string NOME { get; set; }
        public string NUMERO_RG { get; set; }
        public string NUMERO_CPF { get; set; }
        public string SEXO { get; set; }   
        public DateTime DATA_NASCIMENTO { get; set; }
        public string CIDADE { get; set; }

    }
}