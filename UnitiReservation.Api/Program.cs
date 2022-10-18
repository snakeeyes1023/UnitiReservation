using UnitiReservation.Core.Infrastructures.Settings;
using UnitiReservation.Core.Infrastructures.Middleware;
using UnitiReservation.Core.Infrastructures.Configurations.IoC;
using UnitiReservation.Core.Infrastructures.Configurations.Authentication;

namespace UnitiReservation.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            #region SWAGGER
            //todo : ENLEVER AU PREMIER PUBLISH
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            builder.Services.ConfigureIOC();

            ConfigureDatabases(builder);

            builder.Services.ConfigureJwt(builder.Configuration);

            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()));

            var app = builder.Build();

            app.UseCors("corsapp");

            #region SWAGGER
            //todo : ENLEVER AU PREMIER PUBLISH
            app.UseSwagger();
            app.UseSwaggerUI();
            #endregion

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<RequestLogging>();

            app.MapControllers();

            app.Run();
        }

        private static void ConfigureDatabases(WebApplicationBuilder builder)
        {
            builder.Services.Configure<UnitiReservationDatabaseSettings>(builder.Configuration.GetSection("UnitiReservationDatabase"));
        }
    }
}