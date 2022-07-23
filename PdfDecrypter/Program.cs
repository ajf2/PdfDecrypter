string inputFilePath = "";

var argsAreValid = ReadInputFilePath(args);
if (!argsAreValid) PrintUsage();
else
{
    var parameters = new PdfDecrypter.Parameters(inputFilePath);
    var fileIsEncrypted = await PdfDecrypter.PdfDecrypter.CheckIsEncryptedAsync(parameters);
    if (fileIsEncrypted) {
        Console.Write("File is encrypted, enter password:");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        while (keyInfo.Key != ConsoleKey.Enter)
        {
            parameters.Password += keyInfo.KeyChar;
            keyInfo = Console.ReadKey(true);
        }

        await PdfDecrypter.PdfDecrypter.DecryptAsync(parameters);
    }
}

bool ReadInputFilePath(string[] args)
{
    if (!args.Any()) return false;
    if (!File.Exists(args[0])) return false;
    inputFilePath = args[0];
    return true;
}

void PrintUsage() => Console.WriteLine($"Usage:{Environment.NewLine}PdfDecrypter <path-to-encrypted-pdf>");
