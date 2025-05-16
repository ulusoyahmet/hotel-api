using FluentValidation;
using FluentValidation.AspNetCore; 
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Models.Mail.HotelProject.WebUI.Models;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  

builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>();

builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssemblyContaining<Program>();

builder.Services.Configure<SmtpSettings>(
    builder.Configuration.GetSection("Smtp"));

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(12);
    options.LoginPath = "/Login/Index";
});

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseStatusCodePagesWithRedirects("/ErrorPage/Error404/?code={0}");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
