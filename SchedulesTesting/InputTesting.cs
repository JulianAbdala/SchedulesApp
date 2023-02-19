using NUnit.Framework;
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

            //Act
            var result = InputParser.ParseDayOfWeek(day);

            //Assert
            Assert.AreEqual(expectedOutput, result);
        }
    }

}


