namespace PdfDecrypter.PdfDecrypters
{
    public interface IPdfDecrypter
    {
        public Task<bool> CheckIsEncryptedAsync(Parameters parameters);
        public Task DecryptAsync(Parameters parameters);
    }
}
