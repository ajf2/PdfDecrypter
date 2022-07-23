using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = org.pdfclown.files.File;

namespace PdfDecrypter.PdfDecrypters
{
    public class PdfClownDecrypter : IPdfDecrypter
    {
        public Task DecryptAsync(Parameters parameters) => Task.Run(() =>
            {
                // Doesn't support encrypted files.
                var inputFile = new File(parameters.InputFilePath).Document;
                var outputFile = new File(parameters.OutputFilePath).Document;
                outputFile.Pages.AddAll(inputFile.Pages);
                outputFile.File.Save();
            });
    }
}
