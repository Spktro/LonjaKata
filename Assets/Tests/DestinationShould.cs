using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tests
{
    public class DestinationShould
    {

        // * CalculateSalePerformance equal zero when amount is zero
        // * CalculateSalePerformance when distance greater than zero
        // * CalculateDestinationPerformance having 3 different seafood
        // * CalculateDestinationPerformance having 3 different seafood, 1 of which is not in the market


        Market marketTest;
        Destination destinationTest;

        [SetUp]
        public void SetUp()
        {
            GivenATestMarketAndDestination();
        }

        private void GivenATestMarketAndDestination()
        {
            marketTest = new Market("Madrid");
            marketTest.AddSeafoodDetail("Vieiras", 500);
            marketTest.AddSeafoodDetail("Pulpo", 0);
            marketTest.AddSeafoodDetail("Centollo", 450);
            destinationTest = new Destination(800, marketTest);
        }

        [Test]
        public void CalculateSalePerformanceEqualZeroWhenAmountIsZero()
        {
            //given
            Seafood seafood = new Seafood("Vieiras");
            int amount = 0;

            //when
            var salePerformance = destinationTest.CalculateSalePerformance(seafood, amount);

            //then
            Assert.AreEqual(0, salePerformance);
        }



        [Test]
        public void CalculateSalePerformanceWhenDistanceGreaterThanZero()
        {
            //given
            Seafood seafood = new Seafood("Vieiras");
            int amount = 10;
            decimal price = destinationTest.Market.GetMarketPrice(seafood);
            float distance = destinationTest.Distance;

            //when
            var salePerformance = destinationTest.CalculateSalePerformance(seafood, amount);

            //then
            Assert.AreEqual(price * amount - price * Convert.ToDecimal(amount * Mathf.Floor(distance / 100) * 0.01f), salePerformance);
        }

        [Test]
        public void CalculateDestinationPerformanceHaving3DifferentSeafood()
        {
            //given
            List<Seafood> seafoods = new List<Seafood>()
            {
                new Seafood("Vieiras"),
                new Seafood("Pulpo"),
                new Seafood("Centollo")
            };
            int amount = 10;
            List<SeafoodStock> seafoodStocks = new List<SeafoodStock>(seafoods.Count);
            seafoods.ForEach(seafood => {
                seafoodStocks.Add(new SeafoodStock(seafood, amount));
            });

            //when
            var DestinationPerformance = destinationTest.CalculateDestinationPerformance(seafoodStocks);

            //then
            Assert.AreEqual(7135 , DestinationPerformance);
        }

        [Test]
        public void CalculateDestinationPerformanceHaving3DifferentSeafoodBut1SeafoodNotInTheMarket() 
        {
            //given
            List<Seafood> seafoods = new List<Seafood>()
            {
                new Seafood("Vieiras"),
                new Seafood("Pulpo"),
                new Seafood("Cornalitos")
            };
            int amount = 10;
            float distance = destinationTest.Distance;
            List<SeafoodStock> seafoodStocks = new List<SeafoodStock>(seafoods.Count);
            seafoods.ForEach(seafood => {
                seafoodStocks.Add(new SeafoodStock(seafood, amount));
            });

            //when
            var DestinationPerformance = destinationTest.CalculateDestinationPerformance(seafoodStocks);

            //then
            Assert.AreEqual(2995, DestinationPerformance);
        }

    }
}
