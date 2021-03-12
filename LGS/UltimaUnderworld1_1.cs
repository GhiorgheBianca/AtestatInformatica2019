using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace LGS
{
    public partial class Form13 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form13()
        {
            InitializeComponent();

            //căutarea și memorarea locului unde se află coloana sonoră corespunzătoare Form-ului curent
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Muzica\UW The Fat Man - 03 - Descent.mp3";
            player.URL = url1;
            //
        }

        //trecerea la Form-ul cuprinsului, respectiv oprirea coloanei sonore
        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }
        //

        //afișarea Form-urilor cu imaginile reprezentative jocului selectat prin apăsarea label-ului corespunzător
        private void label1_Click(object sender, EventArgs e)
        {
            PozeUltima6 f26 = new PozeUltima6();
            f26.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PozeUltima7 f27 = new PozeUltima7();
            f27.Show();
        }
        //

        private void label3_Click(object sender, EventArgs e)
        {

        }

        string text = Application.StartupPath;

        private void Form13_Load(object sender, EventArgs e)
        {
            //stabilirea limbii pentru acest Form și înlocuirea cu textul tradus
            if (Clasa_Intrebari.Limba == 1)
            {
                //găsirea fișierului de tip .txt, unde se află secvența de text în engleză
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_EN\uw1.txt";

                string text1 = System.IO.File.ReadAllText(text);
                //

                richTextBox2.Text = text1;
                label2.Text = Class3.Titlu[11];
                label3.Text = Class3.Titlu[12];
                button1.Text = Class3.Titlu[13];
                button3.Text = Class3.Titlu[164];
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                //găsirea fișierului de tip .txt, unde se află secvența de text în română
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_RO\uw1.txt";

                string text1 = System.IO.File.ReadAllText(text);
                //

                richTextBox2.Text = text1;
            }
            //

            //pornirea, respectiv oprirea muzicii în funcție de setarea sonorului din cuprins
            if (Class2.Muzica == 0)
                player.controls.play();
            else if (Class2.Muzica == 1)
                player.controls.stop();
            //

            //stabilește dacă utilizatorul poate edita textul
            if (Clasa_Conectare.Status == 1 || Clasa_Conectare.Status == 2)
            {
                richTextBox2.ReadOnly = false;
            }
            else
            {
                richTextBox2.ReadOnly = true;
            }
            //

            button3.Visible = false;
        }

        //trecerea la următorul Form, respectiv oprirea coloanei sonore
        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            UltimaUnderworld1_2 f14 = new UltimaUnderworld1_2();
            f14.Show();
        }
        //

        //închiderea aplicației
        private void Form13_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //

        //informații suplimentare legate de butoane
        ToolTip tip = new ToolTip();
        private void button2_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce înainte.", button2);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[125], button2);
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce la cuprins.", button1);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[121], button1);
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a afișa imagini cu Ultima VI.", label1);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[134], label1);
            }
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a afișa imagini cu Ultima VII.", label4);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[135], label4);
            }
        }
        //

        //salvează modificările
        private void button3_Click(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 1)
            {
                System.IO.File.WriteAllText(text, richTextBox2.Text);

                MessageBox.Show(Class3.Titlu[166], Class3.Titlu[165], MessageBoxButtons.OK, MessageBoxIcon.Information);
                button3.Visible = false;
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                System.IO.File.WriteAllText(text, richTextBox2.Text);

                MessageBox.Show("Textul a fost salvat.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button3.Visible = false;
            }
        }
        //

        //când textul se modifică, butonul de salvare devine utilizabil
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            button3.Visible = true;
        }
        //

        //informații suplimentare legate de butoane
        private void button3_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a salva modificările.", button3);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[167], button3);
            }
        }
        //
    }
}
