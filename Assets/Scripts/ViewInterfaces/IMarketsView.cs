using System.Collections.Generic;

public interface IMarketsView
{
    string MarketName { get; }
    List<decimal> Prices { get; }
}