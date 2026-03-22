using System.IO;

namespace BPMS.Infrastructure.Helpers
{
    public static class PdfHelper
    {
        public static void SaveToFile(byte[] data, string path)
        {
            File.WriteAllBytes(path, data);
        }

        public static byte[] LoadFromFile(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
