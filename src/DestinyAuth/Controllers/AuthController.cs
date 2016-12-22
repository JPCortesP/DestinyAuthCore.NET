using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Microsoft.AspNetCore.Http;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DestinyAuth.Controllers
{
    public class AuthController : Controller
    {
        private Bungie.BungieAppConfig BungieConfig;
        public AuthController(IOptions<Bungie.BungieAppConfig> options)
        {
            this.BungieConfig = options.Value;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return Redirect(BungieConfig.AuthURL);
        }
        public IActionResult Error()
        {
            return View();
        }
        public async Task<IActionResult> getResult(string code = "")
        {
            using (var client = new HttpClient())
            {
                var codeObject = new 
                {
                    code = code
                };
                client.DefaultRequestHeaders.Add("x-api-key", BungieConfig.ApiKey);
                var res = await client.PostAsync("https://www.bungie.net/Platform/App/GetAccessTokensFromCode/"
                    , new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(codeObject)));
                if(!res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Error");
                }
                var responseJson = await res.Content.ReadAsStringAsync();
                var Tokens = new Bungie.Tokens(responseJson);

                


            }
            throw new NotImplementedException();
        }
    }
}
