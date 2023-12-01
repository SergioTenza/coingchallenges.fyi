using JsonParser;

namespace cc02_tets;

public class InvalidJson

{
    [Fact]
    public async Task ShouldReturnInvalidOperationExceptionOnEmptyJson()
    {
        //given        
        var path = $"""{Directory.GetCurrentDirectory()}\tests\step1\empty.json""";
        var jsonParser = new JsonParserer();
        var expectedMessage = "El contenido del archivo no puede estar vacio.";
        //when        
        var processContent = await Assert.ThrowsAsync<InvalidOperationException>(async ()=>await jsonParser.ProcessFile(path));
        

        //then 
        Assert.True(expectedMessage.Equals(processContent.Message));
        
    }
    [Fact]
    public async Task ShouldReturnInvalidOperationExceptionOnBadJson()
    {
        //given        
        var path = $"""{Directory.GetCurrentDirectory()}\tests\step1\invalid.json""";
        var jsonParser = new JsonParserer();
        var expectedMessage = "El contenido del archivo no es un json valido.";

        //when        
        var processContent = await Assert.ThrowsAsync<InvalidOperationException>(async ()=>await jsonParser.ProcessFile(path));
        

        //then 
        Assert.True(expectedMessage.Equals(processContent.Message));
    }

    [Fact]
    public async Task ShouldReturnInvalidOperationExceptionOnBadTrailingComma()
    {
        //given        
        var path = $"""{Directory.GetCurrentDirectory()}\tests\step2\invalid.json""";
        var jsonParser = new JsonParserer();
        var expectedMessage = "El contenido del archivo no es un json valido. No se permiten comas residuales.";

        //when        
        var processContent = await Assert.ThrowsAsync<InvalidOperationException>(async ()=>await jsonParser.ProcessFile(path));
        

        //then 
        Assert.True(expectedMessage.Equals(processContent.Message));
    }

     [Fact]
    public async Task ShouldReturnInvalidOperationExceptionOnUnescappedKeys()
    {
        //given        
        var path = $"""{Directory.GetCurrentDirectory()}\tests\step2\invalid2.json""";
        var jsonParser = new JsonParserer();
        var expectedMessage = "El contenido del archivo no es un json valido. No se permiten Keys sin envolver en comas dobles.";

        //when        
        var processContent = await Assert.ThrowsAsync<InvalidOperationException>(async ()=>await jsonParser.ProcessFile(path));
        

        //then 
        Assert.True(expectedMessage.Equals(processContent.Message));
    }

    [Fact]
    public async Task ShouldReturnInvalidOperationExceptionOnBadFileType()
    {
        //given        
        var path = $"""{Directory.GetCurrentDirectory()}\tests\step1\bad.txt""";
        var jsonParser = new JsonParserer();
        var expectedMessage = "El tipo de archivo debe ser .json el tipo de archivo .txt no esta admitido.";
        //when        
        var processContent = await Assert.ThrowsAsync<InvalidOperationException>(async ()=>await jsonParser.ProcessFile(path));
        

        //then 
        Assert.True(expectedMessage.Equals(processContent.Message));
    }

    [Fact]
    public async Task ShouldReturnInvalidOperationExceptionOnNotExistingFile()
    {
        //given        
        var path = $"""{Directory.GetCurrentDirectory()}\tests\step1\badpath.json""";
        var jsonParser = new JsonParserer();
        var expectedMessage = "No se ha podido encontrar el archivo suministrado.";
        //when        
        var processContent = await Assert.ThrowsAsync<InvalidOperationException>(async ()=>await jsonParser.ProcessFile(path));
        

        //then 
        Assert.True(expectedMessage.Equals(processContent.Message));
    }
}