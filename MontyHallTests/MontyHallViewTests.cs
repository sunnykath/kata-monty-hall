using System;
using System.IO;
using MontyHallKata.Models.Randomizer;
using MontyHallKata.Views;
using Xunit;

namespace MontyHallTests
{
    public class MontyHallViewTests
    {

        [Fact]
        public void GivenAMontyHallView_WhenPlayIsCalled_ThenShouldDisplayTheThreeDoorsToSelectFrom()
        {
            // Arrange
            var montyHallView = new MontyHallView();
            var randomizer = new CustomRandomizer();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            const string expectedOutput = "#Door 1#\t#Closed#\n" +
                                          "#Door 2#\t#Closed#\n" +
                                          "#Door 3#\t#Closed#\n";
            
            // Act
            montyHallView.Play(randomizer);

            // Assert
            Assert.Contains(expectedOutput, stringWriter.ToString());
        }
        
    }
}