using System.Text;

namespace Cryptopals.Set1;

public class RepeatingKeyXor
{
    private const string KEY = "ICE";

    public static byte[] Run(string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);

        return Run(inputBytes, KEY);
    }

    public static byte[] Run(byte[] inputBytes, string key)
    {
        var output = new byte[inputBytes.Length];
        var keyBytes = Encoding.ASCII.GetBytes(key);

        for (int j = 0; j < inputBytes.Length; j++)
            output[j] = (byte) (inputBytes[j] ^ keyBytes[j % key.Length]);

        return output;
    }
}