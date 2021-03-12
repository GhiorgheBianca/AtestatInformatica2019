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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //găsirea fișierului de tip .txt, unde se află textul titlului în engleză
            string text = Application.StartupPath;
            text = text.Substring(0, text.Length - 10);
            text = text + @"\texte_EN\titlu1.txt";

            string text1 = System.IO.File.ReadAllText(text);
            //

            //stabilirea limbii pentru acest Form
            if (Clasa_Intrebari.Limba == 1)
            {
                label1.Text = text1;
                label2.Text = Class3.Titlu[2];
                label1.Location = new Point(187, 411);
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                //ajustarea pozițiilor unor obiecte, în urma selectării limbii
                label2.Location = new Point(14, 4);
            }
            //
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //trecerea la Form-ul cu descrierea companiei
            this.Hide();
            LookingGlass f3 = new LookingGlass();
            f3.Show();
            //
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //trecerea la Form-ul cu descrierea jocului Thief: The Dark Project
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
            //
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //trecerea la Form-ul cu descrierea jocului Ultima Underworld
            this.Hide();
            Form13 f13 = new Form13();
            f13.Show();
            //
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //trecerea la Form-ul cu descrierea jocului System Shock 2
            this.Hide();
            Form7 f7 = new Form7();
            f7.Show();
            //
        }

        //închiderea aplicației
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //

        //informații suplimentare legate de butoane
        ToolTip tip = new ToolTip();
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
             tip.Show("Thief: The Dark Project", pictureBox1);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            tip.Show("Ultima Underworld: The Stygian Abyss", pictureBox3);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            tip.Show("System Shock 2", pictureBox2);
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Informații despre studioul Looking Glass.", label1);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[127], label1);
            }
        }
        //
    }
}
