namespace Cryptopals.Set1;

public class DetectAesInEcbMode
{
    private const int BLOCK_SIZE = 16;
    
    public static int? Run()
    {
        using (var sr = File.OpenText("Data/8.txt"))
        {
            var line = 1;
            string hex;
            
            while ((hex = sr.ReadLine()) != null)
            {
                var bytes = Convert.FromHexString(hex);
                var blocksCount = bytes.Length / BLOCK_SIZE;
                var blocks = new byte[blocksCount][];
                
                for (int i = 0; i < blocksCount; i++)
                {
                    var block = new byte[BLOCK_SIZE];
                    
                    for (int j = 0; j < BLOCK_SIZE; j++)
                        block[j] = bytes[j + i * BLOCK_SIZE];

                    blocks[i] = block;
                }

                for (int current = 0; current < blocksCount; current++)
                {
                    for (int compare = current + 1; compare < blocksCount; compare++)
                    {
                        var duplicated = true;
                        
                        for (int i = 0; i < BLOCK_SIZE; i++)
                            duplicated &= blocks[current][i] == blocks[compare][i];

                        if (duplicated)
                            return line;
                    }
                }

                line++;
            }
        }
        
        return null;
    }
}