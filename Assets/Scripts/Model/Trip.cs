
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Trip {

        public float Distance { get; set; }
        public Market Market { get; set; }

        public Trip(float distance, Market market)
        {
            Distance = distance;
            Market = market;
        }

        public decimal CalculateSalePerformance(Seafood seafood, int amount) {
            decimal price = Market.GetMarketPrice(seafood);
            return price * amount - price * Convert.ToDecimal(amount * Mathf.Floor(Distance / 100) * 0.01f);
        }

        public decimal CalculateTripPerformance(List<SeafoodStock> seafoodStocks) {
            decimal tripPerformance = 0;
            seafoodStocks.ForEach(seafoodStock => {
                tripPerformance += CalculateSalePerformance(seafoodStock.Seafood, seafoodStock.Amount);
            });
            tripPerformance -= 5 + Convert.ToDecimal(2 * Distance);
            return tripPerformance;
        }
    }
}