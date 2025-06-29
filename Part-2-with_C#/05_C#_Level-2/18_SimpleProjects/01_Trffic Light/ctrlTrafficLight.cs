using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _01_Trffic_Light.Properties;

namespace _01_Trffic_Light
{
    public partial class ctrlTrafficLight : UserControl
    {
        public ctrlTrafficLight()
        {
            InitializeComponent();
        }

        public enum enTrafficLight { Red,Orange,Green}
        private enTrafficLight _CurrentTrafficLight = enTrafficLight.Red;

        public class TraficLightEventArgs: EventArgs
        {
            public byte Duration { get; }
            public enTrafficLight TrafficLight { get; }

            public TraficLightEventArgs(enTrafficLight trafficLight, byte Duration)
            {
                this.Duration = Duration;
                this.TrafficLight = trafficLight;
            }
        }

        public event EventHandler<TraficLightEventArgs> OnRedLightOn;
        public void ReaseRedlightOn()
        {
            ReaseRedlightOn(new TraficLightEventArgs(enTrafficLight.Red, _RedTime));
        }
        protected virtual void ReaseRedlightOn(TraficLightEventArgs e)
        {
            OnRedLightOn?.Invoke(this, e);
        }


        public event EventHandler<TraficLightEventArgs> OnRedLightOff;
        public void ReaseRedlightOff()
        {
            ReaseRedlightOff(new TraficLightEventArgs(enTrafficLight.Orange, _OrangeTime));
        }
        protected virtual void ReaseRedlightOff( TraficLightEventArgs e)
        {
            OnRedLightOff?.Invoke(this, e);
        }


        public event EventHandler<TraficLightEventArgs> OnOrangeLightOn;
        public void ReaseOrangelightOn()
        {
            ReaseOrangelightOn(this, new TraficLightEventArgs(enTrafficLight.Orange, _OrangeTime));
        }
        protected virtual void ReaseOrangelightOn(object sender, TraficLightEventArgs e)
        {
            OnOrangeLightOn?.Invoke(sender, e);
        }
       

        public event EventHandler<TraficLightEventArgs> OnGreenLightOn;
        public void ReaseGreenlightOn()
        {
            ReaseGreenlightOn(new TraficLightEventArgs(enTrafficLight.Green, _GreenTime));
        }
        protected virtual void ReaseGreenlightOn( TraficLightEventArgs e)
        {
            OnGreenLightOn?.Invoke(this, e);
        }
        public event EventHandler<TraficLightEventArgs> OnGreenLightOff;
        public void ReaseGreenlightOff()
        {
            ReaseGreenlightOff(new TraficLightEventArgs(enTrafficLight.Orange, _OrangeTime));
        }
        protected virtual void ReaseGreenlightOff(TraficLightEventArgs e)
        {
            OnGreenLightOff?.Invoke(this, e);
        }

        private byte _RedTime=15;
        private byte _OrangeTime=7;
        private byte _GreenTime=15;

        private byte _CurrentLightDuration;
        public byte RedLightDuration { get { return _RedTime; } set { _RedTime = value; } }
        public byte OrangeLightDuration { get { return _OrangeTime; } set { _OrangeTime = value; } }
        public byte GreenLightDuration { get { return _GreenTime; } set { _GreenTime = value; } }

        public enTrafficLight CurrentTrafficLight
        {
            get
            {
                return _CurrentTrafficLight;
            }
            set
            {
                switch((_CurrentTrafficLight = value))
                {
                    case enTrafficLight.Red:
                        pictureBox2.Image = Resources.TrafficLight_Red;
                        lblLightDuration.ForeColor = Color.Red;
                        break;

                    case enTrafficLight.Orange:
                        pictureBox2.Image = Resources.Trafficligth_Orange;
                        lblLightDuration.ForeColor = Color.Orange;

                        break;

                    case enTrafficLight.Green:
                        pictureBox2.Image = Resources.TrafficLigth_Green;
                        lblLightDuration.ForeColor = Color.Green;

                        break;
                }
            }
        }

        private byte _GetLightDuration(enTrafficLight Light)
        {
            switch(Light)
            {
                case enTrafficLight.Red:
                    return RedLightDuration;
                case enTrafficLight.Orange:
                    return OrangeLightDuration;
                case enTrafficLight.Green:
                    return GreenLightDuration;
                default:
                    return 0;
            }
        }

        

        private void LightTimer_Tick(object sender, EventArgs e)
        {
            lblLightDuration.Text = _CurrentLightDuration.ToString();
            if (_CurrentLightDuration == 0)
            {
                _LightSwitchHandler();
            }else
            {
                -- _CurrentLightDuration;
            }
        }

        public void __Start()
        {
            _CurrentLightDuration = _GetLightDuration(_CurrentTrafficLight);
            LightTimer.Start();
        }
        public void __Stop()
        {
            _CurrentLightDuration = 0;
            lblLightDuration.Text = _CurrentLightDuration.ToString();
            LightTimer.Stop();
        }

        private enTrafficLight _LightNextOrangelight;
        private void _LightSwitchHandler()
        {
             switch(_CurrentTrafficLight)
            {
                case enTrafficLight.Red:
                    CurrentTrafficLight = enTrafficLight.Orange;
                    _LightNextOrangelight = enTrafficLight.Green;
                    lblLightDuration.Text = _CurrentLightDuration.ToString();
                    ReaseOrangelightOn();
                    break;

                case enTrafficLight.Orange:

                   if(_LightNextOrangelight == enTrafficLight.Red)
                   {
                        CurrentTrafficLight = enTrafficLight.Red;
                        lblLightDuration.Text = _CurrentLightDuration.ToString();

                        ReaseRedlightOn();
                   }
                   else
                   {
                        CurrentTrafficLight = enTrafficLight.Green;
                        lblLightDuration.Text = _CurrentLightDuration.ToString();
                        ReaseGreenlightOn();
                    }
                        break;
                case enTrafficLight.Green:
                    CurrentTrafficLight = enTrafficLight.Orange;
                    _LightNextOrangelight = enTrafficLight.Red;
                    lblLightDuration.Text = _CurrentLightDuration.ToString();
                    ReaseOrangelightOn();
                    break;
            }

            _CurrentLightDuration = _GetLightDuration(_CurrentTrafficLight);
        }
    }
}
