using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDecrypter.PdfDecrypters
{
    public class AsposePdfDecrypter : IPdfDecrypter
    {
        public Task DecryptAsync(Parameters parameters) => Task.Run(() =>
        {
            using var pdfFile = new Aspose.Pdf.Document(parameters.InputFilePath, parameters.Password);
            pdfFile.Decrypt();
            // Adds a watermark to the file.
            pdfFile.Save(parameters.OutputFilePath);
        });
    }
}
