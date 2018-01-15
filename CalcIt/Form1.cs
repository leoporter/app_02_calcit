using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcIt
{
    public partial class CalcIt : Form
    {
        // przechowuje wynik
        double result = 0;
        // przechowuje rodzaj wykonywanej operacji 
        string operationPerformed = "";
        // przechowuje stan logiczny wykonywanej operacji
        bool isOperationPerformed = false;

        double numberInTextBox;

        // konstruktor
        public CalcIt()
        {
            InitializeComponent();
        }

        // wydarzenie na ładowanie aplikacji
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // wydarzenie na kliknięcie w przyciski cyfr lub kropki
        private void button19_Click(object sender, EventArgs e)
        {
            // rzutowanie buttona na obiekt wysyłający 
            Button button = (Button)sender;
            
            // jeśli wpisze się 0 na początku lub nie wykonuje się działania, to wpisanie liczby np. 3 da 3, a nie 03
            if ((textBox1.Text == "0") || (isOperationPerformed))
            {
                // jeśli ciąg znaków jest inny niż 0, to go wymazuje
                if (!((textBox1.Text == "0") && (button.Text == ",")))
                {
                    textBox1.Clear();
                }
            }

            // wyświetlenie aktualnie wykonywanej operacji
            labelCurrentOperation.Text = result + " " + operationPerformed;
            // czy operacja jest wykonywana
            isOperationPerformed = false;

            // warunek co się dzieje, jeśli zostanie wpisana kropka
            if (button.Text == ",")
            {
                // jeśli nie ma kropki to można wpisywać tekst
                if (!textBox1.Text.Contains(","))
                {
                    textBox1.Text = textBox1.Text + button.Text;
                }
            }
            // nie ma kropki, to można wpisać kolejne cyfry
            else
            {
                textBox1.Text = textBox1.Text + button.Text;
            }
        }

        // wydarzenie na kliknięcie w przyciski działań (tj. +, -, *, /)
        private void operator_click(object sender, EventArgs e)
        {
            // rzutowanie buttona na "wysyłacz" - zeby wysłało 
            Button button = (Button)sender;

            if (result != 0)
            {
                operationPerformed = button.Text;
                labelCurrentOperation.Text = result + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                // przypisanie znaku działania do wykonywanego działania 
                operationPerformed = button.Text;
                // wynik rzutujemy na double
                double.TryParse(textBox1.Text, out result);
                // flaga ustawiana na tak, jest wykonywana operacja 
                labelCurrentOperation.Text = result + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        // przycisk CE - służy do wyczyszczenia działań
        private void clear_entry(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void clear(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            result = 0;
        }

        // wydarzenie co się ma dziać na wciśnięcie entera
        private void button_equal(object sender, EventArgs e)
        {
            double.TryParse(textBox1.Text, out numberInTextBox);
            // w zależności od wykonywanego działania
            switch (operationPerformed)
            {
                // przypadek dodawania
                case "+":
                    textBox1.Text = (result + numberInTextBox).ToString();
                    break;
                // przypadek odejmowania 
                case "-":
                    textBox1.Text = (result - numberInTextBox).ToString();
                    break;
                // przypadek mnożenia
                case "*":
                    textBox1.Text = (result * numberInTextBox).ToString();
                    break;
                // przypadek dzielenia
                case "/":
                    textBox1.Text = (result / numberInTextBox).ToString();
                    break;
                // przypadek potęgowania
                case "^":
                    textBox1.Text = (Math.Pow(result, numberInTextBox)).ToString();
                    break;
                // przypadek silnii
                case "√":
                    textBox1.Text = (Math.Sqrt(result)).ToString();
                    break;
                default:
                    break;
            }
            double.TryParse(textBox1.Text, out result);
            labelCurrentOperation.Text = "";
        }

        private void labelCurrentOperation_Click(object sender, EventArgs e)
        {

        }
    }
}
