using GestionDesStagesSM.Server.Data;
using GestionDesStagesSM.Server.Interfaces;
using GestionDesStagesSM.Shared.Modele;
using Microsoft.EntityFrameworkCore;

namespace GestionDesStagesSM.Server.Repositories
{
    public class EtudiantRepository : IEtudiantRepository
    {

        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger<EtudiantRepository> _logger;

        public EtudiantRepository(ApplicationDbContext appDbContext, ILogger<EtudiantRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }


        Etudiant IEtudiantRepository.AddEtudiant(Etudiant etudiant)
        {
            try
            {
                var addedEntity = _appDbContext.Etudiant.Add(etudiant);
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans la création d'un enregistrement {ex}");
                return null;
            }

        }

        public Etudiant GetEtudiantById(string Id)
        {
            return _appDbContext.Etudiant.AsNoTracking().FirstOrDefault(c => c.Id == Id);
        }

        Etudiant IEtudiantRepository.UpdateEtudiant(Etudiant etudiant)
        {
            // Rechercher le stage afin d'indiquer au contexte le stage à mettre à jour
            var foundEtudiant = _appDbContext.Etudiant.FirstOrDefault(e => e.Id == etudiant.Id);
            if (foundEtudiant != null)
            {
                foundEtudiant.Prenom = etudiant.Prenom;
                foundEtudiant.Nom = etudiant.Nom;
                foundEtudiant.TelephoneCellulaire = etudiant.TelephoneCellulaire;
                _appDbContext.SaveChanges();
            }
            return foundEtudiant;
        }
    }
    
}
