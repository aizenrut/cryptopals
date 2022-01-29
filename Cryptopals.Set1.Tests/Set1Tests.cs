using System;
using Xunit;

namespace Cryptopals.Set1.Tests;

public class Set1Tests
{
    [Fact]
    public void HexToBase64Test()
    {
        var hex = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
        
        var base64 = HexToBase64.Run(hex);
        
        Assert.Equal("SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t", base64);
    }

    [Fact]
    public void FixedXorTest()
    {
        var hex = "1c0111001f010100061a024b53535009181c";
        var anotherHex = "686974207468652062756c6c277320657965";

        var bytes = FixedXor.Run(hex, anotherHex);
        
        Assert.Equal("746865206b696420646f6e277420706c6179", Convert.ToHexString(bytes), ignoreCase: true);
    }
    
    [Fact]
    public void SingleByteXorTest()
    {
        var hex = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";
        
        var (xoredByte, _, message) = SingleByteXor.Run(hex);
        
        Assert.Equal("Cooking MC's like a pound of bacon", message);
        Assert.Equal('X', xoredByte);
    }
    
    [Fact]
    public void SingleCharacterXorTest()
    {
        var (line, xoredByte, message) = SingleCharacterXor.Run();

        Assert.Equal("7b5a4215415d544115415d5015455447414c155c46155f4058455c5b523f", line);
        Assert.Equal('5', xoredByte);
        Assert.Equal("Now that the party is jumping\n", message);
    }

    [Fact]
    public void RepeatingKeyXorTest()
    {
        var input = "Burning 'em, if you ain't quick and nimble\n" +
                    "I go crazy when I hear a cymbal";
        
        var expectedOutput = "0b3637272a2b2e63622c2e69692a23693a2a3c6324202d623d63343c2a26226324272765272" +
                             "a282b2f20430a652e2c652a3124333a653e2b2027630c692b20283165286326302e27282f";
        
        var output = RepeatingKeyXor.Run(input);

        Assert.Equal(expectedOutput, Convert.ToHexString(output), ignoreCase: true);
    }
}