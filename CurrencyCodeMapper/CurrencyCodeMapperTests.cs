using Xunit;

namespace CurrencyCodeMapper;

public class CurrencyCodeMapperTests
{
    private CurrencyCodeMapper currencyCodeMapper;

    public CurrencyCodeMapperTests()
    {
        currencyCodeMapper = new CurrencyCodeMapper();
    }

    [Theory]
    [InlineData("AUD", "$")]
    [InlineData("CAD", "$")]
    [InlineData("GBP", "£")]
    [InlineData("EUR", "€")]
    [InlineData("USD", "$")]
    [InlineData("BRL", "R$")]
    [InlineData("DKK", "kr.")]
    [InlineData("SEK", "kr")]
    [InlineData("NOK", "kr")]
    [InlineData("JPY", "¥")]
    [InlineData("CNY", "¥")]
    [InlineData("PLN", "zł")]
    [InlineData("RUB", "₽")]
    public void GetSymbol_ShouldReturnExpectedSymbol_ForSpecifiedLanguage(string currencyCode, string expectedSymbol)
    {
        var result = currencyCodeMapper.GetSymbol(currencyCode);
        Assert.Equal(expectedSymbol, result);
    }
}