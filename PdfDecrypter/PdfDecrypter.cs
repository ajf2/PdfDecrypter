using PdfDecrypter.PdfDecrypters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfDecrypter
{
    public static class PdfDecrypter
    {
        public static async Task<bool> CheckIsEncryptedAsync(Parameters parameters)
        {
            try
            {
                return await new ITextPdfDecrypter().CheckIsEncryptedAsync(parameters);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static async Task DecryptAsync(Parameters parameters) {
            try
            {
                await new ITextPdfDecrypter().DecryptAsync(parameters);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Parameters
    {
        public bool AreValid { get; set; }
        public string InputFilePath { get; set; } = "";
        public string OutputFilePath => InputFilePath.Replace(".pdf", ".dec.pdf");
        public string Password { get; set; } = "";

        public Parameters(string inputFilePath)
        {
            if (!inputFilePath.ToLower().EndsWith(".pdf")) return;
            if (!File.Exists(inputFilePath)) return;

            InputFilePath = inputFilePath.Trim();
        }

        public Parameters(string inputFilePath, string password, string? outputFilePath = null)
        {
            if (!inputFilePath.ToLower().EndsWith(".pdf")) return;
            if (!File.Exists(inputFilePath)) return;
            if (string.IsNullOrEmpty(password)) return;
            if (!string.IsNullOrEmpty(outputFilePath) && !File.Exists(outputFilePath)) return;

            InputFilePath = inputFilePath.Trim();
            Password = password;
            //OutputFilePath = string.IsNullOrEmpty(outputFilePath) ? inputFilePath.Replace(".pdf", ".dec.pdf") : outputFilePath;
        }
    }
}
