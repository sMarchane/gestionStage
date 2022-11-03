using Duende.IdentityServer.EntityFramework.Options;
using GestionDesStagesSM.Server.Models;
using GestionDesStagesSM.Shared.Modele;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GestionDesStagesSM.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<StageStatut>  StageStatut
        {
            get;set;
        }
        public DbSet<Stage> Stage
        {
            get; set;
        }
        public DbSet<Etudiant> Etudiant
        {
            get; set;
        }

    }
}