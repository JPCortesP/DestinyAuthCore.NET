using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DestinyAuth.Bungie
{
    /// <summary>
    /// Simple class that provides with AccessTokens and stuffs like that, that could be serialized 
    /// to be hold in the session. Please, use something else. Everything is public 'cause I'm lazy AF
    /// and I'll be using JSON.NET to serialize. Again, DON'T DO THIS IN PRODUCTION.
    /// </summary>
    public class AuthLogic 
    {
        public string apikey { get; set; } = "";
        public string AuthURL { get; set; } = "";
        /// <summary>
        /// You might want to check this out.
        /// </summary>
        public int DesiredScope { get; set; } = 1;
        private SecureStuff UserDetailsBungoGaveMe { get; set; }
        /// <summary>
        /// If initialized correctly, this dude will reply with everything you need. And throw
        /// exceptions like Taniks throws cannons if not, included, but not limited to, go and ask
        /// for the user to redirect somewhere only we (and bungo) knows. The flow can also
        /// be invoked somewhere else, I don't know where yet tho.
        /// </summary>
        /// <returns></returns>
        public HttpClient getClientWithAllTheStuffAndGallyHornIncluded()
        {
            throw new NotImplementedException();
        }
        private bool refreshToken ()
        {
            throw new NotImplementedException();
        }

    }
    /// <summary>
    /// A simple class to hold everything bungie gave us, including keeping track of the expiration
    /// of the AccessToken. Since the Refresh token lives for a year (if used before 90 days), 
    /// I won't care about its expiration.
    /// </summary>
    public class SecureStuff
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int Score { get; set; }
        private DateTime accessTokenRefresh { get; set; }
        public bool AccessTokenNeedsRefresh
        {
            get
            {
                return false;
            }
        }
    }
}
