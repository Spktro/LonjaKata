
using System.Collections.Generic;

namespace Model
{
    public class Trip {
        public float Distance { get; set; }
        public Market Market { get; set; }

        public decimal CalculateSalePerformance(Seafood seafood, int amount) {
            //TODO
            return 0;
        }

        public decimal CalculateTripPerformance(List<SeafoodStock> seafoodStocks) {
            //TODO
            return 0;
        }
    }
}