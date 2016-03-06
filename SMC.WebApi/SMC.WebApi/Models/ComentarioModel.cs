using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMC.WebApi.Models
{
    public class ComentarioModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Comentario { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool EstaDenunciado { get; set; }

        public Escola Escola { get; set; }

    }
}