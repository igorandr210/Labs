using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jordan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox3.Text);
            string[] s = textBox1.Text.Split('\n');
            
            double[,] A = new double[s.Length,n];
            int i = 0;
            int j = 0;
            foreach (var c in s)
            {
                var temp=c.Split(' ');
                foreach(var t in temp)
                {
                    A[i, j] = Convert.ToDouble(t);
                    j++;
                }
                j = 0;
                i++;
            }
            
            string[] g = textBox2.Text.Split('\n');
            double[] B = new double[g.Length];
            i = 0;
            foreach (var c in g)
            {
                B[i] = Convert.ToDouble(c);
                i++;
            }
            var f =Jordan(A, B, n);
            string Stroka = "";
            i = 0;
            foreach (var t in f)
            {
                i++;
                Stroka +=String.Format("X[{0}] = ",i)+ t + "\n";
            }
            MessageBox.Show(Stroka);
        }
        private double[] Jordan(double[,] A,double[] B,int n)
        {
            for (int k = 0; k < n; k++)
            {
                double d = A[k, k];
                A[k, k] = 1.0;
                for (int j = k + 1; j < n; j++)
                {
                    A[k, j] = A[k, j] / d;
                }
                B[k] = B[k] / d;
                for (int i = 0; i < n; i++)
                {
                    if (i != k)
                    {
                        double S = A[i, k];
                        A[i, k] = 0;
                        for (int j = k + 1; j < n; j++)
                        {
                            A[i, j] = A[i, j] - S * A[k, j];
                        }
                        B[i] = B[i] - S * B[k];
                    }
                }
            }
            return B;
        }
        bool tx1 = true;
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (tx1)
            {
                textBox1.Text = "";
                tx1 = false;
            }
        }
        bool tx2 = true;
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (tx2)
            {
                textBox2.Text = "";
                tx2 = false;
            }
        }
        bool tx3 = true;
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (tx3)
            {
                textBox3.Text = "";
                tx3 = false;
            }
        }
    }
}
