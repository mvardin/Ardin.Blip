using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ardin.Blip
{
    public partial class Form1 : Form
    {
        Timer _timer;
        public Form1()
        {
            InitializeComponent();
            _timer = new Timer();
            _timer.Tick += _timer_Tick;
            notifyIcon1.Visible = false;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(1000, DateTime.Now.ToString("HH:mm:ss"), "Ardin Blip", ToolTipIcon.Info);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                btnStart.Text = "Stop";
                _timer.Interval = (int)txtInterval.Value * 1000;
                _timer.Start();
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000, "I'm here :)", "Ardin Blip", ToolTipIcon.Info);
            }
            else
            {
                btnStart.Text = "Start";
                _timer.Stop();
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
