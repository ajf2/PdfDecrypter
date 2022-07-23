using PdfSharpCore.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDecrypter.PdfDecrypters
{
    public class PdfSharpDecrypter : IPdfDecrypter
    {
        public Task DecryptAsync(Parameters parameters)
        {
            // Fails to decrypt.
            var pdfFile = PdfReader.Open(parameters.InputFilePath, parameters.Password, PdfDocumentOpenMode.ReadOnly);
            return Task.Run(() => pdfFile.Save(parameters.OutputFilePath));
        }
    }
}
