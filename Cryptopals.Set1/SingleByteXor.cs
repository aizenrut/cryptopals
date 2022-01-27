using System.Text;

namespace Cryptopals.Set1;

public class SingleByteXor
{
    private static readonly string ALL_CHARACTERS =
        "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~ \t\n\r\x0b\x0c";

    private static readonly Dictionary<char, double> frequencies = new()
    {
        {'a', 0.08167}, {'b', 0.01492}, {'c', 0.02782}, {'d', 0.04253},
        {'e', 0.12702}, {'f', 0.02228}, {'g', 0.02015}, {'h', 0.06094},
        {'i', 0.06094}, {'j', 0.00153}, {'k', 0.00772}, {'l', 0.04025},
        {'m', 0.02406}, {'n', 0.06749}, {'o', 0.07507}, {'p', 0.01929},
        {'q', 0.00095}, {'r', 0.05987}, {'s', 0.06327}, {'t', 0.09056},
        {'u', 0.02758}, {'v', 0.00978}, {'w', 0.02360}, {'x', 0.00150},
        {'y', 0.01974}, {'z', 0.00074}, {' ', 0.13000}
    };
    

    public static (string Message, char XoredByte) Run(string hex)
    {
        var hexBytes = Convert.FromHexString(hex);

        var scores = new List<(char XoredByte, double Score, string Message)>();
        var message = new StringBuilder();
        
        foreach (var caractere in ALL_CHARACTERS)
        {
            double score = 0;

            foreach (var hexByte in hexBytes)
            {
                var inverseXor = Convert.ToChar(hexByte ^ caractere);
                message.Append(inverseXor);
                
                score += frequencies.TryGetValue(inverseXor, out var freq) ? freq : 0;
            }
            
            scores.Add((caractere, score, message.ToString()));
            message.Clear();
        }

        var winner = scores.MaxBy(x => x.Score);

        return (winner.Message, winner.XoredByte);
    }
}