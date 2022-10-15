using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures;

namespace UnitiReservation.Core.Services.ActionsFilters
{
    public class IsValidApiTokenService : IAsyncActionFilter
    {
        private readonly IReservationDbContext _context;
        private readonly IConfiguration _configuration;

        public IsValidApiTokenService(IReservationDbContext webPortalDbContext, IConfiguration configuration)
        {
            _context = webPortalDbContext;
            _configuration = configuration;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.TryGetValue("apiKey", out object? apiKeyFound) && apiKeyFound is string apiKey)
            {

                if ((await _context.UserApiKeys.FindAsync(x => x.ApiKey == apiKey)).Any())
                {
                    await next();
                    return;
                }
                context.Result = RedirectTo403Forbidden();
            }
            else
            {
                context.Result = RedirectTo403Forbidden();
            }
        }

        private RedirectToActionResult RedirectTo403Forbidden()
        {
            return new RedirectToActionResult("Error", "Home", new { errorMsg = "Error - 403 Forbidden" });
        }
    }
}
