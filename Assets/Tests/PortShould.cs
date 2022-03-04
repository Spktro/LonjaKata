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
    public class PortShould
    {
        //Calculate best market to sell no load of seafood
        //Calculate best market to sell 1 load of seafood
        //Calculate best market to sell 3 different load of seafood

        Port portTest;


        [SetUp]
        public void SetUp()
        {
            GivenATestMarketDestinationsAndPort();
        }

        private void GivenATestMarketDestinationsAndPort()
        {
            Market marketTest1 = new Market("Madrid");
            marketTest1.AddSeafoodDetail("Vieiras", 500);
            marketTest1.AddSeafoodDetail("Pulpo", 0);
            marketTest1.AddSeafoodDetail("Centollo", 450);
            Market marketTest2 = new Market("Barcelona");
            marketTest2.AddSeafoodDetail("Vieiras", 450);
            marketTest2.AddSeafoodDetail("Pulpo", 120);
            marketTest2.AddSeafoodDetail("Centollo", 450);
            Market marketTest3 = new Market("Lisboa");
            marketTest3.AddSeafoodDetail("Vieiras", 600);
            marketTest3.AddSeafoodDetail("Pulpo", 100);
            marketTest3.AddSeafoodDetail("Centollo", 500);
            Destination destinationTest1 = new Destination(800, marketTest1);
            Destination destinationTest2 = new Destination(1100, marketTest2);
            Destination destinationTest3 = new Destination(600, marketTest3);

            portTest = new Port();
            portTest.Destinations.Add(destinationTest1);
            portTest.Destinations.Add(destinationTest2);
            portTest.Destinations.Add(destinationTest3);
        }

        [Test]
        public void CalculateBestMarketToSellNoLoadOfSeafood()
        {
            //given
            List<Seafood> seafoods = new List<Seafood>()
            {
                new Seafood("Vieiras"),
                new Seafood("Pulpo"),
                new Seafood("Centollo")
            };
            int amount = 0;
            List<SeafoodStock> seafoodStocks = new List<SeafoodStock>(seafoods.Count);
            seafoods.ForEach(seafood => {
                seafoodStocks.Add(new SeafoodStock(seafood, amount));
            });

            //when
            Market bestMarket = portTest.CalculateBestMarketToSell(seafoodStocks);

            //then
            Assert.AreEqual(null, bestMarket);
        }

        [Test]
        public void CalculateBestMarketToSell1LoadOfSeafood()
        {
            //given
            List<Seafood> seafoods = new List<Seafood>()
            {
                new Seafood("Vieiras")
            };
            int amount = 10;
            List<SeafoodStock> seafoodStocks = new List<SeafoodStock>(seafoods.Count);
            seafoods.ForEach(seafood => {
                seafoodStocks.Add(new SeafoodStock(seafood, amount));
            });

            //when
            Market bestMarket = portTest.CalculateBestMarketToSell(seafoodStocks);

            //then
            Assert.AreEqual(portTest.Destinations[2].Market , bestMarket);
        }

        [Test]
        public void CalculateBestMarketToSell3DifferentLoadOfSeafood()
        {
            //given
            List<Seafood> seafoods = new List<Seafood>()
            {
                new Seafood("Vieiras"),
                new Seafood("Pulpo"),
                new Seafood("Centollo")
            };
            List<SeafoodStock> seafoodStocks = new List<SeafoodStock>(seafoods.Count);
            seafoodStocks.Add(new SeafoodStock(seafoods[0], 50));
            seafoodStocks.Add(new SeafoodStock(seafoods[1], 100));
            seafoodStocks.Add(new SeafoodStock(seafoods[2], 50));

            //when
            Market bestMarket = portTest.CalculateBestMarketToSell(seafoodStocks);

            //then
            Assert.AreEqual(portTest.Destinations[2].Market, bestMarket);
        }
    }
}
