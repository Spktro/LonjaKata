using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tests {
    public class TripShould {

        // * CalculateSalePerformance equal zero when amount is zero
        // * CalculateSalePerformance when distance greater than zero
        // * Return seafood times amount minus depreciation according to given amount

        [Test]
        public void CalculateSalePerformanceEqualZeroWhenAmountIsZero()
        {
            //given
            Market market = new Market("Madrid");
            Trip trip = new Trip(800, market);
            Seafood seafood = new Seafood("Vieiras");
            int amount = 0;

            //when
            var salePerformance = trip.CalculateSalePerformance(seafood, amount);

            //then
            Assert.AreEqual(0, salePerformance);
        }

        [Test]
        public void CalculateSalePerformanceWhenDistanceGreaterThanZero() {

            //then
            //Assert.AreEqual(price * amount - price * amount * Mathf.Round(distance / 100) * 0.01f, salePerformance);
        }

    }
}
