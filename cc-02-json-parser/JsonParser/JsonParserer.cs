using System.Text.RegularExpressions;

namespace JsonParser;

public class JsonParserer
{
    public async ValueTask<int> ProcessFile(string filePath)
    {
        Validate(filePath);
        return 0;
    }

    private string Validate(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new InvalidOperationException($"No se ha podido encontrar el archivo suministrado.");
        }
        var fileInfo = new FileInfo(filePath);
        if (!fileInfo.Extension.EndsWith(".json"))
        {
            throw new InvalidOperationException($"El tipo de archivo debe ser .json el tipo de archivo {fileInfo.Extension} no esta admitido.");
        }
        var content = File.ReadAllText(fileInfo.FullName);
        if(string.IsNullOrEmpty(content))
        {
            throw new InvalidOperationException($"El contenido del archivo no puede estar vacio.");
        }
        if (!(content.StartsWith('{') && (content.EndsWith('}') || content.EndsWith("}\n"))))
        {
            throw new InvalidOperationException($"El contenido del archivo no es un json valido.");
        }
        if (content.EndsWith(",}"))
        {
            throw new InvalidOperationException($"El contenido del archivo no es un json valido. No se permiten comas residuales.");
        }
        Regex regex = new Regex(@"(?<![""]|[{][""])\b\w+\b(?=[""]?:)");

        MatchCollection matches = regex.Matches(content);
        if (matches.Count > 0)
        {
            throw new InvalidOperationException($"El contenido del archivo no es un json valido. No se permiten Keys sin envolver en comas dobles.");
        }        
        return content;
    }
}
