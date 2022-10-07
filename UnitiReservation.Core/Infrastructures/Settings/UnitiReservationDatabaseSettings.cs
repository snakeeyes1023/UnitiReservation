namespace UnitiReservation.Core.Infrastructures.Settings
{
    public class UnitiReservationDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ReservationCollectionName { get; set; } = null!;
    }
}