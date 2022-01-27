namespace Cryptopals.Set1;

public static class FixedXor
{
    public static byte[] Run(string hex, string anotherHex)
    {
        var bytes = Convert.FromHexString(hex);
        var anotherBytes = Convert.FromHexString(anotherHex);

        var output = new byte[bytes.Length];

        for (int i = 0; i < bytes.Length; i++)
            output[i] = (byte) (bytes[i] ^ anotherBytes[i]);

        return output;
    }
}