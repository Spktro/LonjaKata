
using System.Collections.Generic;

namespace Model {
    public class Port {
        public string Name { get; set; }
        public List<Destination> Destinations { get; set; } = new List<Destination>();

        public (Market,decimal) CalculateBestMarketToSell(List<SeafoodStock> seafoodStocks) {
            decimal bestPerformance = 0, currentPerformance;
            Destination bestDestination = null;

            Destinations.ForEach(destination => { 
                currentPerformance = destination.CalculateDestinationPerformance(seafoodStocks);
                if (currentPerformance > bestPerformance)
                {
                    bestPerformance = currentPerformance;
                    bestDestination = destination;
                }
            });
            return (bestDestination?.Market, bestPerformance);
        }
    }
}