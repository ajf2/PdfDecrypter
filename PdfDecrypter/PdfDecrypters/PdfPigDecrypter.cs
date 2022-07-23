using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;

namespace PdfDecrypter.PdfDecrypters
{
    public class PdfPigDecrypter : IPdfDecrypter
    {
        public Task DecryptAsync(Parameters parameters)
        {
            var pdfFile = PdfDocument.Open(parameters.InputFilePath, new ParsingOptions { Password = parameters.Password });
            return Task.Run(() => { /* Can't save with this library. */ });
        }
    }
}
