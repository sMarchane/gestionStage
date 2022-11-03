using GestionDesStagesSM.Shared.Modele;
using Microsoft.AspNetCore.Mvc;

namespace GestionDesStagesSM.Server.Interfaces
{
    public interface IStageRepository
    {
       Stage AddStage(Stage stage);
        IEnumerable<Stage> GetAllStagesById(string id);
        IEnumerable<Stage> GetAllStages();

        Stage GetStageByStageId(string id);

        Stage UpdateStage(Stage stage);
    }
}
