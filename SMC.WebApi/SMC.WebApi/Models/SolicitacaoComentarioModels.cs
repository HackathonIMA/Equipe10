using System;

namespace SMC.WebApi.Models
{
    public class SolicitacaoComentarioModels
    {
        public string Id { get; set; }
        public string IdSolicitacao { get; set; }
        public DateTime Data { get; set; }
        public string Comentario { get; set; }
        public int Curtidas { get; set; }
    }
}