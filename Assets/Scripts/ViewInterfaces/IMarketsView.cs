using System.Collections.Generic;

public interface IMarketsView
{
    string MarketName { get; }
    List<MarketPriceDTO> MarketPriceDTOs { get; }
}