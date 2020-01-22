using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimpleERP.WebApiServer.Controllers
{
    [Authorize]
    public class BluePopeController : Controller
    {
        public async Task<IActionResult> GetUserList([FromBody]Dictionary<string, string> input)
        {
            var search = input["search"];

            var list = await MUser.GetList(search);

            return Json(list);
        }
    }
}