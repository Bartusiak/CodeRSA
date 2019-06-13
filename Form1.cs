using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Zadanie3
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String toCrypt = textBox1.Text;
            BigInteger P = BigInteger.Parse(numP.Text);
            BigInteger Q = BigInteger.Parse(numQ.Text);
            BigInteger E = BigInteger.Parse(numE.Text);
            BigInteger N = P * Q;
            BigInteger fn = (P - 1) * (Q - 1);
            while (CheckIfPrime((double)E) == false && (BigInteger)E < fn)
            {
                E = RandomInteger(fn - 1);
                
            }
            int d = 2;
            while (((d * E) % fn) != 1 || d==E)
            {
                d++;
            }
            publicKey.Text = "(" + E + "," + N + ")";
            privKey.Text = "(" + d + "," + N + ")";
            int j = 0;
            BigInteger value = 0;
            textBox4.Text = "";
            for (int i = 0; i < textBox1.Text.Length-1; i++)
            {
                value = textBox1.Text[i] * 256 + textBox1.Text[i + 1];
                
                i++;
                value = BigInteger.ModPow(value, E, N);
                BigInteger valueDiv,valueMod;
                valueDiv = value / 256;
                valueMod = value % 256;
                

                textBox4.Text = textBox4.Text + valueDiv + " " + valueMod + " ";
                //Problem polega pomiedzy ASCII i UTF (wyswietlanie)
                //textBox4.Text = textBox4.Text + (Char)valueDiv + (char)valueMod;
                   
            
            /* byte[] asciiBytes = Encoding.ASCII.GetBytes();
                char[] asciiChars = Encoding.ASCII.GetChars(asciiBytes);
                string asciiString = new string(asciiChars);
                textBox4.Text = textBox4.Text + asciiString;*/

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public static BigInteger RandomInteger(BigInteger N)
        {
            Random random = new Random();
            byte[] bytes = N.ToByteArray();
            BigInteger R;

            do
            {
                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F;
                R = new BigInteger(bytes);
            } while (R >= N);

            return R;
        }

        public bool CheckIfPrime(double e)
        {
            //var sqrt = BigInteger.D(e);
            var sqrt = Math.Sqrt(e);
            for (var i = 2; i <= sqrt; i++)
            {
                if ((e % i == 0))
                    return false;
            }
            return true;
        }
    
        

        private void numP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
