using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorStore.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        [Route("/authenticate")]
        public IActionResult Authenticate([FromQuery] string user, [FromQuery] string pwd)
        {
            if (user == "admin" && pwd == "adminadmin")
            {
                var userClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user),
                    new Claim(ClaimTypes.Email, "admin.blazorstore.com"),
                    new Claim(ClaimTypes.HomePhone, "12345678"),
                };

                var userIdentity = new ClaimsIdentity(userClaims, WebConstants.Cookies.AuthenticationScheme);
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                HttpContext.SignInAsync(WebConstants.Cookies.AuthenticationScheme, userPrincipal);
            }

            return Redirect("/outstandingorders");
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/outstandingorders");
        }
    }
}
