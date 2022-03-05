using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class LonjaKataView : MonoBehaviour, ILonjaKataView
{
    [SerializeField] private DistancesView Distances;
    [SerializeField] private StockView Stock;
    [SerializeField] private List<MarketsView> Markets;
    private List<IMarketsView> IMarkets => Markets.Cast<IMarketsView>().ToList();

    private LonjaKataPresenter presenter;

    private void Start()
    {
        presenter = new LonjaKataPresenter(this);
    }

    public void OnCalculateButtonClicked()
    {
        presenter.CalculateBestMarket(Distances, Stock, IMarkets);
    }

    public void UpdateBestMarketTxt()
    {

    }
}

