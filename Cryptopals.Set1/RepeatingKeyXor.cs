using System.Text;

namespace Cryptopals.Set1;

public class RepeatingKeyXor
{
    private const string KEY = "ICE";

    public static byte[] Run(string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var output = new byte[inputBytes.Length];
        var keyBytes = Encoding.ASCII.GetBytes(KEY);
        var keyIndex = 0;

        for (int j = 0; j < inputBytes.Length; j++)
        {
            output[j] = (byte) (inputBytes[j] ^ keyBytes[keyIndex]);

            keyIndex = (keyIndex + 1) % KEY.Length;
        }

        return output;
    }
}