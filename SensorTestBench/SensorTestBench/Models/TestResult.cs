using System;
using System.Collections.Generic;
using System.Text;

namespace SensorTestBench.Models
{
    internal class TestResult
    {

        // Field variables in camelCase
        private int testID;
        private string sensorTyp ="";
        private double temRef;
        private double resSoll;
        private double resIst;
        private double deltaR;
        private bool testBestanden;
        private DateTime getestetAm;
        private double tolerance;

        // Property variables in PascalCase

        public double Tolerance
        {
            get { return tolerance; }
            set { tolerance = value; }     
        }
        public int TestID
        {
            get
            {
                return testID;
            }
            set
            {
                testID = value;
            }
        }

        public string SensorTyp
        {
            get
            {
                return sensorTyp;
            }
            set
            {
                sensorTyp = value;
            }
        }


        public double TemRef
        {
            get
            {
                return temRef;
            }
            set
            {
                temRef = value;
            }
        }
        public double ResSoll
        {
            get
            {
                return resSoll;
            }
            set
            {
                resSoll = value;
            }
        }
        public double ResIst
        {
            get
            {
                return resIst;
            }
            set
            {
                resIst = value;
            }
        }
        public bool TestBestanden
        {
            get
            {
                return testBestanden;
            }
            set
            {
                testBestanden = value;
            }
        }

        public DateTime GetestetAm
        {
            get
            {
                return getestetAm;
            }
            set
            {
                getestetAm = value;
            }
        }
        public double DeltaR
        {
            get
            {
                return deltaR;
            }
            set
            {
                deltaR = value;
            }
        }


    }
}
