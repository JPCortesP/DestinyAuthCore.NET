using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft;

namespace DestinyAuth.Bungie
{
    public class Tokens
    {
        public BungieTokenBase AccessToken { get; set; }
        public BungieTokenBase RefreshToken { get; set; }
        public int Scope { get; set; }
        public DateTime Creation { get; set; }

        /// <summary>
        /// Just checks if the AccessToken is Valid
        /// </summary>
        

        public Tokens() { AccessToken = new BungieTokenBase(); RefreshToken = new BungieTokenBase(); } 
        public Tokens(String bungieResponse)
        {
            Creation = DateTime.Now;
            AccessToken = new BungieTokenBase();
            RefreshToken = new BungieTokenBase();
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(bungieResponse).Response;
            this.Scope = response.scope;
            
            this.AccessToken.value = response.accessToken.value;
            this.AccessToken.ReadyIn = response.accessToken.readyin;
            this.AccessToken.Expiration = response.accessToken.expires;

            
            this.RefreshToken.value = response.refreshToken.value;
            this.RefreshToken.ReadyIn = response.refreshToken.readyin;
            this.RefreshToken.Expiration = response.refreshToken.expires;


        }

        /// <summary>
        /// Clever, Clever Creature... I'm not sure it works tho.
        /// Returns True if the AccessToken is valid. If not, you can probably just refresh the thing.
        /// </summary>
        public bool Valid
        {
            get
            {
                return (DateTime.Now - Creation).TotalSeconds < AccessToken.Expiration;
            }
        }
        /// <summary>
        /// True if: (1) the AccessToken is no longer valid, AND (2) the RefreshToken can now be used, AND 
        /// (3) the RefreshToken is still valid. 3 Ifs, not pretty, but what can we do?
        /// </summary>
        public bool CanRefresh
        {
            get
            {
                if (!Valid 
                    && (DateTime.Now - Creation).TotalSeconds > RefreshToken.ReadyIn 
                    && (DateTime.Now-Creation).TotalSeconds < RefreshToken.Expiration)
                {
                    return true;
                }
                return false;

            }
        }

        public override bool Equals(object obj)
        {
            var algo = obj as Tokens;
            if (algo == null)
            {
                return false;
            }
            return algo.AccessToken.value.Equals(this.AccessToken.value) &&
                algo.AccessToken.Expiration.Equals(this.AccessToken.Expiration) &&
                algo.RefreshToken.value.Equals(this.RefreshToken.value) &&
                algo.RefreshToken.Expiration.Equals(this.RefreshToken.Expiration) &&
                algo.Scope == this.Scope;
        }
        public override int GetHashCode()
        {
            return AccessToken.value.GetHashCode();
        }
    }

    public class BungieTokenBase
    {
        
        public string value { get; set; }
        public int ReadyIn { get; set; }
        public int Expiration { get; set; }
        
    }

    #region JsonObjects
    public class AccessToken
    {
        public string value { get; set; }
        public int readyin { get; set; }
        public int expires { get; set; }
    }

    public class RefreshToken
    {
        public string value { get; set; }
        public int readyin { get; set; }
        public int expires { get; set; }
    }

    public class Response
    {
        public AccessToken accessToken { get; set; }
        public RefreshToken refreshToken { get; set; }
        public int scope { get; set; }
    }

    public class MessageData
    {
    }

    public class RootObject
    {
        public Response Response { get; set; }
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public MessageData MessageData { get; set; }
    }
    #endregion
}
