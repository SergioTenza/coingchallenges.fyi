using System.Text.Json;
using JsonParser;

try
{
    if (args.Length > 0 && args.Length == 1)
    {
        var jsonParserer = new JsonParserer();
        var content = await jsonParserer.ProcessFile(args[0]);
        if(content != 0)
        {
            Console.WriteLine("Ha ocurrido un error al procesar el archivo");
            Environment.Exit(content);
        }
        Console.WriteLine("Json parseado correctamente");
        Environment.Exit(content);
    }   
    else if(args.Length > 1)
    {
        Console.WriteLine("Solo se admite un archivo por peticion.");
        Environment.Exit(1);
    } 
    else
    {
        Console.WriteLine("No se ha suministrado ningun archivo valido.");
        Environment.Exit(1);
    }
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
    Environment.Exit(1);
}

