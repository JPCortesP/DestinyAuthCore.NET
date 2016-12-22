using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class TokenTests
    {
        private string goodJson = "{'Response':{'accessToken':{'value':'CHMS5gEAIGou...szvcBJaYrjn6OTmSN9Khan7Q == ','readyin':0,'expires':3600},'refreshToken':{'value':'CHMShgIAIG....wm/MI3AOdxRXvbREXhoL797Em','readyin':1800,'expires':7776000},'scope':129},'ErrorCode':1,'ThrottleSeconds':0,'ErrorStatus':'Success','Message':'Ok','MessageData':{}}";
        [Fact]
        public void TokensObjectCreatesSuccesfully()
        {
            var res = new DestinyAuth.Bungie.Tokens(goodJson);
            Assert.NotNull(res);
            
        }

        [Fact]
        public void PropertiesWorksNow()
        {
            var res = new DestinyAuth.Bungie.Tokens(goodJson);
            Assert.True(res.Valid);
            Assert.False(res.CanRefresh);
        }
        [Fact]
        public void PropertiesWorksInTwoHours()
        {
            var res = new DestinyAuth.Bungie.Tokens(goodJson);

            res.Creation = res.Creation.AddHours(-2);

            Assert.False(res.Valid, "Token Should be not valid");
            Assert.True(res.CanRefresh, "Should be able to refresh");
        }

        [Fact]
        public void PropertiesWorksInTwoYears()
        {
            var res = new DestinyAuth.Bungie.Tokens(goodJson);
            res.Creation = res.Creation.AddYears(-2);

            Assert.False(res.Valid);
            Assert.False(res.CanRefresh);
        }
        [Fact]
        public void SerializationWorks()
        {
            var Tokens1 = new DestinyAuth.Bungie.Tokens(goodJson);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Tokens1);
            var Tokens2 = Newtonsoft.Json.JsonConvert.DeserializeObject<DestinyAuth.Bungie.Tokens>(json);

            Assert.Equal(Tokens2, Tokens1);

        }
    }
}
