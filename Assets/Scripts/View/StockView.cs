using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StockView : MonoBehaviour, IStockView
{
    [SerializeField] private InputField[] stock;
    [SerializeField] private string[] seafoodName;

    public List<float> Stock
    {
        get
        {
            return stock
                   .Select(stockInp => float.Parse(stockInp.text))
                   .ToList();
        }

    }

    public List<SeafoodStockDTO> SeafoodStockDTOs
    {
        get {

            int i = 0;
            return stock
                   .Select(stockInp => new SeafoodStockDTO(seafoodName[i++], float.Parse(stockInp.text)))
                   .ToList();
        }
    }
}

