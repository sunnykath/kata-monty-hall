using System;
using System.IO;
using MontyHallKata.Models.Randomizer;
using MontyHallKata.Views;
using Xunit;

namespace MontyHallTests
{
    public class MontyHallViewTests
    {
        private MontyHallView _montyHallView;
        private CustomRandomizer _randomizer;

        public MontyHallViewTests()
        {
            _montyHallView = new MontyHallView();
            _randomizer = new CustomRandomizer();
        }
        
        [Fact]
        public void GivenAMontyHallView_WhenPlayIsCalled_ThenShouldDisplayTheThreeDoorsToSelectFrom()
        {
            // Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            const string expectedOutput = "#Door 1#\t#Closed#\n" +
                                          "#Door 2#\t#Closed#\n" +
                                          "#Door 3#\t#Closed#\n";
            
            // Act
            _montyHallView.Play(_randomizer);

            // Assert
            Assert.Contains(expectedOutput, stringWriter.ToString());
        }

        [Fact]
        public void GivenAMontyHallView_WhenPlayIsCalledOnce_ThenTheUserShouldBeAbleToQuitTheGameByInputtingQ()
        {
            // Arrange
            var stringReader = new StringReader("q");
            var stringWriter = new StringWriter();
            
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);

            var expectedQuitMessage = "You have Quit the game.\n";
            
            // Act
            _montyHallView.Play(_randomizer);
            
            // Assert
            Assert.Contains(expectedQuitMessage, stringWriter.ToString());
        }
        
    }
}