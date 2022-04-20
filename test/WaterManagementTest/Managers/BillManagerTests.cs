using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterManagement;
using WaterManagement.Models;
using WaterManagement.Utilities;

namespace WaterManagementTest.Managers
{
    [TestFixture]
    public class BillManagerTests
    {
        private Mock<ILogger> _logger;
        private Mock<IWaterManager> _waterManager;
        private Mock<IPeopleManager> _peopleManager;
        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();
            MyLogger.Log = _logger.Object;
            _waterManager = new Mock<IWaterManager>();
            _peopleManager = new Mock<IPeopleManager>();
        }

        [Test]
        [TestCase(250,2450,1750)]
        [TestCase(550, 3100, 2050)]
        [TestCase(1550, 6200, 3050)]
        [TestCase(3550, 17850, 5050)]
        public void GetTotalBill_ProperResponse(int tankerWater,int totalCost,int totalWater)
        {
            //Arrange
            var allocateCommand = "ALLOT_WATER 3 2:3";
            var guestCommands = new List<string> { "ADD_GUESTS 4", "ADD_GUESTS 1" };
            var people = new People() { PeopleCount = 5,GuestCount = 5};
            var water = new Water() { BorewellWater = 900, CorporationWater = 600, TankerWater = tankerWater };
            _peopleManager.Setup(x => x.GetPeopleAndGuests(It.IsAny<string>(), It.IsAny<List<string>>())).Returns(people);
            _waterManager.Setup(x => x.GetWaterUsed(people, It.IsAny<Ratio>())).Returns(water);
            var expected = new Result() { TotalCost = totalCost, TotalWater = totalWater };

            //Act
            var obj = new BillManager(_waterManager.Object, _peopleManager.Object);
            var result = obj.GetTotalBill(allocateCommand, guestCommands);
            
            //Assert
            Assert.AreEqual(expected.TotalWater, result.TotalWater);
            Assert.AreEqual(expected.TotalCost, result.TotalCost);
        }

        [Test]
        public void GetTotalBill_ThrowsFormatException()
        {
            //Arrange
            var allocateCommand = "ALLOT_WATER 3 X:Y";
            var guestCommands = new List<string> { "ADD_GUESTS 4", "ADD_GUESTS 1" };
            var people = new People() { PeopleCount = 5, GuestCount = 5 };

            //Act
            var obj = new BillManager(_waterManager.Object, _peopleManager.Object);

            //Assert
            Assert.Throws<FormatException>(()=>obj.GetTotalBill(allocateCommand,guestCommands));

        }

    }
}
