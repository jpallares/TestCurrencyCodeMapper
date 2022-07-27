using NUnit.Framework;

namespace CurrencyCodeMapper;

[TestFixture]
public class CurrencyCodeMapperTests
{
    private CurrencyCodeMapper currencyCodeMapper;

    [SetUp]
    public void Setup()
    {
        currencyCodeMapper = new CurrencyCodeMapper();
    }

    [TestCase("AUD", "$")]
    [TestCase("CAD", "$")]
    [TestCase("GBP", "£")]
    [TestCase("EUR", "€")]
    [TestCase("USD", "$")]
    [TestCase("BRL", "R$")]
    [TestCase("DKK", "kr.")]
    [TestCase("SEK", "kr")]
    [TestCase("NOK", "kr")]
    [TestCase("JPY", "¥")]
    [TestCase("CNY", "¥")]
    [TestCase("PLN", "zł")]
    [TestCase("RUB", "₽")]
    public void GetSymbol_ShouldReturnExpectedSymbol_ForSpecifiedLanguage(string currencyCode, string expectedSymbol)
    {
        var result = currencyCodeMapper.GetSymbol(currencyCode);
        Assert.AreEqual(expectedSymbol, result);
    }
}