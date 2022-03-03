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
    public class TripShould
    {

        // * CalculateSalePerformance equal zero when amount is zero
        // * CalculateSalePerformance when distance greater than zero
        // * CalculateTripPerformance having 3 different seafood
        // * CalculateTripPerformance having 3 different seafood, 1 of which is not in the market


        Market marketTest;
        Trip tripTest;

        [SetUp]
        public void SetUp()
        {
            GivenATestMarketAndTrip();
        }

        private void GivenATestMarketAndTrip()
        {
            marketTest = new Market("Madrid");
            marketTest.AddSeafoodDetail("Vieiras", 500);
            marketTest.AddSeafoodDetail("Pulpo", 0);
            marketTest.AddSeafoodDetail("Centollo", 450);
            tripTest = new Trip(800, marketTest);
        }

        [Test]
        public void CalculateSalePerformanceEqualZeroWhenAmountIsZero()
        {
            //given
            Seafood seafood = new Seafood("Vieiras");
            int amount = 0;

            //when
            var salePerformance = tripTest.CalculateSalePerformance(seafood, amount);

            //then
            Assert.AreEqual(0, salePerformance);
        }



        [Test]
        public void CalculateSalePerformanceWhenDistanceGreaterThanZero()
        {
            //given
            Seafood seafood = new Seafood("Vieiras");
            int amount = 10;
            decimal price = tripTest.Market.GetMarketPrice(seafood);
            float distance = tripTest.Distance;

            //when
            var salePerformance = tripTest.CalculateSalePerformance(seafood, amount);

            //then
            Assert.AreEqual(price * amount - price * Convert.ToDecimal(amount * Mathf.Floor(distance / 100) * 0.01f), salePerformance);
        }

        [Test]
        public void CalculateTripPerformanceHaving3DifferentSeafood()
        {
            //given
            List<Seafood> seafoods = new List<Seafood>()
            {
                new Seafood("Vieiras"),
                new Seafood("Pulpo"),
                new Seafood("Centollo")
            };
            int amount = 10;
            float distance = tripTest.Distance;
            List<SeafoodStock> seafoodStocks = new List<SeafoodStock>(seafoods.Count);
            seafoods.ForEach(seafood => {
                seafoodStocks.Add(new SeafoodStock(seafood, amount));
            });

            //when
            var tripPerformance = tripTest.CalculateTripPerformance(seafoodStocks);

            //then
            Assert.AreEqual(7135 , tripPerformance);
        }

        [Test]
        public void CalculateTripPerformanceHaving3DifferentSeafoodBut1SeafoodNotInTheMarket() 
        {
            //given
            List<Seafood> seafoods = new List<Seafood>()
            {
                new Seafood("Vieiras"),
                new Seafood("Pulpo"),
                new Seafood("Cornalitos")
            };
            int amount = 10;
            float distance = tripTest.Distance;
            List<SeafoodStock> seafoodStocks = new List<SeafoodStock>(seafoods.Count);
            seafoods.ForEach(seafood => {
                seafoodStocks.Add(new SeafoodStock(seafood, amount));
            });

            //when
            var tripPerformance = tripTest.CalculateTripPerformance(seafoodStocks);

            //then
            Assert.AreEqual(2995, tripPerformance);
        }

    }
}
