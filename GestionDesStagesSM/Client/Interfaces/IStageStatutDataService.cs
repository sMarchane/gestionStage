using GestionDesStagesSM.Shared.Modele;

namespace GestionDesStagesSM.Client.Interfaces
{
    public interface IStageStatutDataService
    {
        Task<IEnumerable<StageStatut>> GetAllStageStatuts();
    }
}