using Microsoft.Extensions.DependencyInjection;
using UnitiReservation.Core.Infrastructures.Data.DbContext;
using UnitiReservation.Core.Services.Reservations;
using UnitiReservation.Core.Services.Statistics;
using UnitiReservation.Core.Services.Units;

namespace UnitiReservation.Core.Infrastructures.Configurations.IoC
{
    public static class ApplicationIoCConfiguration
    {
        public static void ConfigureIOC(this IServiceCollection services)
        {
            services.AddScoped<IReservationDbContext, ReservationDbContext>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IStatistiqueService, StatistiqueService>();
            services.AddScoped<IReservationService, ReservationService>();
        }
    }
}
