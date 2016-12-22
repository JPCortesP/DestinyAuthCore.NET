using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DestinyAuth.Controllers
{
    public class Auth : Controller
    {
        private Bungie.BungieAppConfig BungieConfig;
        public Auth(IOptions<Bungie.BungieAppConfig> options)
        {
            this.BungieConfig = options.Value;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return Redirect(BungieConfig.AuthURL);
        }
        public IActionResult getResult(string code = "")
        {
            
            throw new NotImplementedException();
        }
    }
}
