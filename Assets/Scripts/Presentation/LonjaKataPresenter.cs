using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonjaKataPresenter
{
    private readonly ILonjaKataView lonjaKataView;
    private Port port;

    public LonjaKataPresenter(ILonjaKataView view)
    {
        this.lonjaKataView = view;

        LoadData();
    }

    private void LoadData()
    {
        port = new Port();
        port.Name = "Galician Port";
    }

    public void CalculateBestMarket(IDistancesView distancesView, IStockView stockView, List<IMarketsView> marketsViews)
    {
       

        List<Market> markets = new List<Market>(3);
        Market newMarket;
        marketsViews.ForEach(marketView => {
            newMarket = new Market(marketView.MarketName);
            marketView.MarketPriceDTOs.ForEach(marketPriceDTO =>{
                newMarket.AddSeafoodDetail(marketPriceDTO.SeafoodNames, marketPriceDTO.Price);
            });
            
            markets.Add(newMarket); 
        });

        Destination newDestination;
        for (int i = 0; i < 3; i++) {
            newDestination = new Destination(distancesView.Distances[i], markets[i]);
            port.Destinations.Add(newDestination);
        }

        List<SeafoodStock> seafoodStock = new List<SeafoodStock>(3);

           stockView.SeafoodStockDTOs.ForEach(seafoodStockDTO => {
               seafoodStock.Add(SeafoodStockDTOAdapter.SeafoodStockDTOToSeafoodStock(seafoodStockDTO));
           });        
        var bestMarketPerformance = port.CalculateBestMarketToSell(seafoodStock);
        lonjaKataView.UpdateBestMarketTxt(bestMarketPerformance.Item1.Name, bestMarketPerformance.Item2);
    }
}
