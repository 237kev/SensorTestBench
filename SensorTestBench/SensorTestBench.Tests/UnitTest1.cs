using SensorTestBench.Services;
using SensorTestBench.ViewModels;
using SensorTestBench.Models;

namespace SensorTestBench.Tests
{
    public class UnitTest1
    {
        [Fact]
        //  je test la fonction ComputeResistance avec en entrée 0° et à la sortie 100 ohm 
        public void TestComputeResistanceAt0DegreesReturns100Ohms()
        {
            // arrange
            TestServices tS = new TestServices();
            double tem0 = 0.0;
            double expectedResult = 100.0;
            //act
            double computedResult = tS.ComputeResistance(tem0);
            //assert
            Assert.Equal(expectedResult, computedResult);

        }
        [Fact]
        public void TestComputeResistanceAt100DegreesReturns138Dot5055Ohms()
        {
            // arrange
            TestServices tS = new TestServices();
            double entryTemperature = 100.0;
            double expectedResult = 138.5055;
            //act
            double computedResult = tS.ComputeResistance(entryTemperature);
            //assert
            Assert.Equal(expectedResult, computedResult, 4);

        }
        [Fact]
        public void TestMeasuredResistanceIsOk()
        {
            // arrage
            double expecetedResistance = 100.0;
            double measuredResistance = 102.36;
            double tolerance = 3.1;
            bool expectedResult = true;
            TestServices tS = new TestServices();
            //act
            bool result = tS.MeasuredResistanceIsOk(expecetedResistance, measuredResistance, tolerance);

            Assert.Equal(expectedResult,result);
        }

        [Fact]
        public void TestMeasuredResistanceIsOk2()
        {
            // arrage
            double expecetedResistance = 100.0;
            double measuredResistance = 105.36;
            double tolerance = 2.1;
            bool expectedResult = false;
            TestServices tS = new TestServices();
            //act
            bool result = tS.MeasuredResistanceIsOk(expecetedResistance, measuredResistance, tolerance);

            Assert.Equal(expectedResult,result);
        }
        [Fact]
        public void TestMainViewModel()
        {
            // Arrange
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.SensorTyp = "PT100";
            mainViewModel.TemperaturRef = 100.0;
            mainViewModel.MeasuredResistanceValue = 138.4752; // Ist
            double expectedResistance = 138.5055;           //soll
            double expectedDelta = Math.Abs(expectedResistance - mainViewModel.MeasuredResistanceValue);
            mainViewModel.Tolerance = 0.1;

            // Act
            mainViewModel.Run();

            // Assert
            Assert.NotNull(mainViewModel.LastTestResult);
            Assert.Equal(mainViewModel.SensorTyp, mainViewModel.LastTestResult.SensorTyp);
            Assert.Equal(mainViewModel.TemperaturRef, mainViewModel.LastTestResult.TemRef,4);
            Assert.Equal(mainViewModel.MeasuredResistanceValue, mainViewModel.LastTestResult.ResIst,4);
            Assert.Equal(expectedResistance, mainViewModel.LastTestResult.ResSoll,4);
            Assert.Equal(expectedDelta, mainViewModel.LastTestResult.DeltaR,4);
            Assert.True(mainViewModel.LastTestResult.TestBestanden);
            Assert.Equal(mainViewModel.Tolerance, mainViewModel.LastTestResult.Tolerance);
        }

        [Fact]
        public void TestMainViewModelPropertiesChanged()
        {
            // Arrange
            MainViewModel mainViewModel = new MainViewModel();
            bool sensorTypChanged = false;
            bool temperaturRefChanged = false;
            bool measuredResistanceValueChanged = false;
            bool toleranceChanged = false;
            mainViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(MainViewModel.SensorTyp))
                    sensorTypChanged = true;
                if (e.PropertyName == nameof(MainViewModel.TemperaturRef))
                    temperaturRefChanged = true;
                if (e.PropertyName == nameof(MainViewModel.MeasuredResistanceValue))
                    measuredResistanceValueChanged = true;
                if (e.PropertyName == nameof(MainViewModel.Tolerance))
                    toleranceChanged = true;
            };
            // Act
            mainViewModel.SensorTyp = "PT100";
            mainViewModel.TemperaturRef = 100.0;
            mainViewModel.MeasuredResistanceValue = 138.4752;
            mainViewModel.Tolerance = 0.1;
            // Assert
            Assert.True(sensorTypChanged);
            Assert.True(temperaturRefChanged);
            Assert.True(measuredResistanceValueChanged);
            Assert.True(toleranceChanged);
        }

        [Fact]
        public void TestMainViewModelPropertychangedNotTriggeredWhenValueIsSame()
        {
            // Arrange
            MainViewModel mainViewModel = new MainViewModel();
            bool sensorTypChanged = false;
            mainViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(MainViewModel.SensorTyp))
                    sensorTypChanged = true;
            };
            // Act
            mainViewModel.SensorTyp = "PT100"; // First change, should trigger PropertyChanged
            sensorTypChanged = false; // Reset for the next test
            mainViewModel.SensorTyp = "PT100"; // Same value, should not trigger PropertyChanged
            // Assert
            Assert.False(sensorTypChanged);
        }


    }
}
