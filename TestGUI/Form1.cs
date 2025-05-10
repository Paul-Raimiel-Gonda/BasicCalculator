using System;
using System.Data;
using System.Windows.Forms;

namespace TestGUI
{
    public partial class Form1 : Form
    {
        private string expression = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateDisplay()
        {
           
            textBox1.Text = expression;
        }

       // ---------- Number buttons ----------
        private void button1_Click(object sender, EventArgs e) { expression += "1"; UpdateDisplay(); }
        private void button2_Click(object sender, EventArgs e) { expression += "2"; UpdateDisplay(); }
        private void button3_Click(object sender, EventArgs e) { expression += "3"; UpdateDisplay(); }
        private void button4_Click(object sender, EventArgs e) { expression += "4"; UpdateDisplay(); }
        private void button5_Click(object sender, EventArgs e) { expression += "5"; UpdateDisplay(); }
        private void button6_Click(object sender, EventArgs e) { expression += "6"; UpdateDisplay(); }
        private void button7_Click(object sender, EventArgs e) { expression += "7"; UpdateDisplay(); }
        private void button8_Click(object sender, EventArgs e) { expression += "8"; UpdateDisplay(); }
        private void button9_Click(object sender, EventArgs e) { expression += "9"; UpdateDisplay(); }
        private void button10_Click(object sender, EventArgs e) { expression += "0"; UpdateDisplay(); }

        private void button18_Click(object sender, EventArgs e) { expression += "."; UpdateDisplay(); } // period

        private void button11_Click(object sender, EventArgs e)   // CE
        {
            expression = "";
            UpdateDisplay();
        }

        private void button12_Click(object sender, EventArgs e)   // C
        {
            if (expression.Length > 0)
                expression = expression.Substring(0, expression.Length - 1);
            UpdateDisplay();
        }


        private void button13_Click(object sender, EventArgs e) { expression += "/"; UpdateDisplay(); }  // divide
        private void button14_Click(object sender, EventArgs e) { expression += "*"; UpdateDisplay(); }  // multiply
        private void button15_Click(object sender, EventArgs e) { expression += "-"; UpdateDisplay(); }  // subtract
        private void button16_Click(object sender, EventArgs e) { expression += "+"; UpdateDisplay(); }  // add


        private void button17_Click(object sender, EventArgs e)  
        {
            try
            {
               
                var result = new DataTable().Compute(expression, null);
                expression = result.ToString();
                UpdateDisplay();
            }
            catch
            {
                MessageBox.Show("Invalid Expression", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expression = "";
                UpdateDisplay();
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
