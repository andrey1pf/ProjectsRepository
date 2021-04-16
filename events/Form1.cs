using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace events
{
    public partial class Form1 : Form
    {
        private Presenter presenter;
        private Calculator calculator;
        private int delay;
       
        public Form1()
        {
            InitializeComponent();
            presenter = new Presenter();
            calculator = new Calculator(int.Parse(textBoxMS.Text));
            presenter.PresEvent += new PresenterEventHandler(calculator.Message);
            calculator.calculationEvent += new CalculatorEventHandler(presenter.Display);
            presenter.PrEvent += new PresentEventHandler(this.sendInfo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            textBoxMS.Enabled = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            calculator = new Calculator((int)delay);
            presenter.PresEvent += new PresenterEventHandler(calculator.Message);
            calculator.calculationEvent += new CalculatorEventHandler(presenter.Display);
            Thread threadCalc1 = new Thread(calculator.Calculation);
            threadCalc1.Start();
            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
            textBoxMS.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            presenter.Stop();
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
            textBoxMS.Enabled = true;
        }

        private void checkNumber(object sender, CancelEventArgs e, ref int a)
        {
            try
            {
                a = int.Parse((sender as TextBox).Text);
                errorProvider1.Clear();
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(sender as TextBox, ex.Message);
                e.Cancel = true;
                (sender as TextBox).Text = "";
            }
        }

        public void sendInfo(object sender, DisplayEventArgs e)
        {
            if (e.Append) {
                tbInfo.AppendText(e.Info + "\r\n");
            }
            else {
                tbInfo.Text = e.Info + "\r\n";
            }
            Invalidate();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            presenter.Stop();
        }

        private void textBoxMS_Validating(object sender, CancelEventArgs e)
        {
            checkNumber(sender, e, ref delay);
        }
    }
}
