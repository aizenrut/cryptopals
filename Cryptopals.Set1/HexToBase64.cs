namespace Cryptopals.Set1;

public static class HexToBase64
{
    public static string Run(string hex)
    {
        var bytes = Convert.FromHexString(hex);
        var base64 = Convert.ToBase64String(bytes);

        return base64;
    }
}