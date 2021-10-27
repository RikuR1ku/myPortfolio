using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        /* 
         Pelissä on 2 pelaajaa ja kukin pelaaja heittää kerran vuorossa kahta 10-sivuista noppaa.
         Pelaajilla on pelin alussa 100 elämäpistettä ja kahden nopan silmäluvun summa määrittää, 
         kuinka paljon elämäpisteitä vastapelaaja menettää. Se, joka ensimmäisenä saa pudotettua 
         vastapelaajan elämäpisteet nollaan, voittaa pelin. Jos pelaaja saa 2 samaa silmälukua, 
         pelaaja saa ylimääräisen heittovuoron.
        */

        pisteet p1 = new pisteet();
        pisteet p2 = new pisteet();
        Random gen = new Random();
        int noppis1;
        int noppis2;
        int a = 100;
        int b = 100;
        int erotussumma1 = 0;
        int erotussumma2 = 0;



        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            noppis1 = gen.Next(10);
            noppis2 = gen.Next(10);

            pictureBox1.Image = Image.FromFile("TenSidedDice\\D" + noppis1 + ".jpg");
            pictureBox2.Image = Image.FromFile("TenSidedDice\\D" + noppis2 + ".jpg");
            label1.Text = "Numerot: " + noppis1 + " ja " + noppis2;
            label3.Text = "";
            erotussumma2 = noppis1 + noppis2;
            a = p2.palautaEp() - erotussumma2;
            p2.laitaEp(a);
            timer1.Enabled = true;
            button1.Visible = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p1.laitaEp(100);
            p2.laitaEp(100);
            pictureBox3.Width = 300;
            pictureBox4.Width = 300;
            label2.Text = "Pelaaja 1:n ep: " + p1.palautaEp();
            label5.Text = "Pelaaja 2:n ep: " + p2.palautaEp();
            pictureBox5.BackgroundImage = null;
            int decider = gen.Next(2);
            if (decider == 1)
            {
                button3.Visible = false;
                button1.Visible = true;
            }
            
            else
            {
                button1.Visible = false;
                button3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            noppis1 = gen.Next(10);
            noppis2 = gen.Next(10);

            pictureBox1.Image = Image.FromFile("TenSidedDice\\D" + noppis1 + ".jpg");
            pictureBox2.Image = Image.FromFile("TenSidedDice\\D" + noppis2 + ".jpg");
            label1.Text = "Numerot: " + noppis1 + " ja " + noppis2;
            label4.Text = "";
            erotussumma1 = noppis1 + noppis2;
            b = p1.palautaEp() - erotussumma1;
            p1.laitaEp(b);
            timer2.Enabled = true;
            button3.Visible = false;
        }

        int kerroin1 = 1;
        int kerroin2 = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox3.Width -= 1;
            kerroin1++;
            if (kerroin1 >= erotussumma2 * 3)
            {
                timer1.Enabled = false;
                kerroin1 = 1;
                if (noppis1 == noppis2)
                    {
                        label3.Text = "Bonus aktivoitu!";
                        button1.Visible = true;
                    }
                else if (a < 1)
                    {
                        button1.Visible = false;
                        button3.Visible = false;
                        label2.Text = "Pelaaja 1:n ep: " + a;
                        label1.Text = "Pelaaja 2 voitti!";
                    }
                else
                    {
                        label2.Text = "Pelaaja 1:n ep: " + a;
                        button1.Visible = false;
                        button3.Visible = true;
                    }
                
            }
    }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox4.Width -= 1;
            kerroin2++;
            if (kerroin2 >= erotussumma1 * 3)
            {
                timer2.Enabled = false;
                kerroin2 = 1;
                if (noppis1 == noppis2)
                {
                    label4.Text = "Bonus aktivoitu!";
                    button3.Visible = true;
                }
                else if (b < 1)
                {
                    button1.Visible = false;
                    button3.Visible = false;
                    label5.Text = "Pelaaja 2:n ep: " + b;
                    label1.Text = "Pelaaja 1 voitti!";
                }
                else
                {
                    label5.Text = "Pelaaja 2:n ep: " + b;
                    button3.Visible = false;
                    button1.Visible = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
