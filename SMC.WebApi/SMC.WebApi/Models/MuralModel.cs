using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC.WebApi.Models
{
    public class MuralModel
    {
        public int Id { get; set; }
        public string Escola_Id { get; set; }
        public string Conteudo { get; set; }
        public int Curtidas { get; set; }
    }
}