using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitiReservation.Core.Models.Auth;
using UnitiReservation.Core.Models.Users;
using UnitiReservation.Core.Services.Users;

namespace UnitiReservation.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate(UserAuthForm auth)
        {
            if (ModelState.IsValid)
            {
                var token = await _userService.Authenticate(auth);

                if (token == null)
                {
                    return Unauthorized();
                }

                return Ok(token);
            }

            return BadRequest(ModelState);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateAccount(UserCreationForm user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.CreateAccount(user);

                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest(ModelState);
        }
    }
}
