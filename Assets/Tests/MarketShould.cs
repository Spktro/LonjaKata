using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MarketShould
    {
        // * Return zero when seafood amount is zero -
        // * Return seafood price when amount is one -
        // * Return seafood times amount according to given amount -
        // * Return zero when the market doesnt have seafood passed  -
        // * throw an exception when amount is negative -
        // * throw an exception when seafood is null -

        Market marketTest;

        [SetUp]
        public void Setup()
        {
            GivenATestMarket();
        }

        private void GivenATestMarket()
        {
            marketTest = new Market("Madrid");
            marketTest.AddSeafoodDetail("Vieiras", 500);
            marketTest.AddSeafoodDetail("Pulpo", 0);
            marketTest.AddSeafoodDetail("Centollo", 450);
        }

        [Test]
        public void ReturnZeroWhenSeaFoodAmountIsZero()
        {
            //given        
            var seafoodTest = new Seafood("Vieiras");
            int seafoodAmount = 0;

            //when
            var seafoodRevenue = marketTest.CalculateRevenue(seafoodTest, seafoodAmount);

            //then
            Assert.AreEqual(0, seafoodRevenue);
        }


        [Test]
        public void ReturnSeafoodPriceWhenAmountIsOne()
        {
            //given
            var seafoodTest = new Seafood("Vieiras");
            int seafoodAmount = 1;

            //when
            var seafoodRevenue = marketTest.CalculateRevenue(seafoodTest, seafoodAmount);
            var seafoodMarketPrice = marketTest.GetMarketPrice(seafoodTest);

            //then
            Assert.AreEqual(seafoodRevenue, seafoodMarketPrice);
        }

        [Test]
        public void ReturnSeafoodTimesAmountAccordingToGivenAmount()
        {
            //given
            var seafoodTest = new Seafood("Vieiras");
            int seafoodAmount = 10;

            //when
            var seafoodRevenue = marketTest.CalculateRevenue(seafoodTest, seafoodAmount);
            var seafoodMarketPrice = marketTest.GetMarketPrice(seafoodTest);

            //Then
            Assert.AreEqual(seafoodRevenue, seafoodMarketPrice * seafoodAmount);
        }

        [Test]
        public void ReturnZeroWhenTheMarketDoesntHaveSeafoodPassed()
        {
            //given
            var seafoodTest = new Seafood("Cornalitos");
            int seafoodAmount = 10;

            //when
            var seafoodRevenue = marketTest.CalculateRevenue(seafoodTest, seafoodAmount);

            //Then
            Assert.AreEqual(0, seafoodRevenue);
        }


        [Test]
        public void ThrowAnExceptionWhenAmountIsNegative()
        {
            //given
            var seafoodTest = new Seafood("Cornalitos");
            int seafoodAmount = -1;

            //when        

            //Then
            Assert.Throws(typeof(Exception), () => marketTest.CalculateRevenue(seafoodTest, seafoodAmount));
        }

        [Test]
        public void ThrowAnExceptionWhenSeafoodIsNull()
        {
            //given
            int seafoodAmount = 10;

            //when        

            //Then
            Assert.Throws(typeof(NullReferenceException), () => marketTest.CalculateRevenue(null, seafoodAmount));
        }


    }
}