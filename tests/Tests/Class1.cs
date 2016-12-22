using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Class1
    {

        [Fact]
        public void ThisIsHowYouMakeATest()
        {
            Assert.Equal(4, Add(2, 2));
        }
        //https://xunit.github.io/docs/getting-started-dotnet-core.html

        int Add(int x, int y)
        {
            return x + y;
        }
    }


}
