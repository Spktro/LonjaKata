
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

        public decimal CalculateSalePerformance(Seafood seafood, int amount) {
            decimal price = Market.GetMarketPrice(seafood);
            return price * amount - price * Convert.ToDecimal(amount * Mathf.Floor(Distance / 100) * 0.01f);
        }

        public decimal CalculateDestinationPerformance(List<SeafoodStock> seafoodStocks) {
            decimal DestinationPerformance = 0;
            seafoodStocks.ForEach(seafoodStock => {
                DestinationPerformance += CalculateSalePerformance(seafoodStock.Seafood, seafoodStock.Amount);
            });
            DestinationPerformance -= 5 + Convert.ToDecimal(2 * Distance);
            return DestinationPerformance;
        }
    }
}