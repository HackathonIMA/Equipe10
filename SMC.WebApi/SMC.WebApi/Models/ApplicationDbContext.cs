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

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new EscolaMap());
            modelBuilder.Configurations.Add(new MuralModelMap());
            modelBuilder.Configurations.Add(new ComentarioMap());
        }

    }
}