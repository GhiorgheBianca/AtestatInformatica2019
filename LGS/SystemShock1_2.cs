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
    public partial class SystemShock1_2 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public SystemShock1_2()
        {
            InitializeComponent();

            //căutarea și memorarea locului unde se află coloana sonoră corespunzătoare Form-ului curent
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Muzica\08 SS_security.mp3";
            player.URL = url1;
            //
        }

        string text = Application.StartupPath;

        private void Form18_Load(object sender, EventArgs e)
        {
            //stabilirea limbii pentru acest Form și înlocuirea cu textul tradus
            if (Clasa_Intrebari.Limba == 1)
            {
                //găsirea fișierului de tip .txt, unde se află secvențele de text în engleză
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_EN\ss2.txt";
                string text1 = System.IO.File.ReadAllText(text);

                text = text.Substring(0, text.Length - 7);
                text = text + @"ss3.txt";
                string text2 = System.IO.File.ReadAllText(text);

                text = text.Substring(0, text.Length - 7);
                text = text + @"ss4.txt";
                string text3 = System.IO.File.ReadAllText(text);
                //

                label2.Text = Class3.Titlu[14];
                label1.Text = Class3.Titlu[18];
                label3.Text = Class3.Titlu[16];
                richTextBox2.Text = text1;
                richTextBox1.Text = text2;
                richTextBox3.Text = text3;
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                //găsirea fișierului de tip .txt, unde se află secvențele de text în română
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_RO\ss2.txt";
                string text1 = System.IO.File.ReadAllText(text);

                text = text.Substring(0, text.Length - 7);
                text = text + @"ss3.txt";
                string text2 = System.IO.File.ReadAllText(text);

                text = text.Substring(0, text.Length - 7);
                text = text + @"ss4.txt";
                string text3 = System.IO.File.ReadAllText(text);
                //

                richTextBox2.Text = text1;
                richTextBox1.Text = text2;
                richTextBox3.Text = text3;
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
                richTextBox1.ReadOnly = false;
                richTextBox2.ReadOnly = false;
                richTextBox3.ReadOnly = false;
            }
            else
            {
                richTextBox1.ReadOnly = true;
                richTextBox2.ReadOnly = true;
                richTextBox3.ReadOnly = true;
            }
            //

            button4.Visible = false;
        }

        //trecerea la următorul Form, respectiv oprirea coloanei sonore
        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            FlightUnlimited f19 = new FlightUnlimited();
            f19.Show();
        }
        //

        //trecerea la Form-ul precedent, respectiv oprirea coloanei sonore
        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form17 f17 = new Form17();
            f17.Show();
        }
        //

        //închiderea aplicației
        private void Form18_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //

        //informații suplimentare legate de butoane
        ToolTip tip = new ToolTip();
        private void button3_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce înapoi.", button3);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[124], button3);
            }
        }

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

        private void button4_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a salva modificările.", button4);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[167], button4);
            }
        }
        //

        //salvează modificările
        private void button4_Click(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 1)
            {
                text = text.Substring(0, text.Length - 7);
                text = text + @"ss2.txt";
                System.IO.File.WriteAllText(text, richTextBox2.Text);

                text = text.Substring(0, text.Length - 7);
                text = text + @"ss3.txt";
                System.IO.File.WriteAllText(text, richTextBox1.Text);

                text = text.Substring(0, text.Length - 7);
                text = text + @"ss4.txt";
                System.IO.File.WriteAllText(text, richTextBox3.Text);

                MessageBox.Show(Class3.Titlu[166], Class3.Titlu[165], MessageBoxButtons.OK, MessageBoxIcon.Information);
                button4.Visible = false;
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                text = text.Substring(0, text.Length - 7);
                text = text + @"ss2.txt";
                System.IO.File.WriteAllText(text, richTextBox2.Text);

                text = text.Substring(0, text.Length - 7);
                text = text + @"ss3.txt";
                System.IO.File.WriteAllText(text, richTextBox1.Text);

                text = text.Substring(0, text.Length - 7);
                text = text + @"ss4.txt";
                System.IO.File.WriteAllText(text, richTextBox3.Text);

                MessageBox.Show("Textul a fost salvat.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button4.Visible = false;
            }
        }
        //

        //când textul se modifică, butonul de salvare devine utilizabil
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            button4.Visible = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button4.Visible = true;
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            button4.Visible = true;
        }
        //
    }
}
