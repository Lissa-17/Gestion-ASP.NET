using GestionHopital.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GestionHopital;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(op => {
    op.Conventions.AuthorizeFolder("/Admin");
    op.Conventions.AuthorizeFolder("/Consultations");
    op.Conventions.AuthorizeFolder("/Medecins");
    op.Conventions.AuthorizeFolder("/Patients");
    op.Conventions.AuthorizeFolder("/Prescriptions");
    op.Conventions.AllowAnonymousToPage("/Admin/login");
    op.Conventions.AllowAnonymousToPage("/Admin/Register");

});
builder.Services.AddDbContext<HopitalContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("GestionHopital_SqlServer")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<HopitalContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(op => {
    op.LoginPath = "/Admin/login";    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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
