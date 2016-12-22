using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DestinyAuth.Controllers
{
    public class PlayerController : Controller
    {
        private string url = "http://www.bungie.net/Platform/User/GetCurrentBungieAccount/";
        private Bungie.BungieAppConfig BungieConfig;
        public PlayerController(IOptions<Bungie.BungieAppConfig> options)
        {
            this.BungieConfig = options.Value;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            if (!HttpContext.Session.Keys.Contains("token"))
            {
                return RedirectToAction("Index", new { controller = "Home" });
            }
            var jtoken = HttpContext.Session.GetString("token");
            var Token = Newtonsoft.Json.JsonConvert.DeserializeObject<Bungie.Tokens>(jtoken);
            using (var cl = new HttpClient())
            {
                cl.DefaultRequestHeaders.Add("x-api-key", BungieConfig.ApiKey);
                cl.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Token.AccessToken.value);
                var resultado = await cl.GetStringAsync(url);
                return new JsonResult(resultado);
            }

            
        }
    }
}
