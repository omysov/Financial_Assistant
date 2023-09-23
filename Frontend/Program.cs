using Frontend.Services;
using Frontend.Services.IService;
using Frontend.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IAuthService, AuthService>();

//session
builder.Services.AddSession();

builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.ExpireTimeSpan = TimeSpan.FromHours(10);
        option.LoginPath = "/Auth/Login";
        option.AccessDeniedPath = "/Auth/AccessDenied";
    });


SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapRazorPages();

// Add session
app.UseSession();

app.Run();
