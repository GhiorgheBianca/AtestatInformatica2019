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
using System.Diagnostics;

namespace LGS
{
    public partial class Video : Form
    {
        public Video()
        {
            InitializeComponent();

            //căutarea și memorarea locului unde se află un videoclip
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Videoclipuri\How Thief's Stealth System Almost Didn't Work - War Stories - Ars Technica.mp4";
            axWindowsMediaPlayer1.URL = url1;
            //
        }

        //inițializarea numărul videoclipului
        int video = 0;

        private void Form40_Load(object sender, EventArgs e)
        {
            //pornește videoclipul
            axWindowsMediaPlayer1.Ctlcontrols.play();

            //alege textul în funcție de limbă pentru primul videoclip
            if (Clasa_Intrebari.Limba == 1)
            {
                label1.Text = Class3.Titlu[169] + Environment.NewLine + Class3.Titlu[170];

                string text = Application.StartupPath;
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_EN\video1.txt";
                richTextBox1.Text = System.IO.File.ReadAllText(text);

                linkLabel1.Text = Class3.Titlu[171];
                videoclipuriToolStripMenuItem.Text = Class3.Titlu[176];
                howThiefsStealthSystemAlmostDidntWorkToolStripMenuItem.Text = Class3.Titlu[169] + Class3.Titlu[170];
                lookingGlassStudiosRetrospective13ToolStripMenuItem.Text = Class3.Titlu[172] + Class3.Titlu[173];
                lookingGlassStudiosRetrospective23ToolStripMenuItem.Text = Class3.Titlu[172] + Class3.Titlu[174];
                lookingGlassStudiosRetrospective33ToolStripMenuItem.Text = Class3.Titlu[172] + Class3.Titlu[175];
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                label1.Text = "[Thief] Cum mecanicile stealth aproape" + Environment.NewLine + "nu au funcționat";

                string text = Application.StartupPath;
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_RO\video1.txt";
                richTextBox1.Text = System.IO.File.ReadAllText(text);

                panel1.Visible = true;
                label2.Visible = true;
                button1.Visible = true;
            }
            //

            //stabilește dacă utilizatorul poate edita textul
            if (Clasa_Conectare.Status == 1 || Clasa_Conectare.Status == 2)
            {
                richTextBox1.ReadOnly = false;
            }
            else
            {
                richTextBox1.ReadOnly = true;
            }
            //

            button4.Visible = false;
        }

        //închiderea aplicației
        private void Form40_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //

        private void videoclipuriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //trecerea la Form-ul cuprinsului, respectiv oprirea coloanei sonore
        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }
        //

        private void howThiefsStealthSystemAlmostDidntWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reține numărul videoclipului
            video = 0;

            //căutarea și memorarea locului unde se află videoclipurile
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Videoclipuri\How Thief's Stealth System Almost Didn't Work - War Stories - Ars Technica.mp4";
            axWindowsMediaPlayer1.URL = url1;
            //

            //pornește videoclipul
            axWindowsMediaPlayer1.Ctlcontrols.play();

            //alege textul în funcție de limbă și videoclip
            if (Clasa_Intrebari.Limba == 1)
            {
                label1.Text = Class3.Titlu[169] + Environment.NewLine + Class3.Titlu[170];

                string text = Application.StartupPath;
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_EN\video1.txt";
                richTextBox1.Text = System.IO.File.ReadAllText(text);
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                label1.Text = "[Thief] Cum mecanicile stealth aproape" + Environment.NewLine + "nu au funcționat";

                string text = Application.StartupPath;
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_RO\video1.txt";
                richTextBox1.Text = System.IO.File.ReadAllText(text);
            }
            //

