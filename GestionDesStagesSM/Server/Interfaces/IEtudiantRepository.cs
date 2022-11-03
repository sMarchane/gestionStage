using GestionDesStagesSM.Shared.Modele;

namespace GestionDesStagesSM.Server.Interfaces
{
    public interface IEtudiantRepository
    {
        Etudiant AddEtudiant(Etudiant etudiant);

        
        Etudiant GetEtudiantById(string id);

        Etudiant UpdateEtudiant(Etudiant etudiant);




    }
}
