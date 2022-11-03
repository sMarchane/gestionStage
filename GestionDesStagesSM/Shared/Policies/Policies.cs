
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesStagesSM.Shared.Policies
{
    public static class Policies
    {
        public const string EstEntreprise = "EstEntreprise";
        public const string EstEtudiant = "EstEtudiant";
        public const string EstCoordinateur = "EstCoordinateur";



        public static AuthorizationPolicy EstEntreprisePolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole("Entreprise").Build();
        }
        public static AuthorizationPolicy EstEtudiantPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole("Etudiant").Build();
        }
    }
}
