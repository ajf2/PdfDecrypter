using IronPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDecrypter.PdfDecrypters
{
    public class IronPdfDecrypter : IPdfDecrypter
    {
        public Task DecryptAsync(Parameters parameters) => Task.Run(() =>
        {
            var pdfFile = PdfDocument.FromFile(parameters.InputFilePath, parameters.Password);
            pdfFile.Password = null;
            // Adds a watermark.
            pdfFile.SaveAs(parameters.OutputFilePath);
        });
    }
}
