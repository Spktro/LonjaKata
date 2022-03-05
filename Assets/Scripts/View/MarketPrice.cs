using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MarketPrice {
    [SerializeField] private string seafoodName;
    public string SeafoodNames => seafoodName;
    
    [SerializeField] private InputField price;
    public decimal Price => decimal.Parse(price.text);

    
}





