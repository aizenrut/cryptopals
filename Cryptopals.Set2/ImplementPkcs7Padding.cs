namespace Cryptopals.Set2;

public class ImplementPkcs7Padding
{
    public static string Run(string text, int lenght)
    {
        var remaining = lenght - text.Length;
        var padding = Convert.ToHexString(new []{(byte) remaining});

        for (int i = 0; i < remaining; i++)
        {
            text += padding;
        }
        
        return text;
    }
}