
using System.Collections.Generic;

namespace Model {
    public class Port {
        public string Name { get; set; }
        public List<Destination> Destinations { get; set; } = new List<Destination>();

        public Market CalculateBestMarketToSell(List<SeafoodStock> seafoodStocks) {
            //TODO
            return Destinations[0].Market;
        }
    }
}