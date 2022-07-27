using System.Globalization;

namespace CurrencyCodeMapper;

public interface ICurrencyCodeMapper
{
    string GetSymbol(string currencyCode);
}

public class CurrencyCodeMapper : ICurrencyCodeMapper
{
    public string GetSymbol(string currencyCode) => _symbolsByCurrencyCode[currencyCode];

    private readonly Dictionary<string, string> _symbolsByCurrencyCode;

    public CurrencyCodeMapper()
    {
        _symbolsByCurrencyCode = new Dictionary<string, string>();

        var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                      .Select(cultureInfo => new RegionInfo(cultureInfo.Name));

        var NOKregions = regions.Where(r => r.ISOCurrencySymbol == "NOK");
        var japaneseYenRegions = regions.Where(r => r.ISOCurrencySymbol == "JPY");
        var polishSlotyRegions = regions.Where(r => r.ISOCurrencySymbol == "PLN");
        var russianRegions = regions.Where(r => r.ISOCurrencySymbol == "RUB");

        foreach (var region in regions)
        {
            if (!_symbolsByCurrencyCode.ContainsKey(region.ISOCurrencySymbol))
            {
                _symbolsByCurrencyCode.Add(region.ISOCurrencySymbol, region.CurrencySymbol);
            }
        }   
    }
}
