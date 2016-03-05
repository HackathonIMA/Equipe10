using System.Data.Entity.ModelConfiguration;

namespace SMC.WebApi.Models.Mappers
{
    public class SolicitacaoComentarioModelsMap : EntityTypeConfiguration<SolicitacaoComentarioModels>
    {
        public SolicitacaoComentarioModelsMap()
        {
            ToTable("SolicitacaoComentarios");

            HasKey(p => p.Id);
            Property(p => p.IdSolicitacao).HasMaxLength(50); ;
            Property(p => p.Data);
            Property(p => p.Comentario).HasMaxLength(250);
            Property(p => p.Curtidas);
        }
    }
}