using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGS
{
    public partial class Meniu_Jocuri : Form
    {
        public Meniu_Jocuri()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Class3.Test_acomodare == true)
            {
                this.Hide();
                Joc_Xsi0 f24 = new Joc_Xsi0();
                f24.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }
        //

        //închiderea aplicației
        private void Form33_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //

        private void Form33_Load(object sender, EventArgs e)
        {
            if(Clasa_Intrebari.Limba == 1)
            {
                label1.Text = Class3.Titlu[50];
                button1.Text = Class3.Titlu[51];
                button2.Text = Class3.Titlu[52];
            }

            if (Class3.Test_acomodare == true)
            {
                pictureBox1.Visible = false;
                panel2.Visible = false;
            }
        }

        //informații suplimentare legate de butoane
        ToolTip tip = new ToolTip();
        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (Class3.Test_acomodare == true)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    tip.Show("Apasă pentru a te duce la jocul X și 0.", button1);
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    tip.Show(Class3.Titlu[198], button1);
                }
            }
            else if (Class3.Test_acomodare == false)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    tip.Show("Trebuie să faci mai întâi testul de acomodare (chestionarul).", button1);
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    tip.Show(Class3.Titlu[199], button1);
                }
            }
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce la cuprins.", button2);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[121], button2);
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            if (Class3.Test_acomodare == false)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    tip.Show("Trebuie să faci mai întâi testul de acomodare (chestionarul).", pictureBox1);
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    tip.Show(Class3.Titlu[199], pictureBox1);
                }
            }
        }
        //
    }
}
