using NUnit.Framework;
using SchedulesApp.Classes.OverlapLogic;
using SchedulesApp.Classes.ParsingLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulesTesting
{

    [TestFixture]
    public class InputTesting 
    {
        [Test]
        public void TestReadInput()
        {
            // Arrange
            InputParser InputParser = new InputParser();

            // Act
            //El testinput.txt debe estar en la carpeta de testing
            var result = InputParser.ReadInput("TestInput.txt");
        }
        [Test]
        public void TestParseDayOfWeek()
        {
            //Arrange
            InputParser InputParser = new InputParser();
            string day = "MO";

            var expectedOutput = DayOfWeek.Monday;
            var notExpectedOutput = DayOfWeek.Tuesday;

            //Act
            var result = InputParser.ParseDayOfWeek(day);

            //Assert
            Assert.AreEqual(expectedOutput, result);
            Assert.AreNotEqual(notExpectedOutput, result);
        }
    }



    [TestFixture]
    public class OverlapHandlerTests
    {
        private OverlapHandler overlapHandler1;
        private OverlapHandler overlapHandler2;
        private OverlapHandler overlapHandler3;
        private OverlapHandler overlapHandler4;

        [SetUp]
        public void Setup()
        {
            overlapHandler1 = new OverlapHandler(DayOfWeek.Monday, DateTime.Parse("09:00"), DateTime.Parse("12:00"));
            overlapHandler2 = new OverlapHandler(DayOfWeek.Monday, DateTime.Parse("10:00"), DateTime.Parse("13:00"));
            overlapHandler3 = new OverlapHandler(DayOfWeek.Wednesday, DateTime.Parse("09:00"), DateTime.Parse("12:00"));
            overlapHandler4 = new OverlapHandler(DayOfWeek.Wednesday, DateTime.Parse("13:00"), DateTime.Parse("15:00"));
        }

        [Test]
        public void TestCheckOverlap_Exists()
        {
            // Act
            var overlap = overlapHandler1.CheckOverlap(overlapHandler2);

            // Assert
            Assert.That(overlap, Is.EqualTo(TimeSpan.FromHours(2)));
        }
        [Test]
        public void TestCheckOverlap_NotExists()
        {
            // Act
            var noOverlap = overlapHandler3.CheckOverlap(overlapHandler4);

            // Assert
            Assert.That(noOverlap, Is.EqualTo(TimeSpan.FromHours(0)));
        }



    }



}