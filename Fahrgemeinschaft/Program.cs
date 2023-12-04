using Fahrgemeinschaft;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/Login/AccessDenied";
    });
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
    options.AddPolicy("ListRegistrations", policyBuilder => policyBuilder.RequireRole("RegistrationReader"));
    options.AddPolicy("DeleteRegistrations", policyBuilder => policyBuilder.RequireRole("RegistrationManager"));
    options.AddPolicy("ImportRegistrations", policyBuilder => policyBuilder.RequireRole("RegistrationManager"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUserStore>(ctx =>
{
    return new StaticUserStore(new StaticUserStore.User[]
    {
        new("niklas", "1234", new[] { "RegistrationReader", "RegistrationManager" }),
        new("Jak@icloud.com", "abcd", new[] { "RegistrationReader" }),
    });
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<Authenticator>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
