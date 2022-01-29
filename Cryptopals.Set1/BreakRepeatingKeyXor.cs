using System.Text;

namespace Cryptopals.Set1;

public class BreakRepeatingKeyXor
{
    public static byte[] Run()
    {
        var base64 = File.ReadAllText("Data/6.txt");
        var bytes = Convert.FromBase64String(base64);

        var keySizeEdits = GetBestKeySizeEdits(bytes);

        var results = new byte[keySizeEdits.Length][];
        
        for (int i = 0; i < keySizeEdits.Length; i++)
        {
            var keySize = keySizeEdits[i];

            var blocks = BreakIntoNBlocks(bytes, keySize);
            var transposedBlocks = Transpose(blocks, keySize);
            var repeatingKey = GetRepeatingKey(transposedBlocks, keySize);

            var result = RepeatingKeyXor.Run(bytes, repeatingKey);
            
            results[i] = result;
        }

        return GetBestEnglishResult(results);
    }

    private static byte[] GetBestEnglishResult(byte[][] results)
    {
        return results
            .Select(x => new
            {
                Bytes = x,
                Score = Shared.Score(x)
            })
            .MaxBy(x => x.Score)
            .Bytes;
    }

    private static int[] GetBestKeySizeEdits(byte [] bytes)
    {
        var keySizeEdits = new (int KeySize, double Distance)[39];
        
        for (int i = 2; i <= 40; i++)
        {
            var third = new byte[i];
            for (int k = 0; k < i; k++)
                third[k] = bytes[k + i * 2];

            var fourth = new byte[i];
            for (int k = 0; k < i; k++)
                fourth[k] = bytes[k + i * 3];

            var edit = HammingDistance(third, fourth) / (double) i;
            
            keySizeEdits[i - 2] = (i, edit);
        }
        
        return keySizeEdits
            .OrderBy(x => x.Distance)
            .Take(5)
            .Select(x => x.KeySize)
            .ToArray();
    }
    
    private static int HammingDistance(byte[] a, byte[] b)
    {
        var count = 0;

        for (int i = 0; i < a.Length; i++)
        {
            var xor = a[i] ^ b[i];

            while (xor != 0)
            {
                xor &= xor - 1;
                count++;
            }
        }

        return count;
    }

    private static byte[][] BreakIntoNBlocks(byte[] bytes, int n)
    {
        var blocksCount = bytes.Length / n;
        var blocks = new byte[blocksCount][];

        for (int j = 0; j < blocksCount; j++)
        {
            blocks[j] = bytes.Skip(n * j).Take(n).ToArray();
        }

        return blocks;
    }

    private static byte[][] Transpose(byte[][] blocks, int keySize)
    {
        var blocksCount = blocks.Length;
        
        var transposedBlocks = new byte[keySize][];

        for (int j = 0; j < keySize; j++)
        {
            var block = new byte[blocksCount];

            for (int k = 0; k < blocksCount; k++)
                block[k] = blocks[k][j];

            transposedBlocks[j] = block;
        }

        return transposedBlocks;
    }

    private static string GetRepeatingKey(byte[][] transposedBlocks, int keySize)
    {
        var repeatingKey = new StringBuilder();

        for (int j = 0; j < keySize; j++)
        {
            var (key, _, _) = SingleByteXor.Run(transposedBlocks[j]);
            repeatingKey.Append(key);
        }

        return repeatingKey.ToString();
    }
}