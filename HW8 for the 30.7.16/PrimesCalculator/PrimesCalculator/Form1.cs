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
            this.FromTextBox.TextChanged += FromTextBox_TextChanged;
            this.ToTextBox.TextChanged += ToTextBox_TextChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if ((FromTextBox.Text != "") && (ToTextBox.Text != ""))
            {
                CalculateButton.Enabled = false;
                var resultingPrimes = PrimeFinder.CalcPrimes(int.Parse(FromTextBox.Text), int.Parse(ToTextBox.Text));
                ResultListBox.DataSource = resultingPrimes;
                CalculateButton.Enabled = true;
            }
        }

        private void FromTextBox_TextChanged(object sender, EventArgs e)
        {
            bool enteredLetter = false;
            Queue<char> text = new Queue<char>();
            foreach (var ch in this.FromTextBox.Text)
            {
                if (char.IsDigit(ch))
                {
                    text.Enqueue(ch);
                }
                else
                {
                    enteredLetter = true;
                }
            }

            if (enteredLetter)
            {
                StringBuilder sb = new StringBuilder();
                while (text.Count > 0)
                {
                    sb.Append(text.Dequeue());
                }

                this.FromTextBox.Text = sb.ToString();
                this.FromTextBox.SelectionStart = this.FromTextBox.Text.Length;
            }
        }

        private void ToTextBox_TextChanged(object sender, EventArgs e)
        {
            bool enteredLetter = false;
            Queue<char> text = new Queue<char>();
            foreach (var ch in this.ToTextBox.Text)
            {
                if (char.IsDigit(ch))
                {
                    text.Enqueue(ch);
                }
                else
                {
                    enteredLetter = true;
                }
            }

            if (enteredLetter)
            {
                StringBuilder sb = new StringBuilder();
                while (text.Count > 0)
                {
                    sb.Append(text.Dequeue());
                }

                this.ToTextBox.Text = sb.ToString();
                this.ToTextBox.SelectionStart = this.ToTextBox.Text.Length;
            }
        }
    }
}
