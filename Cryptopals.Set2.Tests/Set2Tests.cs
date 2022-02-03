using Xunit;

namespace Cryptopals.Set2.Tests;

public class UnitTest1
{
    [Fact]
    public void ImplementPkcs7PaddingTest()
    {
        var result = ImplementPkcs7Padding.Run("YELLOW SUBMARINE", 20);
        
        Assert.Equal("YELLOW SUBMARINE04040404", result);
    }
}