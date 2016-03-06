using System.Data.Entity.ModelConfiguration;

namespace SMC.WebApi.Models.Mappers
{
    public class EscolaMap : EntityTypeConfiguration<Escola>
    {
        public EscolaMap()
        {
            ToTable("Escolas");

            HasKey(p => p.Id);
            Property(p => p.NomeUnidadeEscolar).HasMaxLength(250);
            Property(p => p.Bairro).HasMaxLength(250);
            Property(p => p.Descricao).HasMaxLength(500);
            Property(p => p.LogradouroDemanda).HasMaxLength(250);
            Property(p => p.MunicipioDemanda).HasMaxLength(70);
            Property(p => p.UfDemanda).HasMaxLength(2);
            Property(p => p.CepDemanda).HasMaxLength(10);
            Property(p => p.Telefone).HasMaxLength(20);
            Property(p => p.Endereco).HasMaxLength(20);
        }
    }
}