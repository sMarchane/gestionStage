﻿using GestionDesStagesSM.Client.Interfaces;
using GestionDesStagesSM.Shared.Modele;
using GestionDesStagesSM.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Security.Cryptography;

namespace GestionDesStagesSM.Client.Pages
{
    public partial class StageView
    {
        [Inject]
        public IStageDataService StageDataService { get; set; }
        public List<Stage> Stages { get; set; } = new List<Stage>();
        [Inject]
        public AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }

        [Parameter]
        public string id { get; set; }
        private async Task<string> ObtenirClaim(string ClaimName)
        {
            // Obtenir tous les revendications (Claims) de l'utilisateur actuellement connecté.            
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();
            // Mettre les revendications dans un tableau
            _claims = user.Claims;
            // Obtenir du tableau des revendications le claim demandé pour l'utilisateur en cours
            // Attention s'il y a plusieurs claims du  même type (comme rôle) seul le premier est retourné FindFirst
            return user.FindFirst(c => c.Type == ClaimName)?.Value; ;
        }
        protected override async Task OnInitializedAsync()
        {
            // Vérifier le rôle de l'utilisateur actuellement authentifié
            if (await ObtenirClaim("role") == "Etudiant")
            {
                // Appel du service pour obtenir la liste de TOUS les stages actifs
                Stages = (await StageDataService.GetAllStages()).ToList();
            }
            else
            {
                // Appel du service pour obtenir la liste des stages d'une entreprise précise
                Stages = (await StageDataService.GetAllStages(await ObtenirClaim("sub"))).ToList();
            }
        }



    }
}
