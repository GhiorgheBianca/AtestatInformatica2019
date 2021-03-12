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
    public partial class SchimbLimba : Form
    {
        public SchimbLimba()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //alegerea steagului corespunzător
            if (comboBox1.SelectedIndex == 0)
            {
                //steagul României
                pictureBox1.Image = imageList1.Images[0];
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                //steagul Marii Britanii
                pictureBox1.Image = imageList1.Images[1];
            }
            //
        }

        private void Form25_Load(object sender, EventArgs e)
        {
            
        }

        //închiderea aplicației
        private void Form25_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //

        private void button1_Click(object sender, EventArgs e)
        {
            //reținerea valorii care determină selectarea limbii printr-o clasă și trecerea la următorul Form
            if (comboBox1.SelectedIndex == 0)
            {
                //pentru română
                Clasa_Intrebari.Limba = 0;
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                //stabilirea locației fișierului de tip .txt, valabil pentru întreaga aplicație
                string text = Application.StartupPath;
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_EN\titluri.txt";
                Class3.Titlu = System.IO.File.ReadAllLines(text);
                //pentru engleză
                Clasa_Intrebari.Limba = 1;
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            //
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //informații suplimentare legate de butoane
        ToolTip tip = new ToolTip();
        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă după ce ai selectat limba.", button1);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[137], button1);
            }
        }
        //
    }
}
