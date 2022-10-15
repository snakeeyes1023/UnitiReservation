using UnitiReservation.Core.Infrastructures;
using UnitiReservation.Core.Infrastructures.Settings;
using UnitiReservation.Core.Services.UnitService;
using UnitiReservation.Core.Services.StatistiqueService;
using UnitiReservation.Core.Services.ReservationService;
using UnitiReservation.Core.Services.ActionsFilters;

namespace UnitiReservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<UnitiReservationDatabaseSettings>(builder.Configuration.GetSection("UnitiReservationDatabase"));
            builder.Services.AddScoped<IReservationDbContext, ReservationDbContext>();
            builder.Services.AddScoped<IUnitServices, UnitServices>();
            builder.Services.AddScoped<IStatistiqueService, StatistiqueService>();
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<IsValidApiTokenService>();

            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()));

            var app = builder.Build();

            app.UseCors("corsapp");

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}