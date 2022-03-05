using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MarketsView : MonoBehaviour, IMarketsView
{
    [SerializeField] private string marketName;
    [SerializeField] private List<MarketPrice> marketPrices;

    public string MarketName  => marketName;

    public List<decimal> Prices
    {
        get
        {
            return marketPrices
                .Select(marketPrice => decimal.Parse(marketPrice.Price.text))
                .ToList();
        }
    }

}