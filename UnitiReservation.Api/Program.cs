using UnitiReservation.Core.Infrastructures;
using UnitiReservation.Core.Infrastructures.Settings;
using UnitiReservation.Core.Services.UnitService;

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
            builder.Services.AddSingleton<IReservationDbContext, ReservationDbContext>();
            builder.Services.AddSingleton<IUnitServices, UnitServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}