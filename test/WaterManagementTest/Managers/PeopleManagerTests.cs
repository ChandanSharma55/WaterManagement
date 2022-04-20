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
    public class PeopleManagerTests
    {
        private Mock<ILogger> _logger;
        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();
            MyLogger.Log = _logger.Object;
        }

        [Test]
        [TestCase(2,3)]
        [TestCase(3,5)]
        public void GetPeopleAndGuests_ProperResponse(int roomType,int peopleCount)
        {
            //Arrange
            var expected = new People()
            {
                GuestCount = 5,
                PeopleCount = peopleCount,
            };
            var allocateCommand = "ALLOT_WATER "+roomType+" 2:1";
            var guestCommands = new List<string> { "ADD_GUESTS 4", "ADD_GUESTS 1" };
            var obj = new PeopleManager();

            //Act
            var result = obj.GetPeopleAndGuests(allocateCommand, guestCommands);

            //Assert
            Assert.AreEqual(expected.PeopleCount, result.PeopleCount);
            Assert.AreEqual(expected.GuestCount, result.GuestCount);
        }

        [Test]
        public void GetPeopleAndGuests_ThrowsExceptionFromGetPeople()
        {
            //Arrange
            var expected = new People()
            {
                GuestCount = 5,
                PeopleCount = 5,
            };
            var allocateCommand = "ALLOT_WATER C 2:1";
            var guestCommands = new List<string> { "ADD_GUESTS 4", "ADD_GUESTS 1" };
            var obj = new PeopleManager();

            //Assert
            Assert.Throws<FormatException>(() => obj.GetPeopleAndGuests(allocateCommand,guestCommands));

        }
        [Test]
        public void GetPeopleAndGuests_ThrowsExceptionFromGetGuests()
        {
            //Arrange
            var expected = new People()
            {
                GuestCount = 5,
                PeopleCount = 5,
            };
            var allocateCommand = "ALLOT_WATER 3 2:1";
            var guestCommands = new List<string> { "ADD_GUESTS X"};
            var obj = new PeopleManager();

            //Assert
            Assert.Throws<FormatException>(() => obj.GetPeopleAndGuests(allocateCommand, guestCommands));

        }
    }
}
