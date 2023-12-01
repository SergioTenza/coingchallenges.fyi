using JsonParser;

namespace cc02_tets;

public class ValidJson
{
    [Fact]
    public async Task ShouldReturnCodeZeroOnGoodJson()
    {
        //given        
        var path = $"""{Directory.GetCurrentDirectory()}\tests\step1\valid.json""";
        var jsonParser = new JsonParserer();

        //when        
        var processContent = await jsonParser.ProcessFile(path);

        //then 
        Assert.True(processContent == 0);
    }

     [Fact]
    public async Task ShouldReturnCodeZeroOnGoodJsonOnePairKeyValue()
    {
        //given        
        var path = $"""{Directory.GetCurrentDirectory()}\tests\step2\valid.json""";
        var jsonParser = new JsonParserer();

        //when        
        var processContent = await jsonParser.ProcessFile(path);

        //then 
        Assert.True(processContent == 0);
    }

     [Fact]
    public async Task ShouldReturnCodeZeroOnGoodJsonTwoPairsKeyValue()
    {
        //given        
        var path = $"""{Directory.GetCurrentDirectory()}\tests\step2\valid2.json""";
        var jsonParser = new JsonParserer();

        //when        
        var processContent = await jsonParser.ProcessFile(path);

        //then 
        Assert.True(processContent == 0);
    }
}