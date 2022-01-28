namespace Cryptopals.Set1;

public class SingleCharacterXor
{
    public static (string Line, char XoredByte, string Message) Run()
    {
        var winners = new List<(string Line, char XoredByte, double Score, string Message)>();
        
        using (var reader = File.OpenText("4.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var (xoredByte, score, message) = SingleByteXor.Run(line);
                winners.Add((line, xoredByte, score, message));
            }
        }
        
        var winner = winners.MaxBy(x => x.Score);

        return (winner.Line, winner.XoredByte, winner.Message);
    }
}