using System.Collections;
using System.Collections.Generic;
using Model;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MarketShould
{
    // * Return zero when seafood amount is zero
    // * Return seafood price when amount is one
    // * Return seafood times amount acording to given amount   
    // * Return zero when the market doesnt have seafood passed
    // * throw an exception when amount is negative
    // * throw an exception when seafood its null 

    // A Test behaves as an ordinary method
    [Test]
    public void ReturnZeroWhenSeaFoodAmountIsZero()
    {
        //given
        var marketTest = new Market();
        marketTest.Name = "Test Market";
        var seafood1 = new Seafood("Vieiras", 500);
        var seafood2 = new Seafood("Pulpo", 0);
        var seafood3 = new Seafood("Centollo", 450);
        marketTest.Seafoods.Add(seafood1);
        marketTest.Seafoods.Add(seafood2);
        marketTest.Seafoods.Add(seafood3);

       // var seafood1 = new Seafood("Cangrejos", );
        //when


        //then
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
