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
    public partial class LookingGlass : Form
    {
        public LookingGlass()
        {
            InitializeComponent();
        }

        string text = Application.StartupPath;

        private void Form3_Load(object sender, EventArgs e)
        {
            //stabilirea limbii pentru acest Form
            if (Clasa_Intrebari.Limba == 1)
            {
                //găsirea fișierului de tip .txt, unde se află secvențele de text în engleză
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_EN\file1.txt";
                string text1 = System.IO.File.ReadAllText(text);

                text = text.Substring(0, text.Length - 9);
                text = text + @"file2.txt";
                string text2 = System.IO.File.ReadAllText(text);
                //

                label1.Text = Class3.Titlu[0];
                richTextBox1.Text = text1;
                label2.Text = Class3.Titlu[1];
                richTextBox2.Text = text2;
                button1.Text = Class3.Titlu[164];
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                //găsirea fișierului de tip .txt, unde se află secvențele de text în română
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_RO\file1.txt";
                string text1 = System.IO.File.ReadAllText(text);

                text = text.Substring(0, text.Length - 9);
                text = text + @"file2.txt";
                string text2 = System.IO.File.ReadAllText(text);
                //

                richTextBox1.Text = text1;
                richTextBox2.Text = text2;
            }
            //

            //stabilește dacă utilizatorul poate edita textul
            if (Clasa_Conectare.Status == 1 || Clasa_Conectare.Status == 2)
            {
                richTextBox1.ReadOnly = false;
                richTextBox2.ReadOnly = false;
            }
            else
            {
                richTextBox1.ReadOnly = true;
                richTextBox2.ReadOnly = true;
            }
            //

            button1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //trecerea la Form-ul cuprinsului
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
            //
        }

        //închiderea aplicației
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
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
        //

        //când textul se modifică, butonul de salvare devine utilizabil
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }
        //

        //salvează modificările
        private void button1_Click(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 1)
            {
                text = text.Substring(0, text.Length - 9);
                text = text + @"file2.txt";
                System.IO.File.WriteAllText(text, richTextBox2.Text);

                text = text.Substring(0, text.Length - 9);
                text = text + @"file1.txt";
                System.IO.File.WriteAllText(text, richTextBox1.Text);

                MessageBox.Show(Class3.Titlu[166], Class3.Titlu[165], MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Visible = false;
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                text = text.Substring(0, text.Length - 9);
                text = text + @"file2.txt";
                System.IO.File.WriteAllText(text, richTextBox2.Text);

                text = text.Substring(0, text.Length - 9);
                text = text + @"file1.txt";
                System.IO.File.WriteAllText(text, richTextBox1.Text);

                MessageBox.Show("Textul a fost salvat.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Visible = false;
            }
        }
        //

        //informații suplimentare legate de butoane
        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a salva modificările.", button1);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[167], button1);
            }
        }
        //
    }
}
