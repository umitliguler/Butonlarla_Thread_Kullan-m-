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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        void yazdir01()
        {
            for (int i = 0; i < 100000; i++)
            {
                listBox1.Items.Add(Thread.CurrentThread.Name + "---->" + i);
            }
        }

        void yazdir02()
        {
            for (int i = 0; i < 100000; i++)
            {
                listBox1.Items.Add(Thread.CurrentThread.Name + "---->" + i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th01 = new Thread(yazdir01);
            th01.Name = "isci 01";
            Thread th02 = new Thread(yazdir02);
            th01.Name = "isci 02";

            th01.Start();
            th02.Start();
        }
    }
}
