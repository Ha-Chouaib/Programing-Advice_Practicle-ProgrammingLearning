using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_Pool_Club
{
    public partial class ctrlPoolClub : UserControl
    {
        public ctrlPoolClub()
        {
            InitializeComponent();
        }

        public class TableEventArgs : EventArgs
        {
            public string TableName { get; }
            public string PlayerName { get; }
            public string TimeConsumed { get; }
            public int TotalSeconds { get; }
            public float HourlyRate { get; }
            public float TotalFees { get; }

            public TableEventArgs(string TableName, string PlayerName, string TimeConsumed, int TotalSeconds,float HourlyRate, float TotalFees)
            {
                this.TableName = TableName;
                this.PlayerName = PlayerName;
                this.TimeConsumed = TimeConsumed;
                this.TotalSeconds = TotalSeconds;
                this.HourlyRate = HourlyRate;
                this.TotalFees = TotalFees;
            }
        }

        public event EventHandler<TableEventArgs> TableComplated;
        public void ReaseOnTableComplated(string TableName, string PlayerName, string TimeConsumed, int TotalSeconds, float HourlyRate, float TotalFees)
        {
            ReaseOnTableComplated(this, new TableEventArgs(TableName, PlayerName, TimeConsumed, TotalSeconds, HourlyRate, TotalFees));
        }
        protected virtual void ReaseOnTableComplated(object sender,TableEventArgs e)
        {
            TableComplated?.Invoke(sender, e);
        }
        private string _TableName = "Table";

        private string _PlayerName= "Player";

        private float _HourlyRate = 15;

        private TimeSpan _ElapsedTime = new TimeSpan();
        private StringBuilder _sbClockTimer = new StringBuilder();

        enum enPlayState { eStart, ePause}
        enPlayState _PlayState = enPlayState.eStart;

        [ Category("Pool Config"), Description("The Table Title") ]
        public string TableName { get { return _TableName; } set { _TableName = value; gbTable.Text = _TableName; } }

        [ Category("Pool Config"), Description("The Player Name") ]
        public string PlyerName { get { return _PlayerName; } set { _PlayerName = value; lblPlayerName.Text = _PlayerName; } }

        [ Category("Pool Config"), Description("Payment Per Hour") ]
        public float HourlyRate { get { return _HourlyRate;} set { _HourlyRate = value; } }

        private void _ClockTimer()
        {
            _ElapsedTime =_ElapsedTime.Add(TimeSpan.FromSeconds(1));

            _sbClockTimer.Clear();
            _sbClockTimer.Append(_ElapsedTime.Hours.ToString("D2")).Append(":");
            _sbClockTimer.Append(_ElapsedTime.Minutes.ToString("D2")).Append(":");
            _sbClockTimer.Append(_ElapsedTime.Seconds.ToString("D2"));

            lblTimer.Text = _sbClockTimer.ToString();
        }

        private void TableTimer_Tick(object sender, EventArgs e)
        {
            _ClockTimer();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            switch(_PlayState)
            {
                case enPlayState.eStart:
                    _PlayState = enPlayState.ePause;
                    btnStartStop.Text = "Pause";
                    btnStartStop.ForeColor = Color.Wheat;
                    TableTimer.Stop();

                    break;
                case enPlayState.ePause:
                    _PlayState = enPlayState.eStart;
                    btnStartStop.Text = "Start";
                    btnStartStop.ForeColor = Color.Lime;
                    TableTimer.Start();
                    break;
            }

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            TableTimer.Stop();

            ReaseOnTableComplated(_TableName, _PlayerName, _sbClockTimer.ToString(), (int)_ElapsedTime.TotalSeconds, _HourlyRate, (float)(_HourlyRate * (_ElapsedTime.TotalSeconds / 3600)));
            btnStartStop.Text = "Start";
            btnStartStop.ForeColor = Color.Lime;
            lblTimer.Text = "00:00:00";
            _ElapsedTime = TimeSpan.Zero;
            _sbClockTimer.Clear();
            _PlayState = enPlayState.eStart;
           
        }
    }
}
