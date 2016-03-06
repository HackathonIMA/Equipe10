using System.Data.Entity.ModelConfiguration;

namespace SMC.WebApi.Models.Mappers
{
    public class ComentarioMap : EntityTypeConfiguration<ComentarioModel>
    {
        public ComentarioMap()
        {
            ToTable("Comentarios");
            HasRequired(x => x.Escola);
            HasKey(p => p.Id);
            Property(p => p.Usuario).HasMaxLength(100);
            Property(p => p.Comentario).HasMaxLength(500);
            Property(p => p.EstaDenunciado);
            Property(p => p.DataCadastro);
        }

    }
}