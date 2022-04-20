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
    public class WaterManagerTests
    {
        private Mock<ILogger> _logger;
        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();
            MyLogger.Log = _logger.Object;
        }

        [Test]
        public void GetWaterUsed_ProperResponse()
        {
            //Arrange
            var people = new People()
            {
                GuestCount = 5,
                PeopleCount = 5,
            };
            var ratio = new Ratio()
            {
                Corporation = 2,
                Borewell = 3
            };
            var water = new Water()
            {
                CorporationWater = 600,
                BorewellWater = 900,
                TankerWater = 1500
            };
            var obj = new WaterManager();

            //Act
            var result = obj.GetWaterUsed(people,ratio);

            //Assert
            Assert.AreEqual(water.CorporationWater, result.CorporationWater);
            Assert.AreEqual(water.BorewellWater, result.BorewellWater);
        }

        [Test]
        public void GetWaterUsed_ThrowsExceptionDivideByZero()
        {
            var people = new People()
            {
                GuestCount = 5,
                PeopleCount = 5,
            };
            var ratio = new Ratio()
            {
                Corporation = -1,
                Borewell = 1
            };
            var water = new Water()
            {
                CorporationWater = 600,
                BorewellWater = 900,
                TankerWater = 1500
            };
            var obj = new WaterManager();


            //Assert
            Assert.Throws<DivideByZeroException>(() => obj.GetWaterUsed(people, ratio));

        }
      
    }
}
