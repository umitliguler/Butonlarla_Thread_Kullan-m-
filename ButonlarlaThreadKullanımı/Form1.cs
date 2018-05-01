using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ButonlarlaThreadKullanımı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        Thread th01;
        Thread th02;



        private void Baslat1_Click(object sender, EventArgs e)
        {
            th01 = new Thread(dene1);
            th01.Start();
        }

        private void dene1()
        {
            for (int i = 0; i < 1000000001; i++)
            {
                progressBar1.Value = i / 10000000;
            }
        }

        private void Baslat2_Click(object sender, EventArgs e)
        {
            th02 = new Thread(dene2);
            th02.Start();
        }

        private void dene2()
        {
            for (int i = 0; i < 1000000001; i++)
            {
                progressBar2.Value = i / 10000000;
            }
        }

        private void Beklet1_Click(object sender, EventArgs e)
        {
            if (th01 != null && th01.IsAlive)
                th01.Suspend();

        }

        private void Beklet2_Click(object sender, EventArgs e)
        {
            if (th02 != null && th02.IsAlive)
                th02.Suspend();
        }

        private void Devam1_Click(object sender, EventArgs e)
        {
            if ((th01 != null) && (th01.ThreadState == ThreadState.Suspended))      
                th01.Resume();
        }

        private void Devam2_Click(object sender, EventArgs e)
        {
            if ((th02 != null) && (th02.ThreadState == ThreadState.Suspended))
                th02.Resume();
        }
    }
}
