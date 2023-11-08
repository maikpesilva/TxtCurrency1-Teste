using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValorPorExtenso;

namespace TxtCurrency1
{
    public partial class Form1 : Form
    {
        private object txtExtenso;

        public Form1()
        {
            InitializeComponent();

            textBox1.Text = string.Format("{0:#,##0.00}", 0d);
        }

        private void TxtKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox t = (TextBox)sender;

                string w = Regex.Replace(t.Text, "[^0-9]", string.Empty);
                if (w == string.Empty) w = "00";

                if (e.KeyChar.Equals((char)Keys.Back))
                    w = w.Substring(0, w.Length - 1);

                else

                    w += e.KeyChar;

                t.Text = string.Format("{0:#,##0.00}", Double.Parse(w) / 100);
                t.Select(t.Text.Length, 0);



            }
            e.Handled = true;



        }

        private void TxtDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                TextBox t = (TextBox)sender;
                t.Select(t.TextLength, 0);
                e.Handled = true;


            }


        }

        private void btnExtenso_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valor = Convert.ToDecimal(textBox1.Text);
                textBox2.Text = Conversor.EscreverExtenso(valor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }    
        
        
        


    


} 