using System;
using System.Collections.Generic;
using System.Text;

namespace SensorTestBench.Models
{
    internal class SensorConfig
    {
        // variable de champs
        private string sensorTyp = "";
        private double temperaturRef;
        private double tolerance;
        private double expectedResistance;
        private int sensorConfigID;

        // proprieté
        public string SensorTyp
        {
            set { sensorTyp = value; }
            get { return sensorTyp; }
        }

        public double TemperaturRef
        {
            set { temperaturRef = value; }
            get { return temperaturRef; }
        }

        public double Tolerance
        {
            set { tolerance = value; }
            get { return tolerance; }
        }

        public double ExpectedResistance
        {
            set { expectedResistance = value; }
            get { return expectedResistance; }
        }
        public int SensorConfigID
        {
            get { return sensorConfigID; }
            set { sensorConfigID = value; }
        }
    }
}
