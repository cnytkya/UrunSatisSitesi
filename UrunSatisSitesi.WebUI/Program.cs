using Microsoft.EntityFrameworkCore;
using UrunSatisSitesi.Data;
using UrunSatisSitesi.Service.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddDbContext<DatabaseContext>(); //options => options.UseSqlServer() uygulamada dabasecontext imizde sql server kullanaca��m�z� bildirdik
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>)); // Projede bir yerde IRepository interfaci kullan�lmak istenirse, Repository nesnesinden bir �rnek olu�tur ve kullan�ma sun.
// Dependency injection y�ntemi olarak 3 farkl� y�ntemimiz var;
// 1-AddSingleton : Olu�turmas� istenen nesneden uygulama �al��t���nda 1 tane olu�tururu ve her istekte bu nesneyi g�nderir.
// 2-AddTransient : Olu�turmas� istenen nesne i�in gelen her istekte yani bir nesne olu�turur.
// 3-AddScoped : Olu�turmas� istenen nesne i�in gelen iste�e bakarak e�er daha �nce olu�mu� bir �rnek varsa geriye onu d�ner, yoksa yeni nesne olu�turup d�ner.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication(); // oturum a�ma i�lemi yapaca��z admin i�in
app.UseAuthorization(); // Authorization : yetkilendirme, rol vb i�lemler i�in

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
