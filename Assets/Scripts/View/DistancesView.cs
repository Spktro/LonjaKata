using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DistancesView : MonoBehaviour, IDistancesView
{
    [SerializeField] private InputField[] distances;

    public List<string> Distances
    {
        get
        {
            return distances
                .Select(stockInp => stockInp.text)
                .ToList();
        }
    }
}

