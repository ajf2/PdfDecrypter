using iText.Kernel.Exceptions;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDecrypter.PdfDecrypters
{
    public class ITextPdfDecrypter : IPdfDecrypter
    {
        public Task<bool> CheckIsEncryptedAsync(Parameters parameters) => Task.Run(() =>
        {
            try
            {
                var pdfFile = new PdfDocument(new PdfReader(parameters.InputFilePath));
            } catch (BadPasswordException)
            {
                return true;
            }
            return false;
        });

        public Task DecryptAsync(Parameters parameters) => Task.Run(() =>
        {
            var pdfFile = new PdfDocument(
                new PdfReader(parameters.InputFilePath, new ReaderProperties().SetPassword(Encoding.UTF8.GetBytes(parameters.Password))),
                new PdfWriter(parameters.OutputFilePath)
            );
            pdfFile.Close();
        });
    }
}
