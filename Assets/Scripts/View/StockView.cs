using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StockView : MonoBehaviour, IStockView
{
    [SerializeField] private InputField[] stock;

    public List<float> Stock
    {
        get
        {
            return stock
                   .Select(stockInp => float.Parse(stockInp.text))
                   .ToList();
        }

    }

}

