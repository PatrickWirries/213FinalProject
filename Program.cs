using _213FinalProject.Components;
using Microsoft.EntityFrameworkCore;
using _213FinalProject.Data;
using _213FinalProject.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<_213FinalProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("_213FinalProjectContext") ?? throw new InvalidOperationException("Connection string '_213FinalProjectContext' not found.")));


var app = builder.Build();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<_213FinalProjectContext>();
SeedData.Initialize(context);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
