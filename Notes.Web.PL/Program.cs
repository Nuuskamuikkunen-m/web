using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Notes.BLL.BLL;
using Notes.DAL.DAL;
using Notes.DALInterfaces;
using Notes.BLLIntefaces;


var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("NotesConnectStr");
builder.Services.AddSingleton(connectionString);
builder.Services.AddScoped<INotesLogic, NotesLogic>();
builder.Services.AddSingleton<INotesDAO>(provider => new NoteSQLDAO(connectionString));

/*ƒл€ установки аутентификации с помощью куки в вызов services.AddAuthentication
 * передаетс€ значение CookieAuthenticationDefaults.AuthenticationScheme. 
 * ƒалее с помощью метода AddCookie() настраиваетс€ аутентификаци€.
 * ѕо сути в этом методе производитс€ конфигураци€ объекта 
 * CookieAuthenticationOptions, который описывает параметры 
 * аутентификации с помощью кук. ¬ частности, в данном случае 
 * использовано одно свойство CookieAuthenticationOptions - LoginPath.
 * Ёто свойство устанавливает относительный путь, по которому будет 
 * перенаправл€тьс€ анонимный пользователь при доступе к ресурсам, дл€ 
 * которых нужна аутентификаци€.*/

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => //CookieAuthenticationOptions
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/Login";
        options.ExpireTimeSpan = new TimeSpan(7, 0, 0, 0);

    });

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.Secure = CookieSecurePolicy.Always;
});
//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//   .AddNegotiate();
builder.Services.AddAuthorization();
// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddAuthorization(options =>
//{
//    // By default, all incoming requests will be authorized according to the default policy.
//    options.FallbackPolicy = options.DefaultPolicy;
//});
//builder.Services.AddRazorPages();

var app = builder.Build();
app.UseDeveloperExceptionPage();
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
/*¬ данном случае стоит различать пон€ти€ "аутентификаци€" и
 * "авторизаци€". јутентификаци€ отвечает на вопрос, кто пользователь. 
 * “о есть посредством аутентификации мы идентифицируем пользовател€,
 * узнаем, кто он. ј авторизаци€ отвечает на вопрос, какие права в системе 
 * имеет пользователь, позвол€ет разграничить доступ к ресурсам приложени€.*/

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
