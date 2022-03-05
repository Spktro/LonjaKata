
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Destination {

        public float Distance { get; set; }
        public Market Market { get; set; }

        public Destination(float distance, Market market)
        {
            Distance = distance;
            Market = market;
        }

        public decimal CalculateSalePerformance(Seafood seafood, float kilosSupplies) {
            decimal price = Market.GetMarketPrice(seafood);
            return  price * Convert.ToDecimal(kilosSupplies) - price * Convert.ToDecimal(kilosSupplies * Mathf.Floor(Distance / 100) * 0.01f);
        }

        public decimal CalculateDestinationPerformance(List<SeafoodStock> seafoodStocks) {
            decimal DestinationPerformance = 0;
            seafoodStocks.ForEach(seafoodStock => {
                DestinationPerformance += CalculateSalePerformance(seafoodStock.Seafood, seafoodStock.KilosSupplies);
            });
            DestinationPerformance -= 5 + Convert.ToDecimal(2 * Distance);
            return DestinationPerformance;
        }
    }
}