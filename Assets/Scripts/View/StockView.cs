using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StockView : MonoBehaviour, IStockView
{
    [SerializeField] private InputField[] stock;

    public List<string> Stock
    {
        get
        {
            return stock
                   .Select(stockInp => stockInp.text)
                   .ToList();
        }

    }

}

