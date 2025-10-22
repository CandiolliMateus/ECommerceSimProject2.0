using ECommerceSimProject2.Components;
using ECommerceSimProject2.src.ECommerceSim.API.Services.Admin;
using ECommerceSimProject2.src.ECommerceSim.Application.Admin.Handlers;
using ECommerceSimProject2.src.ECommerceSim.Application.Admin.Interfaces;
using ECommerceSimProject2.src.ECommerceSim.Domain.Sql.Interfaces;
using ECommerceSimProject2.src.ECommerceSim.Infrastructure.NoSql.Configuration;
using ECommerceSimProject2.src.ECommerceSim.Infrastructure.Sql.Persistence;
using ECommerceSimProject2.src.ECommerceSim.Infrastructure.Sql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ECommerceSimProject2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura��o dos DbContexts //
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("TsqlConnection")));

            builder.Services.AddDbContext<OracleDbContext>(
                options => options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
            //

            // Registro de depend�ncias da aplica��o
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryAdminService, CategoryAdminService>();

            builder.Services.AddScoped<CreateCategoryAdminHandler>();
            builder.Services.AddScoped<UpdateCategoryAdminHandler>();
            //

            // Registro de servi�os da API
            builder.Services.AddScoped<CategoryAdminService>();
            //

            builder.Services.Configure<MongoDbSettings>(
                builder.Configuration.GetSection("MongoDbSettings"));

            builder.Services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Adiciona suporte a controllers
            builder.Services.AddControllers();

            var app = builder.Build();

            // Aplica as migrations automaticamente ao iniciar
            using (var scope = app.Services.CreateScope())
            {
                var tsqlDb = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                // tsqlDb.Database.Migrate();

                var oracleDb = scope.ServiceProvider.GetRequiredService<OracleDbContext>();
                // oracleDb.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            // Mapeia os controllers da API
            app.MapControllers();

            // TESTE DE COMUNICA��O COM AS TABELAS VIA ENDPOINT
            app.MapPost("/testCategory", async (CategoryAdminService service) =>
            {
                await service.InsertCategoryAsync(2, "Eletrod�m�sticos");
                return Results.Ok("Categoria inserida.");
            });

            app.Run();
        }
    }
}
