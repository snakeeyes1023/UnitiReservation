using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using UnitiReservation.Core.Infrastructures.Data.DbContext;
using UnitiReservation.Core.Infrastructures.Data.Entities;

namespace UnitiReservation.Core.Infrastructures.Middleware
{
    public class RequestLogging
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public RequestLogging(RequestDelegate next, ILogger<RequestLogging> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IReservationDbContext reservationDbContext)
        {
            var loadTimeCounter = new Stopwatch();
            var requestTimestamp = DateTime.Now;

            var bodyText = await GetRequestBodyAsync(context.Request);

            loadTimeCounter.Start();

            await _next(context);

            loadTimeCounter.Stop();

            TryInsertLogInDb(context, reservationDbContext, loadTimeCounter, requestTimestamp, bodyText);
        }

        /// <summary>
        /// Tries the insert log in database.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="nfaDbContext">The nfa database context.</param>
        /// <param name="loadTimeCounter">The load time counter.</param>
        /// <param name="requestTimestamp">The request timestamp.</param>
        /// <param name="bodyText">The body text.</param>
        private void TryInsertLogInDb(HttpContext context, IReservationDbContext reservationDbContext, Stopwatch loadTimeCounter, DateTime requestTimestamp, string bodyText)
        {
            try
            {
                var log = new RequestLogEntity(context.Request.Method,
                                                      $"{context.Request.Scheme}//{context.Request.Host}{context.Request.Path}{context.Request.QueryString}",
                                                      context.Connection.RemoteIpAddress.ToString(),
                                                      context.Connection.RemotePort.ToString(),
                                                      loadTimeCounter.ElapsedMilliseconds,
                                                      requestTimestamp,
                                                      bodyText);

                reservationDbContext.RequestLogs.InsertOne(log);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while save log in DB", ex);
            }
        }

        /// <summary>
        /// Gets the request body asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private async Task<string> GetRequestBodyAsync(HttpRequest request)
        {
            request.EnableBuffering();

            var bodyAsText = await new StreamReader(request.Body).ReadToEndAsync();

            request.Body.Position = 0;

            return bodyAsText;
        }
    }
}

