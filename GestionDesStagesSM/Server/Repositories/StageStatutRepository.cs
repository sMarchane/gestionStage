using GestionDesStagesSM.Server.Data;
using GestionDesStagesSM.Server.Interfaces;
using GestionDesStagesSM.Shared.Modele;

namespace GestionDesStagesSM.Server.Repositories
{
    public class StageStatutRepository : IStageStatutRepository
    {
        private ApplicationDbContext _appDbContext;

        public StageStatutRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<StageStatut> GetAllStageStatuts()
        {
            return _appDbContext.StageStatut;
        }
    }
}
