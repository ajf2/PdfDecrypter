using PdfDecrypter;

string inputFilePath = "";

var argsAreValid = ReadInputFilePath(args);
if (!argsAreValid) PrintUsage();
else {
  var parameters = new Parameters(inputFilePath);
  await PdfDecrypter.PdfDecrypter.BruteForcePassword(parameters, new BruteForcePasswordIterator());
}

bool ReadInputFilePath(string[] args)
{
    if (!args.Any()) return false;
    if (!File.Exists(args[0])) return false;
    inputFilePath = args[0];
    return true;
}

void PrintUsage() => Console.WriteLine($"Usage:{Environment.NewLine}PdfDecrypter <path-to-encrypted-pdf>");
