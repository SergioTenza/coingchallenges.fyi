Func<string, int> FindAllWordsOnString = (str) =>
{
    var words = str.Split(' ').Length;
    return words;
};

Func<string, string, string> GetOutput = (param, fileName) =>
    param switch
    {
        "-c" => $"{new FileInfo(fileName).Length} {fileName}",//342190
        "-l" => $"{File.ReadAllLines(fileName).Length} {fileName}",//7145
        "-w"=> $"{FindAllWordsOnString(File.ReadAllText(fileName))} {fileName}",//58164
        "-m" => $"{File.ReadAllText(fileName).ToCharArray().Length} {fileName}",//339292
        _ => $"{File.ReadAllLines(fileName).Length} {FindAllWordsOnString(File.ReadAllText(fileName))} {new FileInfo(fileName).Length} {fileName}"
    };

if (args.Length > 0)
{
    var parameters = args.Where(a => a.Contains("-"));
    if (!parameters.Any())
    {
        Console.WriteLine(GetOutput(null, args.Last()));
        return;
    }

    Console.WriteLine(GetOutput(parameters.FirstOrDefault(), args.Last()));
}
else
{
    Console.WriteLine("No se han suministrado parametros.");
}


