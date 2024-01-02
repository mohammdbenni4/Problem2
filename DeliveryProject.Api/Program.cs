using System.Data;
using System.Reactive.Joins;
using System.Text.Json.Serialization;
using Autofac.Extensions.DependencyInjection;
using DeliveryProject.Infrastructure;
using DeliveryProject.Persistence;
using DeliveryProject.Persistence.Data;
using DeliveryProject.Persistence.Seed;
using Elkood.API.Middlewares.SeedMiddleware;
using Elkood.API.Swagger;
using Elkood.DependencyInjection;
using Elkood.Identity.Middlewares.ElIdentityMiddleware;
using Microsoft.AspNetCore.Builder.Extensions;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", reloadOnChange: true, optional: true)
    .AddEnvironmentVariables();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    o.JsonSerializerOptions.WriteIndented = true;
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);


builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
{
    var options = ConfigurationOptions.Parse(builder.Environment.IsDevelopment() ? "localhost" : "localhost:6380,password=testredis");
    options.ConnectRetry = 5;
    options.AllowAdmin = true;
    options.ClientName = "DeliveryProject";
    options.AbortOnConnectFail = false;
    return ConnectionMultiplexer.Connect(options);
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Environment.IsDevelopment() ? "localhost" : "localhost:6380,password=testredis";
    options.InstanceName = "DeliveryProject";

});
builder.Services
    .AddPersistence(builder.Configuration, builder.Environment)
    .AddInfrastructure(builder.Configuration)
    .AddElkood(
        DeliveryProject.Application.AssemblyReference.Assembly,
        DeliveryProject.Infrastructure.AssemblyReference.Assembly,
        DeliveryProject.Infrastructure.AssemblyReference.Assembly);
builder.Services.AddElSawgger(builder.Environment)
    .AddApiGroupNames<ElApiGroupNames>(true);
// .AddLagHeader()
// .AddDebugModeHeader();
// builder.Services.AddCors();


var app = builder.Build();
app.UseElSawgger<ElApiGroupNames>();
 app.UseCors(policyBuilder =>
 {
    policyBuilder
         .AllowAnyHeader()
         .AllowAnyMethod()
         .AllowCredentials()
         .SetIsOriginAllowed(_ => true);
 });
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
// app.UseElIdentity();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

await app.MigrationAsync<AppDbContext>(DataSeed.Seed, app.Environment.IsDevelopment());

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
