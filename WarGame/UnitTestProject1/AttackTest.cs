using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarGame.Models;
using WarGame.Helper;
using Moq;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class AttackTest
    {
        
        [TestMethod]
        public void AttackLostTest()
        {
            //Arrange
            var mockKingdom = new KingdomViewModel("reino", 5, 10);
            var testPosition = new RegionPosition("t", 1, 1, 1, 1);
            var testRegion = new RegionViewModel("Teste", mockKingdom, testPosition);
            int[] fakeA = { 1 };
            int[] fakeD = { 6, 6, 6 };
            var actual = testRegion.Attack(testRegion, fakeA, fakeD);
            //Attack returns (attackLostTroops[],DefenseLostTroops[])
            //Act
            int[] expected = { 1, 0 };

            //Assert
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);

        }

        [TestMethod]
        public void AttackWinTest()
        {
            //Arrange
            var mockKingdom = new KingdomViewModel("reino", 5, 10);
            var testPosition = new RegionPosition("t", 1, 1, 1, 1);
            var testRegion = new RegionViewModel("Teste", mockKingdom, testPosition);
            int[] fakeA = { 6,3,6 };
            int[] fakeD = { 1, 6, 2 };
            var actual = testRegion.Attack(testRegion, fakeA, fakeD);
            //Attack returns (attackLostTroops[],DefenseLostTroops[])
            //Act
            int[] expected = { 1, 2 };

            //Assert
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);

        }

        [TestMethod]
        public void TieTest()
        {
            //Arrange
            var mockKingdom = new KingdomViewModel("reino", 5, 10);
            var testPosition = new RegionPosition("t", 1, 1, 1, 1);
            var testRegion = new RegionViewModel("Teste", mockKingdom, testPosition);
            int[] fakeA = { 6, 6, 6 };
            int[] fakeD = { 6, 6, 6 };
            var actual = testRegion.Attack(testRegion, fakeA, fakeD);
            //Attack returns (attackLostTroops[],DefenseLostTroops[])
            //Act
            int[] expected = { 3, 0 };

            //Assert
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);

        }

    }
}
