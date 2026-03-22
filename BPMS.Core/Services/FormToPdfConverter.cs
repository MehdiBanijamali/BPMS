using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BPMS.Core.Services
{
    public class FormToPdfConverter : IPdfConverter
    {
        public byte[] ConvertFormToPdf(Form form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            using (var bitmap = CaptureForm(form))
            {
                return ConvertToPdf(bitmap);
            }
        }

        private Bitmap CaptureForm(Form form)
        {
            var bitmap = new Bitmap(form.Width, form.Height);
            form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.Width, form.Height));
            return bitmap;
        }

        private byte[] ConvertToPdf(Bitmap bitmap)
        {
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public void SavePdf(byte[] pdfBytes, string filePath)
        {
            if (pdfBytes == null || pdfBytes.Length == 0)
                throw new ArgumentException("PDF data is empty.");

            File.WriteAllBytes(filePath, pdfBytes);
        }
    }
}
