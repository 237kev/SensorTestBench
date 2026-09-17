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

        // valeur theorique attendue (expected)
        public double ComputeResistance(double tem)
        {
            return ResRefInOhm * (1 + CoefficientA * tem + CoefficientB * tem * tem);
        }

        // compare la valeur attendue de la resistance (theorique) a la valeur mesurée (pratique) soit par le technicien soit par arduino
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
