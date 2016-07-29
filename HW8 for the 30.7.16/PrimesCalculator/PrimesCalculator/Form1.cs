using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class PrimesCalculator : Form
    {
        public PrimesCalculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CalculateButton_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            var resultingPrimes = PrimeFinder.CalcPrimes(int.Parse(FromTexBox.Text), int.Parse(ToTextBox.Text));
            ResultListBox.DataSource = resultingPrimes;
        }
    }
}
