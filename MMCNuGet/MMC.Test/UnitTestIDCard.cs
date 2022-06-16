
using MMC.Helper;

using Xunit;

namespace MMC.Test
{
    public class UnitTestIDCard
    {
        [Theory]
        [InlineData("110101199003074733")]
        [InlineData("11010119900307889X")]
        public void IsAdult(string id)
        {
            Assert.True(IDCard.IsAdult(id));
        }
    }
}
