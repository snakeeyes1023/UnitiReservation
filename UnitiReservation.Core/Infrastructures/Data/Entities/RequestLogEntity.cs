namespace UnitiReservation.Core.Infrastructures.Data.Entities
{
    public class RequestLogEntity : Entity
    {
        public string Method { get; set; }
        public string Url { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public DateTime RequestTimeStamp { get; set; }
        public string BodyText { get; set; }

        public RequestLogEntity(string method, string url, string ip, string port, long elapsedMilliseconds, DateTime requestTimestamp, string bodyText)
        {
            Method = method;
            Url = url;
            Ip = ip;
            Port = port;
            ElapsedMilliseconds = elapsedMilliseconds;
            RequestTimeStamp = requestTimestamp;
            BodyText = bodyText;
        }
    }
}