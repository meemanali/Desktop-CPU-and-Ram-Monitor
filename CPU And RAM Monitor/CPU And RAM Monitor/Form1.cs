using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace CPU_And_RAM_Monitor
{
    public partial class Form1 : Form
    {
        // we can also use coding way to create performance counter rather than from toolbox : 
        //PerformanceCounter perfcpucounter = new PerformanceCounter("Memory", "Available MBytes");
        public Form1()
        {
            InitializeComponent();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int intcpu = (int)pCPU.NextValue();
            int intram = (int)pRam.NextValue();

            progbarcpu.Value = intcpu;
            progbarram.Value = intram;

            lblcpu.Text = intcpu.ToString() + "%";            
            lblram.Text = intram.ToString() + "%";
            lblraminmb.Text = pRamInMB.NextValue() + " " + "MB";

            //lblcpu.Text = string.Format("{0:0.00%}", fcpu);
            //lblram.Text = string.Format("{0:0.00%}", fram);

            chart1.Series["CPU"].Points.AddY(intcpu);
            chart1.Series["RAM"].Points.AddY(intram);

            //lblcpu.Text = pRam.RawValue.ToString();//prints a very large number
        }
    }
}
