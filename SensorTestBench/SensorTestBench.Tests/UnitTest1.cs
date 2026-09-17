using SensorTestBench.Services;

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


    }
}
