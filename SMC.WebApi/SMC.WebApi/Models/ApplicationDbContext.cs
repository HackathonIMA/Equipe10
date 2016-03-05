using Microsoft.AspNet.Identity.EntityFramework;
using SMC.WebApi.Models.Mappers;

namespace SMC.WebApi.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("connectionString", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SolicitacaoComentarioModels> SolicitacaoComentarioModels
        {
            get; set;
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new SolicitacaoComentarioModelsMap());
        }
    }
}