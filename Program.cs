using Microsoft.OpenApi.Models;
using System.Reflection;

namespace QuickBookApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Inject dependencies.
        builder.Services.InjectDependency();

        builder.Services.AddHttpClient();
        builder.Services.AddControllers();
        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddSwaggerGen(c =>
        //{
        //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuickBooks API", Version = "v1" });

        //    // Set the comments path for the Swagger JSON and UI.
        //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        //    c.IncludeXmlComments(xmlPath);
        //});


        var devCorsPolicy = "devCorsPolicy";

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(devCorsPolicy, builder =>
            {
                builder.WithOrigins("https://localhost:7178").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                //builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                //builder.SetIsOriginAllowed(origin => true);
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuickBooks API v1");
            //});
            app.UseCors(devCorsPolicy);
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
