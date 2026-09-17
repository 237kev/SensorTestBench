using System;
using System.Collections.Generic;
using System.Text;


namespace SensorTestBench.Services
{
    public class TestServices
    {
        const double ResRefInOhm = 100;
        const double CoefficientA = 0.0039083;
        const double CoefficientB = -0.0000005775;

        public double ComputeResistance(double tem)
        {
            return ResRefInOhm * (1 + CoefficientA * tem + CoefficientB * tem * tem);
        }


        public bool MeasuredResistanceIsOk(double expecetedResistance, double measuredResistance, double tolerance )
        {
            double deltaRes = Math.Abs(expecetedResistance - measuredResistance);
            if (deltaRes <= tolerance)
            {
                return true;
            }
            return false;

        }


    }
}
