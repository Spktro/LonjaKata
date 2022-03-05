using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonjaKataPresenter
{
    private readonly ILonjaKataView view;
    private Port port;

    public LonjaKataPresenter(ILonjaKataView view)
    {
        this.view = view;

        LoadData();
    }

    private void LoadData()
    {
        port = new Port();
        port.Name = "Galician Port";
    }

    public void CalculateBestMarket(IDistancesView distancesView, IStockView stockView, List<IMarketsView> marketsViews)
    {
        Market marketTest1 = new Market("Madrid");
        marketTest1.AddSeafoodDetail("Vieiras", 500);
        marketTest1.AddSeafoodDetail("Pulpo", 0);
        marketTest1.AddSeafoodDetail("Centollo", 450);
        Market marketTest2 = new Market("Barcelona");
        marketTest2.AddSeafoodDetail("Vieiras", 450);
        marketTest2.AddSeafoodDetail("Pulpo", 120);
        marketTest2.AddSeafoodDetail("Centollo", 450);
        Market marketTest3 = new Market("Lisboa");
        marketTest3.AddSeafoodDetail("Vieiras", 600);
        marketTest3.AddSeafoodDetail("Pulpo", 100);
        marketTest3.AddSeafoodDetail("Centollo", 500);

        Destination destinationTest1 = new Destination(800, marketTest1);
        Destination destinationTest2 = new Destination(1100, marketTest2);
        Destination destinationTest3 = new Destination(600, marketTest3);

        List<Market> markets = new List<Market>(3);
        Market newMarket;
        marketsViews.ForEach(marketView => {
            newMarket = new Market(marketView.MarketName);
            //TODO
            markets.Add(newMarket); 
        });

        Destination newDestination;
        for (int i = 0; i < 3; i++) {
            newDestination = new Destination(distancesView.Distances[i], markets[i]);
            port.Destinations.Add(newDestination);
        }

    }
}
