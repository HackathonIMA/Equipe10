using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading;
using System.Web;

namespace SMC.WebApi.Models.Mappers
{
    public class MuralModelMap : EntityTypeConfiguration<MuralModel>
    {
        public MuralModelMap()
        {
            ToTable("Mural");
            HasKey(p => p.Id);
            Property(p => p.Escola_Id).HasMaxLength(50);
            Property(p => p.Conteudo).HasMaxLength(250);
            Property(p => p.Curtidas);
        }
                   

    }
}