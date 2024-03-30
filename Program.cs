using System.IO;

namespace Anarchy_Online_SDW_Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryReader br = new(File.OpenRead(args[0]));

            int[] ends = new int[6];
            for (int i = 0; i < 6; i++)
                ends[i] = br.ReadInt32();

            Directory.CreateDirectory(Path.GetDirectoryName(args[0]) + "//" + Path.GetFileNameWithoutExtension(args[0]));
            int n = 0;
            foreach (int end in ends)
            {
                BinaryWriter bw = new(File.Create(Path.GetDirectoryName(args[0]) + "//" + Path.GetFileNameWithoutExtension(args[0]) + "//" + n + ".png"));
                bw.Write(br.ReadBytes(end - (int)br.BaseStream.Position));
                bw.Close();
                n++;
            }
        }
    }
}
