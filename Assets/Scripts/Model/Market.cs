
using System;
using System.Linq;
using System.Collections.Generic;

namespace Model {
    public class Market {
        public string Name { get; set; }
        public List<SeafoodDetail> SeafoodDetails { get; set; } = new List<SeafoodDetail>();

        public Market(string name)
        {
            Name = name;
        }

        public void AddSeafoodDetail(string seafoodName, decimal price)
        {            
            SeafoodDetails.Add(new SeafoodDetail(new Seafood(seafoodName), price));
        }

        public decimal CalculateRevenue(Seafood seafood, int seafoodAmount)
        {
            if (seafoodAmount < 0)
            {
                throw new Exception("Seafood amount must be greater or equal than zero");
            }

            if (seafood is null)
            {
                throw new NullReferenceException("Seafood can't be null");
            }
            return GetMarketPrice(seafood) * seafoodAmount;
        }

        public decimal GetMarketPrice(Seafood seafood)
        {           
            var seafoodDetails = SeafoodDetails.Where(detail => detail.Seafood.Name == seafood.Name).SingleOrDefault();
            if (seafoodDetails is null)
                return 0;
            else
                return seafoodDetails.Price;
        }
    }
}
