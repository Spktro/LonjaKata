using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MarketsView : MonoBehaviour, IMarketsView
{
    [SerializeField] private string marketName;
    [SerializeField] private List<MarketPrice> marketPrices;

    public string MarketName  => marketName;

    public List<MarketPriceDTO> MarketPriceDTOs
    {
        get
        {            
            return marketPrices
                .Select(marketPrice => new MarketPriceDTO(marketPrice.SeafoodNames, marketPrice.Price))
                .ToList();
        }
    }

}
