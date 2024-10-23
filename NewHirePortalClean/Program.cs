using Microsoft.EntityFrameworkCore;
using NewHirePortalClean.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add DbContext for EF Core - only once
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=BRAHMS\\SQLEXPRESS;Database=NewHireDatabase;Trusted_Connection=True;TrustServerCertificate=True;"));


// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Enforce Secure attribute
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Enable session middleware

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapGet("/", context =>
    {
        context.Response.Redirect("/Splash");
        return Task.CompletedTask;
    });
});

app.MapRazorPages();

app.Run();
