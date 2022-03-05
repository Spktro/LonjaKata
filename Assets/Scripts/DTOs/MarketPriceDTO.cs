public class MarketPriceDTO
{
    public string SeafoodNames { get; }
    public decimal Price { get;  }

    public MarketPriceDTO(string seafoodNames, decimal price)
    {
        SeafoodNames = seafoodNames;
        Price = price;
    }
}