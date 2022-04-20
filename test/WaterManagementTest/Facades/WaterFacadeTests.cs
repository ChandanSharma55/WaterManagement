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

namespace WaterManagementTest.Facades
{
    [TestFixture]
    public class WaterFacadeTests
    {
        private Mock<IBillManager> _billManager;
        private Mock<ILogger> _logger;
        [SetUp]
        public void SetUp()
        {
            _billManager = new Mock<IBillManager>();
            _logger = new Mock<ILogger>();
            MyLogger.Log = _logger.Object;
        }

        [Test]
        public void CalculateTotalBill_ValidInput_ValidOutput()
        {
            //Arrange
            var expected = new Result()
            {
                TotalCost = 100,
                TotalWater = 100
            };
            _billManager.Setup(x => x.GetTotalBill(It.IsAny<string>(), It.IsAny<List<string>>())).Returns(expected);
            var commands = new string[] { "ALLOT_WATER 3 2:1", "ADD_GUESTS 4", "ADD_GUESTS 1", "BILL" };
            var obj = new WaterFacade(_billManager.Object);

            //Act
            var result = obj.CalculateTotalBill(commands);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CalculateTotalBill_InvalidInput_ThrowsException()
        {
            //Arrange
            var expected = new Result()
            {
                TotalCost = 100,
                TotalWater = 100
            };
            //_billManager.Setup(x => x.GetTotalBill(It.IsAny<string>(), It.IsAny<List<string>>())).Returns(expected);
            var commands = new string[] { "NO_WATER 3 2:1" };
            var obj = new WaterFacade(_billManager.Object);

            //Assert
            Assert.Throws<Exception>(() => obj.CalculateTotalBill(commands));
        }

    }
}
