using GestionDesStagesSM.Server.Data;
using GestionDesStagesSM.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using GestionDesStagesSM.Server.Interfaces;
using GestionDesStagesSM.Server.Repositories;
using GestionDesStagesSM.Client.Interfaces;
using GestionDesStagesSM.Client.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


//Ajouter les repos dans le container de services
builder.Services.AddScoped<IStageRepository, StageRepository>();
builder.Services.AddScoped<IStageStatutRepository, StageStatutRepository>();
builder.Services.AddScoped<IEtudiantRepository, EtudiantRepository>();


builder.Services.AddScoped<IStageStatutRepository, StageStatutRepository>();
//builder.Services.AddScoped<IEtudiantRepository, EtudiantRepository>();


builder.Services.AddIdentityServer()
               .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options => {
                   options.IdentityResources["openid"].UserClaims.Add("role");
                   options.ApiResources.Single().UserClaims.Add("role");
                   options.IdentityResources["openid"].UserClaims.Add("sub");
               });
// Need to do this as it maps "role" to ClaimTypes.Role and causes issues
System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler
    .DefaultInboundClaimTypeMap.Remove("role");

//builder.Services.AddIdentityServer()
//   .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
//TODO: Modifier les points de terminaisons pour la production
builder.Services.AddHttpClient<IStageDataService, StageDataService>(client => client.BaseAddress = new Uri("https://localhost:44330/"));
builder.Services.AddHttpClient<IStageStatutDataService, StageStatutDataService>(client => client.BaseAddress = new Uri("https://localhost:44330/"));
builder.Services.AddHttpClient<IEtudiantDataService, EtudiantDataService>(client => client.BaseAddress = new Uri("https://localhost:44330/"));


// Pour activer la sécurité des API commenter les lignes précédentes et décommenter les lignes suivantes
// Merci à Monsieur NICOLAS ROY étudiant (automne 2021) pour cette recherche
builder.Services.AddScoped<IStageDataService, StageDataService>();
builder.Services.AddScoped<IStageStatutDataService, StageStatutDataService>();
builder.Services.AddScoped<IEtudiantDataService, EtudiantDataService>();
