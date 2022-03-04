using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MarketsView : MonoBehaviour, IMarketsView
{
    [SerializeField] private string CityName;
    [SerializeField] private InputField[] prices;


    public List<string> Prices
    {
        get
        {
            return prices
                .Select(stockInp => stockInp.text)
                .ToList();
        }
    }
}

