using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class PrimesCalculator : Form
    {
        private CancellationTokenSource _source;

        public PrimesCalculator()
        {
            InitializeComponent();

            CancelButton.Enabled = false;

            this.FromTextBox.TextChanged += FromTextBox_TextChanged;
            this.ToTextBox.TextChanged += ToTextBox_TextChanged;
        }

        private async void CalculateButton_Click(object sender, EventArgs e)
        {
            _source = new CancellationTokenSource();
            CancellationToken token = _source.Token;

            if ((FromTextBox.Text != "") && (ToTextBox.Text != ""))
            {
                CalculateButton.Enabled = false;
                CancelButton.Enabled = true;

                var countPrimes = await PrimeFinder.CountPrimesAsync(int.Parse(FromTextBox.Text), int.Parse(ToTextBox.Text),
                        token.WaitHandle);
                CountLabel.Text = string.Format($"Number of primes in range: {countPrimes}.");

                if (SaveLocationTextBox.Text != "")
                {
                    var saveLocation = string.Format(SaveLocationTextBox.Text+".txt");
                    using (var writer = new StreamWriter(saveLocation, true))
                    {
                        writer.WriteLine($"Calculation done on: {DateTime.Now}. Number of primes in range: {countPrimes}.");
                    }
                    SaveLocationTextBox.Text = string.Format($"Calculation saved to file: \"{saveLocation}\"");
                }

                CancelButton.Enabled = false;
                CalculateButton.Enabled = true;

                _source.Dispose();
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancelButton.Enabled = false;
            _source.Cancel();
        }

        //2 Events that don't let users input anything but numbers ("FromTextBox_TextChanged" and "ToTextBox_TextChanged").
        private void FromTextBox_TextChanged(object sender, EventArgs e)
        {
            bool enteredLetter = false;
            var text = new Queue<char>();
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
                var sb = new StringBuilder();
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
            var text = new Queue<char>();
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
                var sb = new StringBuilder();
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
