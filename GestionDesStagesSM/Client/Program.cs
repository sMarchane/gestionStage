using GestionDesStagesSM.Client;
using GestionDesStagesSM.Client.Interfaces;
using GestionDesStagesSM.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("GestionDesStagesSM.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("GestionDesStagesSM.ServerAPI"));

builder.Services.AddApiAuthorization();

builder.Services.AddAuthorizationCore(authorizationOptions =>
{
    authorizationOptions.AddPolicy(
        GestionDesStagesSM.Shared.Policies.Policies.EstEntreprise,
        GestionDesStagesSM.Shared.Policies.Policies.EstEntreprisePolicy());
    authorizationOptions.AddPolicy(
        GestionDesStagesSM.Shared.Policies.Policies.EstEtudiant,
        GestionDesStagesSM.Shared.Policies.Policies.EstEtudiantPolicy());
    //authorizationOptions.AddPolicy(
    // GestionDesStagesSM.Shared.Policies.Policies.EstCoordinnateur,
    // GestionDesStagesSM.Shared.Policies.Policies.EstCoordonnateurPolicy());
});



builder.Services.AddScoped<IStageDataService, StageDataService>();
builder.Services.AddScoped<IStageStatutDataService, StageStatutDataService>();
builder.Services.AddScoped<IEtudiantDataService, EtudiantDataService>();
await builder.Build().RunAsync();
