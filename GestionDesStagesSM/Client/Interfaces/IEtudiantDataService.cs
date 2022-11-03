using GestionDesStagesSM.Shared.Modele;

namespace GestionDesStagesSM.Client.Interfaces
{
    public  interface IEtudiantDataService
    {
        Task <Etudiant>AddEtudiant(Etudiant etudiant);

        Task<Etudiant> GetEtudiantById(string v);


        Task UpdateEtudiant(Etudiant etudiant);

    }
}
