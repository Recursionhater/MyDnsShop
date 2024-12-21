using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.FluentUI.AspNetCore.Components;
using MyDnsShop.Api.Components;
using MyDnsShop.Api.Extensions;
using MyDnsShop.Api.Infrastructure;
using MyDnsShop.Api.Infrastructure.Seed;
var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddFluentUIComponents();
builder.AddNpgsqlDbContext<MyDnsShopDbContext>("myDnsDb");
var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MyDnsShop.Client._Imports).Assembly);

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MyDnsShopDbContext>();
    var dbCreator = context.GetService<IRelationalDatabaseCreator>();
    var strategy = context.Database.CreateExecutionStrategy();
    await strategy.ExecuteAsync(async () =>
    {
        await dbCreator.EnsureCreatedAsync();
        Seed.Create(context);
    });
}
app.UseMyDnsShopApi();
app.Run();
