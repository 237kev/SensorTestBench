using SensorTestBench.Models;
using SensorTestBench.Services;
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
        public double MeasuredResistanceValue
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

        public void Run()
        {
            
            TestServices testService = new TestServices(); // je veux utiliser les methodes de la classe TestServices pour les tests de calcul
            TestResult testResult = new TestResult(); // je veux stocker les valeurs issues des tests de calcul dans notre objet metier (object de la classe testResult)

            // toutes les valeurs de variable du MainViewModel a stocker dans la base de données sont passées aux variable de testResult


            testResult.ResIst = MeasuredResistanceValue;
            testResult.SensorTyp = SensorTyp;
            testResult.TemRef = TemperaturRef;
            testResult.DeltaR = Math.Abs (testResult.ResSoll - testResult.ResIst);
            testResult.GetestetAm = DateTime.Now;
            testResult.Tolerance = Tolerance;

            testResult.ResSoll = testService.ComputeResistance(TemperaturRef); // calcule de la valeur theorique de la resistance dans le TestService et stockage dans une variable l'objet result
            testResult.TestBestanden = testService.MeasuredResistanceIsOk(testResult.ResSoll, MeasuredResistanceValue, Tolerance); // Stockage du resultat du test dans une variable de l'objet result

            LastTestResult = testResult; // le MainViewModel stocke l'objet de testResult (entierement)
        }
    }
}
