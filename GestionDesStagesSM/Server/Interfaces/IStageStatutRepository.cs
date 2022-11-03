using GestionDesStagesSM.Shared.Modele;
using Microsoft.AspNetCore.Mvc;

namespace GestionDesStagesSM.Server.Interfaces
{
    public interface IStageStatutRepository
    {

        IEnumerable<StageStatut> GetAllStageStatuts();

    }
}
