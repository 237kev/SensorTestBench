using SensorTestBench.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensorTestBench.ViewModels
{
    internal class MainViewModel
    {
        // variable de champs
        private string sensorTyp = "";
        private double temperaturRef;
        private double measuredResistanceValue;
        private TestResult? lastTestResult;
        private double tolerance;


        // les proprietés
        public string SensorTyp
        {
            get { return sensorTyp; }
            set { sensorTyp = value; }
        }
        public double TemperaturRef
        {
            get { return temperaturRef; }
            set {  temperaturRef = value; }
        }
        public double MeasuredResistance
        {
            get { return measuredResistanceValue; }
            set { measuredResistanceValue = value; }
        }
        public TestResult? LastTestResult
        {
            get { return lastTestResult; }
            set { lastTestResult = value; }
        }
        public double Tolerance
        {
            get { return tolerance; }
            set { tolerance = value; }
        }


    }
}
