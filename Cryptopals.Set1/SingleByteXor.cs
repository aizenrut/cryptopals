using System.Text;

namespace Cryptopals.Set1;

public class SingleByteXor
{
    private static readonly string ALL_CHARACTERS =
        "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~ \t\n\r\x0b\x0c";

    public static (char XoredByte, double Score, string Message) Run(string hex)
    {
        var hexBytes = Convert.FromHexString(hex);

        return Run(hexBytes);
    }

    public static (char XoredByte, double Score, string Message) Run(byte[] hexBytes)
    {
        var scores = new List<(char XoredByte, double Score, string Message)>();
        var message = new StringBuilder();

        for (int i = 0; i < ALL_CHARACTERS.Length; i++)
        {
            var character = ALL_CHARACTERS[i];

            for (int j = 0; j < hexBytes.Length; j++)
            {
                var inverseXor = Convert.ToChar(hexBytes[j] ^ character);
                message.Append(inverseXor);
            }

            var score = Shared.Score(message.ToString());

            scores.Add((character, score, message.ToString()));
            message.Clear();
        }

        return scores.MaxBy(x => x.Score);
    }
}