            button4.Visible = false;
        }

        private void lookingGlassStudiosRetrospective13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reține numărul videoclipului
            video = 1;

            //căutarea și memorarea locului unde se află videoclipurile
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Videoclipuri\Looking Glass Studios Retrospective 1-3 (Origin Systems, Ultima Underworld 1, Ultima Underworld 2).mp4";
            axWindowsMediaPlayer1.URL = url1;
            //

            //pornește videoclipul
            axWindowsMediaPlayer1.Ctlcontrols.play();

            //alege textul în funcție de limbă și videoclip
            if (Clasa_Intrebari.Limba == 1)
            {
                label1.Text = Class3.Titlu[172] + Environment.NewLine + Class3.Titlu[173];

                string text = Application.StartupPath;
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_EN\video2.txt";
                richTextBox1.Text = System.IO.File.ReadAllText(text);
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                label1.Text = "Retrospectiva studioului Looking Glass," + Environment.NewLine + "partea I";

                string text = Application.StartupPath;
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_RO\video2.txt";
                richTextBox1.Text = System.IO.File.ReadAllText(text);
            }
            //

            button4.Visible = false;
        }

        private void lookingGlassStudiosRetrospective23ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reține numărul videoclipului
            video = 2;

            //căutarea și memorarea locului unde se află videoclipurile
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Videoclipuri\Looking Glass Studios Retrospective 2-3 (System Shock, Thief- The Dark Project, Terra Nova).mp4";
            axWindowsMediaPlayer1.URL = url1;
            //

            //pornește videoclipul
            axWindowsMediaPlayer1.Ctlcontrols.play();

            //alege textul în funcție de limbă și videoclip
            if (Clasa_Intrebari.Limba == 1)
            {
                label1.Text = Class3.Titlu[172] + Environment.NewLine + Class3.Titlu[174];

                string text = Application.StartupPath;
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_EN\video3.txt";
                richTextBox1.Text = System.IO.File.ReadAllText(text);
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                label1.Text = "Retrospectiva studioului Looking Glass," + Environment.NewLine + "partea II";

                string text = Application.StartupPath;
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_RO\video3.txt";
                richTextBox1.Text = System.IO.File.ReadAllText(text);
            }
            //

            button4.Visible = false;
        }

        private void lookingGlassStudiosRetrospective33ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reține numărul videoclipului
            video = 3;

            //căutarea și memorarea locului unde se află videoclipurile
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Videoclipuri\Looking Glass Studios Retrospective 3-3 (System Shock 2, Thief II- The Metal Age, Legacy).mp4";
            axWindowsMediaPlayer1.URL = url1;
            //

            //pornește videoclipul
            axWindowsMediaPlayer1.Ctlcontrols.play();

            //alege textul în funcție de limbă și videoclip
            if (Clasa_Intrebari.Limba == 1)
            {
                label1.Text = Class3.Titlu[172] + Environment.NewLine + Class3.Titlu[175];

                string text = Application.StartupPath;
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_EN\video4.txt";
                richTextBox1.Text = System.IO.File.ReadAllText(text);
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                label1.Text = "Retrospectiva studioului Looking Glass," + Environment.NewLine + "partea III";

                string text = Application.StartupPath;
                text = text.Substring(0, text.Length - 10);
                text = text + @"\texte_RO\video4.txt";
                richTextBox1.Text = System.IO.File.ReadAllText(text);
            }
            //

            button4.Visible = false;
        }

        //deschide browser-ul și intră pe link-ul adecvat videoclipului
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (video == 0)
                Process.Start("https://youtu.be/qzD9ldLoc3c");
            else if (video == 1)
                Process.Start("https://youtu.be/nlcha6A8Ugs");
            else if (video == 2)
                Process.Start("https://youtu.be/pkPtjNDOJkE");
            else if (video == 3)
                Process.Start("https://youtu.be/pfr_6-qI5o4");
        }
        //

        //informații suplimentare legate de butoane
        ToolTip tip = new ToolTip();
        private void button3_MouseHover(object sender, EventArgs e)
        {
            tip.ToolTipTitle = "";
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce înapoi.", button3);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[124], button3);
            }
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            if (video == 0)
            {
                tip.ToolTipTitle = "Ars Technica";
                tip.Show("https://youtu.be/qzD9ldLoc3c", linkLabel1);
            }
            else if (video == 1)
            {
                tip.ToolTipTitle = "Indigo Gaming";
                tip.Show("https://youtu.be/nlcha6A8Ugs", linkLabel1);
            }
            else if (video == 2)
            {
                tip.ToolTipTitle = "Indigo Gaming";
                tip.Show("https://youtu.be/pkPtjNDOJkE", linkLabel1);
            }
            else if (video == 3)
            {
                tip.ToolTipTitle = "Indigo Gaming";
                tip.Show("https://youtu.be/pfr_6-qI5o4", linkLabel1);
            }
        }
        //

        //închide anunțul
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            label2.Visible = false;
            button1.Visible = false;
        }
        //

        //informații suplimentare legate de butoane
        private void button4_MouseHover(object sender, EventArgs e)
        {
            tip.ToolTipTitle = "";

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
            //în funcție de limbă
            if (Clasa_Intrebari.Limba == 1)
            {
                //în funcție de videoclip
                if (video == 0)
                {
                    string text = Application.StartupPath;
                    text = text.Substring(0, text.Length - 10);
                    text = text + @"\texte_EN\video1.txt";
                    System.IO.File.WriteAllText(text, richTextBox1.Text);

                    MessageBox.Show(Class3.Titlu[166], Class3.Titlu[165], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.Visible = false;
                }
                else if (video == 1)
                {
                    string text = Application.StartupPath;
                    text = text.Substring(0, text.Length - 10);
                    text = text + @"\texte_EN\video2.txt";
                    System.IO.File.WriteAllText(text, richTextBox1.Text);

                    MessageBox.Show(Class3.Titlu[166], Class3.Titlu[165], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.Visible = false;
                }
                else if (video == 2)
                {
                    string text = Application.StartupPath;
                    text = text.Substring(0, text.Length - 10);
                    text = text + @"\texte_EN\video3.txt";
                    System.IO.File.WriteAllText(text, richTextBox1.Text);

                    MessageBox.Show(Class3.Titlu[166], Class3.Titlu[165], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.Visible = false;
                }
                else if (video == 3)
                {
                    string text = Application.StartupPath;
                    text = text.Substring(0, text.Length - 10);
                    text = text + @"\texte_EN\video4.txt";
                    System.IO.File.WriteAllText(text, richTextBox1.Text);

                    MessageBox.Show(Class3.Titlu[166], Class3.Titlu[165], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.Visible = false;
                }
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                //în funcție de videoclip
                if (video == 0)
                {
                    string text = Application.StartupPath;
                    text = text.Substring(0, text.Length - 10);
                    text = text + @"\texte_RO\video1.txt";
                    System.IO.File.WriteAllText(text, richTextBox1.Text);

                    MessageBox.Show("Textul a fost salvat.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.Visible = false;
                }
                else if (video == 1)
                {
                    string text = Application.StartupPath;
                    text = text.Substring(0, text.Length - 10);
                    text = text + @"\texte_RO\video2.txt";
                    System.IO.File.WriteAllText(text, richTextBox1.Text);

                    MessageBox.Show("Textul a fost salvat.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.Visible = false;
                }
                else if (video == 2)
                {
                    string text = Application.StartupPath;
                    text = text.Substring(0, text.Length - 10);
                    text = text + @"\texte_RO\video3.txt";
                    System.IO.File.WriteAllText(text, richTextBox1.Text);

                    MessageBox.Show("Textul a fost salvat.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.Visible = false;
                }
                else if (video == 3)
                {
                    string text = Application.StartupPath;
                    text = text.Substring(0, text.Length - 10);
                    text = text + @"\texte_RO\video4.txt";
                    System.IO.File.WriteAllText(text, richTextBox1.Text);

                    MessageBox.Show("Textul a fost salvat.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.Visible = false;
                }
            }
        }
        //

        //când textul se modifică, butonul de salvare devine utilizabil
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button4.Visible = true;
        }
        //
    }
}
