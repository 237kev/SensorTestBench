using SensorTestBench.Models;
using SensorTestBench.Services;
using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Documents; // ici je veux utiliser l'interface INotifyPropertyChanged pour notifier la View de tout changement de valeur dans le Viewmodel

namespace SensorTestBench.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged // MainViewModel herite/(implemente) de la classe (Interface) INotifyPropertyChanged.
    {
        // variable de champs
        private string sensorTyp = "";
        private double temperaturRef;
        private double measuredResistanceValue;
        private TestResult? lastTestResult;
        private double tolerance;
        private double resSoll;

        // les proprietés
        public ICommand RunCommand { get; }
        public ICommand LoadConfigurationCommand { get; }
        public ICommand SaveResultCommand { get; }



        public string SensorTyp
        {
            get { return sensorTyp; }
            set { 
                    if (sensorTyp != value)
                    {
                        sensorTyp = value;
                        OnPropertyChanged(nameof(SensorTyp)); // Notifie la View que la propriété SensorTyp a changé
                    }
                    
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
                if(resSoll != value)
                {
                     resSoll = value;
                    OnPropertyChanged(nameof(ResSoll));
                }

            }
        }
        public double TemperaturRef
        {
            get { return temperaturRef; }
            set {  
                    if(temperaturRef != value)
                    {
                        temperaturRef = value;
                        OnPropertyChanged(nameof(TemperaturRef)); // Notifie la View que la propriété TemperaturRef a changé
                    }

                }
        }
        public double MeasuredResistanceValue
        {
            get { return measuredResistanceValue; }
            set { 
                    if(measuredResistanceValue != value)
                    {
                        measuredResistanceValue = value;
                        OnPropertyChanged(nameof(MeasuredResistanceValue)); // Notifie la View que la propriété MeasuredResistanceValue a changé
                    }
                        
                }
        }


        public double Tolerance
        {
            get { return tolerance; }
            set { 
                    if(tolerance != value)
                    {
                        tolerance = value;
                        OnPropertyChanged(nameof(Tolerance)); // Notifie la View que la propriété Tolerance a changé
                    }
                }
        }
        public TestResult? LastTestResult
        {
            get { return lastTestResult; }
            set { 
                    if(lastTestResult != value)
                    {
                        lastTestResult = value;
                        OnPropertyChanged(nameof(LastTestResult)); // Notifie la View que la propriété LastTestResult a changé
                        OnPropertyChanged(nameof(ResultText));
                    }
                }
        }
        public string ResultText
        {
            get
            {
                if (LastTestResult == null)
                {
                    return "";
                }

                if (LastTestResult.TestBestanden)
                {
                    return "OK";
                }
                else
                {
                    return "NOK";
                }
            }
        }

        // Konstruktor: Initialisierungen, die Instanzmethoden benötigen, hier ausführen
        public MainViewModel()
        {
            // CanExecute immer true (B): übergibt eine Func<bool>
            RunCommand = new RelayCommand(Run, () => true);
            LoadConfigurationCommand = new RelayCommand(LoadConfiguration, () => true);
            SaveResultCommand = new RelayCommand(SaveResult, () => true);
        }
        public void Run()
        {

            TestServices testService = new TestServices(); // je veux utiliser les methodes de la classe TestServices pour les tests de calcul
            TestResult testResult = new TestResult(); // je veux stocker les valeurs issues des tests de calcul dans notre objet metier (object de la classe testResult)
            // toutes les valeurs de variable du MainViewModel a stocker dans la base de données sont passées aux variable de testResult


            testResult.ResIst = MeasuredResistanceValue;
            testResult.SensorTyp = SensorTyp;
            testResult.TemRef = TemperaturRef;

            testResult.GetestetAm = DateTime.Now; 
            testResult.Tolerance = Tolerance;


            testResult.ResSoll = ResSoll; 
            testResult.DeltaR = Math.Abs(testResult.ResSoll - testResult.ResIst);
            testResult.TestBestanden = testService.MeasuredResistanceIsOk(testResult.ResSoll, MeasuredResistanceValue, Tolerance); // Stockage du resultat du test dans une variable de l'objet result
            LastTestResult = testResult; // le MainViewModel stocke l'objet de testResult (entierement)

        }
        public void LoadConfiguration()
        {
            if (SensorTyp == "PT100")
            {
                TemperaturRef = 100;
                Tolerance = 0.1;
                ResSoll = 138.5;
            }
            if (SensorTyp == "NTC")
            {
                TemperaturRef = 0;
                Tolerance = 0.15;
                ResSoll = 60;
            }
        }
        public void SaveResult()
        {

        }


        // Event de notification de changement de valeur
        public event PropertyChangedEventHandler? PropertyChanged;
    
        //je crée la methode qui va notifier la View du changement de la valeurs de la propriétéd du MainViewModel
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        // Einfache RelayCommand-Implementierung
        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool>? _canExecute;

            public RelayCommand(Action execute, Func<bool>? canExecute)
            {
                this._execute = execute;
                this._canExecute = canExecute;
                    
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                if(_canExecute == null)
                {
                    return true;
                }
                else return _canExecute();
            }

            public void Execute(object? parameter)
            {
                _execute();
            }
        }
    }
}
