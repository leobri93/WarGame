using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WarGame.Models;
using System.Collections.Generic;
using WarGame.Helper;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class VictoryTest
    {

        [TestMethod]
        public void Has24TerrainsVictoryTest()
        {
            //Arrange
            var mockfamily = new Mock<FamilyViewModel>();
            Mock<ObjectiveModel> mockObjective = new Mock<ObjectiveModel>(8, "abc");
            PlayerViewModel testPlayer = new PlayerViewModel("player1", mockfamily.Object, mockObjective.Object, true);
            testPlayer.Id = "1";
            var mockPlayer2 = new Mock<PlayerViewModel>();
            var mockPlayer3 = new Mock<PlayerViewModel>();
            List<PlayerViewModel> playersList = new List<PlayerViewModel>();
            playersList.Add(testPlayer);

            playersList.Add(mockPlayer2.Object);
            playersList.Add(mockPlayer3.Object);
            var mockKingdom = new Mock<KingdomViewModel>("mockKingdom", 5, 3);
            var mockRegionPosition = new Mock<RegionPosition>("src", 1, 2, 3, 4);

            var mockRegion = new RegionViewModel("Região", mockKingdom.Object, mockRegionPosition.Object, 2);
            mockRegion.Player = testPlayer;
            List<RegionViewModel> regionList = new List<RegionViewModel>();

            //To config for 24 territories(id = 8)
            for (var i = 0; i < 25; i++)
            {
                regionList.Add(mockRegion);
            }
            var resp = VictoryRule.regrasDeVitoria(testPlayer, regionList, playersList);

            //Act
            //Expectede True

            //Assert
            Assert.IsTrue(resp);
        }

        [TestMethod]
        public void HasNot24TerrainsVictoryTest()
        {
            //Arrange
            var mockPlayer1 = new Mock<PlayerViewModel>();
            var mockfamily = new Mock<FamilyViewModel>();
            Mock<ObjectiveModel> mockObjective = new Mock<ObjectiveModel>(8, "abc");
            PlayerViewModel testPlayer = new PlayerViewModel("player1", mockfamily.Object, mockObjective.Object, true);
            testPlayer.Id = "1";
            var mockPlayer2 = new Mock<PlayerViewModel>();
            var mockPlayer3 = new Mock<PlayerViewModel>();
            List<PlayerViewModel> playersList = new List<PlayerViewModel>();
            playersList.Add(mockPlayer1.Object);
            playersList.Add(mockPlayer2.Object);
            playersList.Add(mockPlayer3.Object);
            var mockKingdom = new Mock<KingdomViewModel>("mockKingdom", 5, 3);
            var mockRegionPosition = new Mock<RegionPosition>("src", 1, 2, 3, 4);
            var mockRegion = new RegionViewModel("Região", mockKingdom.Object, mockRegionPosition.Object, 2);
            mockRegion.Player = mockPlayer1.Object;
            List<RegionViewModel> regionList = new List<RegionViewModel>();
            //colocar 24 territorios de um player
            for (var i = 0; i < 25; i++)
            {
                regionList.Add(mockRegion);
            }
            var resp = VictoryRule.regrasDeVitoria(testPlayer, regionList, playersList);

            //Act
            //Expectede True

            //Assert
            Assert.IsFalse(resp);
        }

        //Testing Victory 6 - Exterminate another family
        [TestMethod]
        public void HasDestroyedFamilyVictoryTest()
        {
            //Arrange

            //Test player configurations(Baratheon)
            var mockfamily = new Mock<FamilyViewModel>("Baratheon");
            Mock<ObjectiveModel> mockObjective = new Mock<ObjectiveModel>(6, "abc");
            PlayerViewModel testPlayer = new PlayerViewModel("player1", mockfamily.Object, mockObjective.Object, true);
            testPlayer.Id = "1";


            //mockPlayers configuration (Targaryen and Stark)
            var mockfamily2 = new Mock<FamilyViewModel>("Targaryen");
            Mock<ObjectiveModel> mockObjective2 = new Mock<ObjectiveModel>(6, "abc");
            var mockPlayer2 = new Mock<PlayerViewModel>("player2", mockfamily2.Object, mockObjective2.Object,false);
            var mockfamily3 = new FamilyViewModel("Stark");
            var mockPlayer3 = new PlayerViewModel("player3", mockfamily3, mockObjective2.Object, false);

            //setting player's list
            List<PlayerViewModel> playersList = new List<PlayerViewModel>();
            playersList.Add(testPlayer);
            playersList.Add(mockPlayer2.Object);
            playersList.Add(mockPlayer3);

            //Creating a mocked region, and setting it in testPlayer's ownership
            var mockKingdom = new Mock<KingdomViewModel>("mockKingdom", 5, 3);
            var mockRegionPosition = new Mock<RegionPosition>("src", 1, 2, 3, 4);
            var mockRegion = new RegionViewModel("Região", mockKingdom.Object, mockRegionPosition.Object, 2);
            mockRegion.Player = testPlayer;
            List<RegionViewModel> regionList = new List<RegionViewModel>();

            //Putting 15 territories
            for (var i = 0; i < 15; i++)
            {
                regionList.Add(mockRegion);
            }

            var resp = VictoryRule.regrasDeVitoria(testPlayer, regionList, playersList);


            //Act
            //Expected True

            //Assert
            Assert.IsTrue(resp);
        }

        [TestMethod]
        public void HasNotDestroyedFamilyVictoryTest()
        {
            //Arrange

            //Test player configurations(Baratheon)
            var mockfamily = new Mock<FamilyViewModel>("Baratheon");
            Mock<ObjectiveModel> mockObjective = new Mock<ObjectiveModel>(6, "abc");
            PlayerViewModel testPlayer = new PlayerViewModel("player1", mockfamily.Object, mockObjective.Object, true);
            testPlayer.Id = "1";
            

            //mockPlayers configuration (Targaryen and Stark)
            var mockfamily2 = new Mock<FamilyViewModel>("Targaryen");
            Mock<ObjectiveModel> mockObjective2 = new Mock<ObjectiveModel>(6, "abc");
            var mockPlayer2 = new Mock<PlayerViewModel>("player2", mockfamily2.Object, mockObjective2.Object, false);
            var mockfamily3 = new FamilyViewModel("Stark");
            var mockPlayer3 = new PlayerViewModel("player3", mockfamily3, mockObjective2.Object, false);
                        
            //setting player's list
            List<PlayerViewModel> playersList = new List<PlayerViewModel>();
            playersList.Add(testPlayer);
            playersList.Add(mockPlayer2.Object);
            playersList.Add(mockPlayer3);

            //Creating a mocked region, and setting it in testPlayer's ownership
            var mockKingdom = new Mock<KingdomViewModel>("mockKingdom", 5, 3);
            var mockRegionPosition = new Mock<RegionPosition>("src", 1, 2, 3, 4);
            var mockRegion = new RegionViewModel("Região", mockKingdom.Object, mockRegionPosition.Object, 2);
            mockRegion.Player = testPlayer;
            List<RegionViewModel> regionList = new List<RegionViewModel>();

            //Putting 15 territories
            for (var i = 0; i < 15; i++)
            {
                regionList.Add(mockRegion);
            }
            var starkRegion = new RegionViewModel("Winterfell", mockKingdom.Object, mockRegionPosition.Object, 2);
            starkRegion.Player = mockPlayer3;
            regionList.Add(starkRegion);
            var resp = VictoryRule.regrasDeVitoria(testPlayer, regionList, playersList);

            //Act
            //Expected False

            //Assert
            Assert.IsFalse(resp);
        }

        //Testing Victory 11 - 2 troops on more than 18 terrains
        [TestMethod]
        public void TwoTroopsMoreThan18TerrainsVictoryTest()
        {
            //Arrange
            var mockPlayer1 = new Mock<PlayerViewModel>();
            var mockPlayer2 = new Mock<PlayerViewModel>();
            var mockPlayer3 = new Mock<PlayerViewModel>();
            var mockfamily = new Mock<FamilyViewModel>();
            Mock<ObjectiveModel> mockObjective = new Mock<ObjectiveModel>(11, "abc");
            PlayerViewModel testPlayer = new PlayerViewModel("player1", mockfamily.Object, mockObjective.Object, true);
            testPlayer.Id = "1";

            List<PlayerViewModel> playersList = new List<PlayerViewModel>();
            playersList.Add(mockPlayer1.Object);
            playersList.Add(mockPlayer2.Object);
            playersList.Add(mockPlayer3.Object);

            var mockKingdom = new Mock<KingdomViewModel>("mockKingdom", 5, 3);
            var mockRegionPosition = new Mock<RegionPosition>("src", 1, 2, 3, 4);
            var mockRegion = new RegionViewModel("Região", mockKingdom.Object, mockRegionPosition.Object, 2);
            mockRegion.Troops = 2;
            mockRegion.Player = testPlayer;
            mockRegion.Player.Id = "1";

            List<RegionViewModel> regionList = new List<RegionViewModel>();
            //colocar 24 territorios de um player
            for (var i = 0; i < 18; i++)
            {
                regionList.Add(mockRegion);
            }
            var resp = VictoryRule.regrasDeVitoria(testPlayer, regionList, playersList);

            //Act
            //Expectede True

            //Assert
            Assert.IsTrue(resp);
        }

        //Testing Vitory 9 - The North and Dorne
        [TestMethod]
        public void ConquestTheNorthAndDorneTest()
        {
            //The North has 10 regions
            //Dorne has 3 regions
            //Arrange

            //Test player configurations(Stark)
            var mockfamily = new Mock<FamilyViewModel>("Stark");
            Mock<ObjectiveModel> mockObjective = new Mock<ObjectiveModel>(9, "abc");
            PlayerViewModel testPlayer = new PlayerViewModel("player1", mockfamily.Object, mockObjective.Object, true);
            testPlayer.Id = "1";


            //mockPlayers configuration (Targaryen and Baratheon)
            var mockfamily2 = new Mock<FamilyViewModel>("Targaryen");
            Mock<ObjectiveModel> mockObjective2 = new Mock<ObjectiveModel>(6, "abc");
            var mockPlayer2 = new Mock<PlayerViewModel>("player2", mockfamily2.Object, mockObjective2.Object, false);
            var mockfamily3 = new FamilyViewModel("Baratheon");
            var mockPlayer3 = new PlayerViewModel("player3", mockfamily3, mockObjective2.Object, false);

            //setting player's list
            List<PlayerViewModel> playersList = new List<PlayerViewModel>();
            playersList.Add(testPlayer);
            playersList.Add(mockPlayer2.Object);
            playersList.Add(mockPlayer3);

            //Creating a mocked region(The North) and setting it in testPlayer's ownership
            var mockNorthKingdom = new Mock<KingdomViewModel>("The North", 5, 3);
            var mockRegionPosition = new Mock<RegionPosition>("src", 1, 2, 3, 4);
            var mockNorthRegion = new RegionViewModel("Norte", mockNorthKingdom.Object, mockRegionPosition.Object, 2);
            mockNorthRegion.Player = testPlayer;

            //Creating a mocked region(Dorne) and setting it in testPlayer's ownership
            var mockDorneKingdom = new Mock<KingdomViewModel>("Dorne", 5, 3);
            var mockDorneRegionPosition = new Mock<RegionPosition>("src", 1, 2, 3, 4);
            var mockDorneRegion = new RegionViewModel("Dorne", mockDorneKingdom.Object, mockDorneRegionPosition.Object, 2);
            mockDorneRegion.Player = testPlayer;

            //Creating the Region List
            List<RegionViewModel> regionList = new List<RegionViewModel>();
            
            //Setting The North(10) territories
            for (var i = 0; i < 10; i++)
            {
                regionList.Add(mockNorthRegion);
            }
                       
            //Setting Dorne(1) territories
            for (var i = 0; i < 3; i++)
            {
                regionList.Add(mockDorneRegion);
            }
            var resp = VictoryRule.regrasDeVitoria(testPlayer, regionList, playersList);
            
            //Act
            //Expected True

            //Assert
            Assert.IsTrue(resp);
        }

        [TestMethod]
        public void FailedConquestTheNorthAndDorneTest()
        {
            //The North has 10 regions
            //Dorne has 3 regions
            //Arrange

            //Test player configurations(Baratheon)
            var mockfamily = new Mock<FamilyViewModel>("Stark");
            Mock<ObjectiveModel> mockObjective = new Mock<ObjectiveModel>(9, "abc");
            PlayerViewModel testPlayer = new PlayerViewModel("player1", mockfamily.Object, mockObjective.Object, true);
            testPlayer.Id = "1";


            //mockPlayers configuration (Targaryen and Stark)
            var mockfamily2 = new Mock<FamilyViewModel>("Targaryen");
            Mock<ObjectiveModel> mockObjective2 = new Mock<ObjectiveModel>(6, "abc");
            var mockPlayer2 = new Mock<PlayerViewModel>("player2", mockfamily2.Object, mockObjective2.Object, false);
            var mockfamily3 = new FamilyViewModel("Baratheon");
            var mockPlayer3 = new PlayerViewModel("player3", mockfamily3, mockObjective2.Object, false);

            //setting player's list
            List<PlayerViewModel> playersList = new List<PlayerViewModel>();
            playersList.Add(testPlayer);
            playersList.Add(mockPlayer2.Object);
            playersList.Add(mockPlayer3);

            //Creating a mocked region(The North) and setting it in testPlayer's ownership
            var mockNorthKingdom = new Mock<KingdomViewModel>("The North", 5, 3);
            var mockRegionPosition = new Mock<RegionPosition>("src", 1, 2, 3, 4);
            var mockNorthRegion = new RegionViewModel("Norte", mockNorthKingdom.Object, mockRegionPosition.Object, 2);
            mockNorthRegion.Player = testPlayer;

            //Creating a mocked region(Dorne) and setting it in testPlayer's ownership
            var mockDorneKingdom = new Mock<KingdomViewModel>("Dorne", 5, 3);
            var mockDorneRegionPosition = new Mock<RegionPosition>("src", 1, 2, 3, 4);
            var mockDorneRegion = new RegionViewModel("Dorne", mockDorneKingdom.Object, mockDorneRegionPosition.Object, 2);
            mockDorneRegion.Player = testPlayer;

            //Creating the Region List
            List<RegionViewModel> regionList = new List<RegionViewModel>();

            //Setting The North(9) territories to testPlayer
            for (var i = 0; i < 10; i++)
            {
                regionList.Add(mockNorthRegion);
            }
            //Setting North(1) territories to mockPlayer3
            mockNorthRegion.Player = mockPlayer3;
            regionList.Add(mockNorthRegion);

            //Setting Dorne(3) territories to mockPlayer3
            for (var i = 0; i < 3; i++)
            {
                regionList.Add(mockDorneRegion);
            }
            var resp = VictoryRule.regrasDeVitoria(testPlayer, regionList, playersList);

            //Act
            //Expected False

            //Assert
            Assert.IsFalse(resp);
        }
    }
}
