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
        
        Assert.Equal("SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t", base64, ignoreCase: true);
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
        
        var (message, xoredByte) = SingleByteXor.Run(hex);
        
        Assert.Equal("Cooking MC's like a pound of bacon", message, ignoreCase: true);
        Assert.Equal('X', xoredByte);
    }
}