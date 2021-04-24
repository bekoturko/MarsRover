using FluentAssertions;
using HBCaseStudy.Business.Abstract.Factories;
using HBCaseStudy.Business.Abstract.Services;
using HBCaseStudy.Business.Services;
using HBCaseStudy.Model;
using HBCaseStudy.Model.Entities;
using HBCaseStudy.NUnitTests.Helpers.Fixtures;
using HBCaseStudy.NUnitTests.Helpers.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HBCaseStudy.NUnitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class RoverServiceTests : BaseTestFixture
    {
        #region members & setup

        StrictMock<IMarsFactory> marsFactory;

        StrictMock<ILoggingService> logger;

        RoverService roverService;

        [SetUp]
        public void Initialize()
        {
            marsFactory = new StrictMock<IMarsFactory>();
            logger = new StrictMock<ILoggingService>();

            roverService = new RoverService(marsFactory.Object, logger.Object);
        }

        #endregion

        #region verify mocks

        protected override void VerifyMocks()
        {
            marsFactory.VerifyAll();
            logger.VerifyAll();
        }

        #endregion

        #region start runing robotic rover

        [Test]
        [TestCase("Alpha", 1, 2, "N", "LMLMLMLMM", "1 3 N")]
        [TestCase("Bravo", 3, 3, "E", "MMRMMRMRRM", "5 1 E")]
        public void Run_NoConditionTestCases_ReturnExpectedResult(string roverName, int startPointHorizontal, int startPointVertical, string direction, string destinationCommands, string expectedResult)
        {
            //Arrange
            var plateauArea = new List<int> { 5, 5 };
            var rover = new Rover
            {
                RoverName = roverName,
                Horizontal = startPointHorizontal,
                Vertical = startPointVertical,
                Direction = (Direction)Enum.Parse(typeof(Direction), direction)
            };

            logger.Setup(x => x.LogInformation(SetupAny<string>(), SetupAny<string>())).Verifiable();
            marsFactory.Setup(x => x.CreatePlateauRectangle(5, 5)).Returns(plateauArea);
            marsFactory.Setup(x => x.CreateRover(roverName, startPointHorizontal, startPointVertical, direction)).Returns(rover);
            logger.Setup(x => x.LogInformation(SetupAny<string>(), SetupAny<string>())).Verifiable();

            //Act
            roverService.Run(roverName, startPointHorizontal, startPointVertical, direction, destinationCommands);

            //Assert
            rover.LocationInfo.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Run_CommandPositionOutOfRange_ThrowIndexOutOfRangeException()
        {
            //Arrange
            var roverName = "robotic rover";
            var startPointHorizontal = 0;
            var startPointVertical = 0;
            var startDirection = "N";
            var destinationCommands = "MMMMMM";
            var plateauArea = new List<int> { 5, 5 };
            var rover = new Rover
            {
                RoverName = roverName,
                Horizontal = startPointHorizontal,
                Vertical = startPointVertical,
                Direction = (Direction)Enum.Parse(typeof(Direction), startDirection)
            };

            logger.Setup(x => x.LogInformation(SetupAny<string>(), SetupAny<string>())).Verifiable();
            marsFactory.Setup(x => x.CreatePlateauRectangle(5, 5)).Returns(plateauArea);
            marsFactory.Setup(x => x.CreateRover(roverName, startPointHorizontal, startPointVertical, startDirection)).Returns(rover);

            //Act
            roverService.Invoking(x => x.Run(roverName, startPointHorizontal, startPointVertical, startDirection, destinationCommands)).Should().Throw<IndexOutOfRangeException>();

            //Assert
        }

        #endregion
    }
}