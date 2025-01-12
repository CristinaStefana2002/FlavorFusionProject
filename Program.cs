using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FlavorFusion.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Recipes");
    options.Conventions.AuthorizeFolder("/MealPlans");
   

}); ;
builder.Services.AddDbContext<FlavorFusionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlavorFusionContext") ?? throw new InvalidOperationException("Connection string 'FlavorFusionContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlavorFusionContext") ?? throw new InvalidOperationException("Connection string 'FlavorFusionContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LibraryIdentityContext>(); ;

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
