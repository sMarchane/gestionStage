﻿using GestionDesStagesSM.Server.Data;
using GestionDesStagesSM.Server.Interfaces;
using GestionDesStagesSM.Shared.Modele;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GestionDesStagesSM.Server.Repositories
{
    public class StageRepository: IStageRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger<StageRepository> _logger;

        public StageRepository(ApplicationDbContext appDbContext, ILogger<StageRepository> logger)
        {
            _appDbContext = appDbContext;
            this._logger = logger;
        }

        public Stage AddStage(Stage stage)
        {
            var addedEntity = _appDbContext.Stage.Add(stage);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public IEnumerable<Stage> GetAllStages()
        {
            try
            {
                return _appDbContext.Stage.Where(c => c.StageStatutId == 1).Include(c => c.StageStatut).OrderByDescending(t => t.DateCreation);

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public IEnumerable<Stage> GetAllStagesById(string id)
            {
                // Obtenir seulement les stages d'une entreprise (actif ou non)
                return _appDbContext.Stage.Include(c => c.StageStatut).Where(c => c.Id == id).OrderByDescending(t => t.DateCreation);
            }

        public Stage GetStageByStageId(string StageId)
        {
            // Obtenir un stage précis d'une entreprise
            return _appDbContext.Stage.Include(c => c.StageStatut).FirstOrDefault(c => c.StageId == new Guid(StageId));
        }


        public Stage UpdateStage(Stage stage)
        {
            // Rechercher le stage afin d'indiquer au contexte le stage à mettre à jour
            var foundStage = _appDbContext.Stage.FirstOrDefault(e => e.StageId == stage.StageId);
            if (foundStage != null)
            {
                foundStage.Titre = stage.Titre;
                foundStage.Description = stage.Description;
                foundStage.StageStatutId = stage.StageStatutId;
                foundStage.DateCreation = stage.DateCreation;
                foundStage.Salaire = stage.Salaire;
                foundStage.TypeTravail = stage.TypeTravail;
                foundStage.Id = stage.Id;
                _appDbContext.SaveChanges();
            }
            return stage;
        }
        public PostulerStage PostulerStage(PostulerStage postulerStage)
        {
            try
            {
                // Vérifier si l'étudiant n'a pas déjà postuler pour ce stage.
                var foundPostulerStage = _appDbContext.PostulerStage.FirstOrDefault(e => e.StageId == postulerStage.StageId && e.Id == postulerStage.Id);

                // Si null il n'a pas postulé
                if (foundPostulerStage == null)
                {
                    var addedEntity = _appDbContext.PostulerStage.Add(postulerStage);
                    _appDbContext.SaveChanges();
                    return addedEntity.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans la création d'un enregistrement {ex}");
                return null;
            }

        }
    }
}
