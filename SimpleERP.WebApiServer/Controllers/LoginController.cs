using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WinformStudy.Server.Models;

namespace SimpleERP.WebApiServer.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        public LoginController()
        {
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Dictionary<string, string> input)
        {
            var user_id = input["user_id"];
            var user_pw = input["user_pw"];

            if (User.Identity != null && User.Identity.IsAuthenticated == true)
            {
                return BadRequest("이미 로그인된 사용자 입니다");
            }

            try
            {
                var login = await MLogin.GetLogin(user_id, user_pw);

                if (login == null) //로그인 오류
                    return BadRequest("아이디 또는 비밀번호가 틀렸습니다");

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, login.USER_ID));
                identity.AddClaim(new Claim(ClaimTypes.Name, login.USER_SEQ.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Role, login.ROLES.IsNull("")));

                //1분마다 확인
                identity.AddClaim(new Claim("NextCheckTime", DateTime.Now.AddMinutes(1).ToString("yyyyMMddHHmmss"), typeof(DateTime).ToString()));

                //identity.AddClaim(new Claim("LOGIN_JSON", JsonConvert.SerializeObject(login)));

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    IsPersistent = false, //로그인 쿠키 영속성 (브라우저 종료시 유지) 여부
                    ExpiresUtc = DateTime.UtcNow.AddDays(1), //1일간 미접속시 쿠키 만료
                    AllowRefresh = true, //갱신여부
                });

                return Json(login);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }
    }
}
