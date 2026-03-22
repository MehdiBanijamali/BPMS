using System.Windows.Forms;

namespace BPMS.Core.Services
{
    public interface IPdfConverter
    {
        byte[] ConvertFormToPdf(Form form);
        void SavePdf(byte[] pdfBytes, string filePath);
    }
}
