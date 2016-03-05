using SMC.Domain.Entities.Core;
using System;

namespace SMC.Domain.Entities
{
    public class Timeline : BaseEntity
    {
        public long Seq { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPost { get; set; }
        public string UserGuid { get; set; }
        public string Photo { get; set; }
    }
}