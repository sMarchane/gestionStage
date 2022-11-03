﻿using GestionDesStagesSM.Shared.Modele;

namespace GestionDesStagesSM.Client.Interfaces
{
    public interface IStageDataService
    {
        Task<Stage> AddStage(Stage stage);
        Task<IEnumerable<Stage>> GetAllStages(string id = null);

        Task<Stage> GetStageByStageId(string StageId);

        Task UpdateStage(Stage stage);
    }
}