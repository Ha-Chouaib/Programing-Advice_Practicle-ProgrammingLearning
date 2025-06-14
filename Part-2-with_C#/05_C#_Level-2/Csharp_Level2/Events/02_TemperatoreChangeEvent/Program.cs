using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatoreChangeEvent
{
    public class TemperatorChangeEventArgs : EventArgs
    {
        public double CurrentTemprature { get;}
        public double OldTemperature { get; }
        public double Difference { get; }

        public TemperatorChangeEventArgs(double CurrentTemprature, double OldTemperator)
        {
            this.CurrentTemprature = CurrentTemprature;
            this.OldTemperature = OldTemperator;
            this.Difference = CurrentTemprature - OldTemperator;
        }
    }

    public class Thermostat
    {
        public event EventHandler<TemperatorChangeEventArgs> TempratureChanged;

        private double OldTemprature, CurrentTeprature;

        public void SetTemprature(double Temprature)
        {
            if (Temprature != CurrentTeprature)
            {
                OldTemprature = CurrentTeprature;
                CurrentTeprature = Temprature;

                OnTemperatureChanged(CurrentTeprature, OldTemprature);
            }
        }
        private void OnTemperatureChanged(double CurrentTemprature, double OldTempratue)
        {
            OnTemperatureChanged(new TemperatorChangeEventArgs(CurrentTemprature, OldTempratue));
        }

        protected virtual void OnTemperatureChanged(TemperatorChangeEventArgs e)
        {
            TempratureChanged?.Invoke(this, e);
        }

    }

    public class Display
    {
        public void Subscribe(Thermostat thermostat)
        {
            thermostat.TempratureChanged += TemperatorChangeHandler;
        }

        public void TemperatorChangeHandler(object sender, TemperatorChangeEventArgs e)
        {
            Console.WriteLine("Temperatue Changes\n\n");
            Console.WriteLine($"Temperatue Changed From: << {e.OldTemperature} C >>\n");
            Console.WriteLine($"Temperatue Changed To: << {e.CurrentTemprature} C >>\n");
            Console.WriteLine($"Temperatue Difference: < {e.Difference} C >\n");
        }
        public class Program 
        {
            public static void Main(string[] args)
            {
                Thermostat thermostat = new Thermostat();
                Display display = new Display();

                display.Subscribe(thermostat);

                thermostat.SetTemprature(32);
                thermostat.SetTemprature(2);

                Console.ReadLine();
            }
        }
    }
}
