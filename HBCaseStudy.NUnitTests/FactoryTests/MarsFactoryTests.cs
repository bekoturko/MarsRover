using FluentAssertions;
using HBCaseStudy.Business.Factories;
using HBCaseStudy.Model;
using HBCaseStudy.Model.Entities;
using HBCaseStudy.NUnitTests.Helpers.Fixtures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HBCaseStudy.NUnitTests
{
    /// <summary>
    /// Birim testlerini isimlendirmede genel yaklaþým þudur: MetotAdý_Koþul_BeklenenDavranýþ
    /// Birden fazla koþul varsa ifadeler And kelimesi ile ayrýlýr.
    /// Koþul varsa: [MethodName]_[Condition(s)]_[Behaviour(s)]
    /// Koþul yoksa: [MethodName]_NoCondition_[Behaviour(s)]
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class MarsFactoryTests : BaseTestFixture
    {
        #region members & setup

        MarsFactory marsFactory;

        [SetUp]
        public void Initialize()
        {
            marsFactory = new MarsFactory();
        }

        #endregion

        #region verify mocks

        protected override void VerifyMocks()
        {
        }

        #endregion

        #region create plateau area

        [Test]
        [TestCase(5, 5)]
        [TestCase(3, 6)]
        [TestCase(2, 5)]
        public void CreatePlateauGridArea_NoConditionTestCases_ReturnList(int width, int height)
        {
            //Arrange
            var plateauArea = new List<int> { width, height };

            //Act
            var result = marsFactory.CreatePlateauRectangle(width, height);

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(plateauArea.Count);
            result.Should().BeEquivalentTo(plateauArea);
        }

        #endregion

        #region create rover

        [Test]
        [TestCase("Alpha", 1, 2, "N")]
        [TestCase("Bravo", 3, 3, "E")]
        public void CreateRover_NoConditionTestCases_ReturnRover(string roverName, int startPointHorizontal, int startPointVertical, string direction)
        {
            //Arrange
            var rover = new Rover
            {
                RoverName = roverName,
                Horizontal = startPointHorizontal,
                Vertical = startPointVertical,
                Direction = (Direction)Enum.Parse(typeof(Direction), direction)
            };

            //Act
            var result = marsFactory.CreateRover(roverName, startPointHorizontal, startPointVertical, direction);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(rover);
        }

        #endregion
    }
}