using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDecrypter.PdfDecrypters
{
    public class FreeSpirePdfDecrypter : IPdfDecrypter
    {
        public Task DecryptAsync(Parameters parameters)
        {
            return Task.Run(() =>
            {
                var pdfFile = new PdfDocument();
                pdfFile.LoadFromFile(parameters.InputFilePath, parameters.Password);
                pdfFile.Security.DecryptOwnerPassWord(parameters.Password);
                // pdfFile.DocumentInformation.Title becomes corrupted.
                pdfFile.SaveToFile(parameters.OutputFilePath);
            });
        }
    }
}
