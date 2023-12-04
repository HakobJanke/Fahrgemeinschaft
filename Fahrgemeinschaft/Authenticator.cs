using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;

namespace Fahrgemeinschaft
{
    public class Authenticator
    {
        private readonly IUserStore userStore;
        private readonly IHttpContextAccessor httpContextAccessor;

        private HttpContext HttpContext => httpContextAccessor.HttpContext ?? throw new Exception("Can't get HttpContext from IHttpContextAccessor");

        public Authenticator(IUserStore userStore, IHttpContextAccessor httpContextAccessor)
        {
            this.userStore = userStore;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Login(string username, string password)
        {
            if (userStore.TryLoginUser(username, password) is string[] roles)
            {
                var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));
                var allClaims = new[] { new Claim(ClaimTypes.Name, username) }.Concat(roleClaims).ToArray();
                var identity = new ClaimsIdentity(allClaims, "HTMLForm");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                return true;
            }
            return false;
        }

        public string? TryGetLoggedInUser()
        {
            DecryptAuthenticationCookie();
            return HttpContext.User.Identity?.Name;
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync();
        }

        [Conditional("DEBUG")]
        public void DecryptAuthenticationCookie()
        {
            // see https://stackoverflow.com/a/69047119/1293659

            var opt = HttpContext.RequestServices
                .GetRequiredService<IOptionsMonitor<CookieAuthenticationOptions>>()
                .Get(CookieAuthenticationDefaults.AuthenticationScheme);

            var cookie = opt.CookieManager.GetRequestCookie(HttpContext, opt.Cookie.Name!);

            var ticket = opt.TicketDataFormat.Unprotect(cookie);
            if (ticket == null)
            {
                return;
            }
            var ticketBytes = TicketSerializer.Default.Serialize(ticket);
            var ticketString = Encoding.UTF8.GetString(ticketBytes);
        }
    }

}
