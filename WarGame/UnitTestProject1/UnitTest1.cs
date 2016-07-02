using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarGame.Models;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AttackTest()
        {
            // Arrange
            //var BattleTest = new Mock<WarGame.Helper.Objective>();
            //Moq.Mock<RegionViewModel> mockRegion = new Moq.Mock<RegionViewModel>();
            var mockRegion = new Mock<RegionViewModel>();
            var fakeRegion = new Mock<RegionViewModel>();
            int[] fakeA = { 1 };
            int[] fakeD = { 6, 6, 6 };
            var actual = mockRegion.Setup<int[]>(m=>m.Attack(fakeRegion.Object,fakeA,fakeD));
            //Act
            int[] expected = {0,1};
            //var MockRegion = new RegionViewModel("ataque",It.IsNotNull,It.IsNotNull);
            //Assert
            Assert.AreEqual(expected,actual);


        }
    }


    public interface vector
    {
        int[] fakeVector();
    }

}
