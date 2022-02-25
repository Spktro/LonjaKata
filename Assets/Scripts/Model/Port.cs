
using System.Collections.Generic;

namespace Model {
    public class Port {
        public string Name { get; set; }
        public List<Trip> Trips { get; set; }
    }
}