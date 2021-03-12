using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LGS
{
    public partial class Joc_Xsi0 : Form
    {
        public Joc_Xsi0()
        {
            InitializeComponent();
        }

        int i = 1, x = 0, o = 0;
        bool b = false;

        private void Form24_Load(object sender, EventArgs e)
        {
            //stabilirea limbii pentru acest Form și înlocuirea cu textul tradus, în cazul în care limba selectată este engleză
            if (Clasa_Intrebari.Limba == 1)
            {
                label2.Text = Class3.Titlu[36];
                label1.Text = Class3.Titlu[37];
                label3.Text = Class3.Titlu[105];
                label4.Text = Class3.Titlu[106];
            }
            //

            label2.Visible = false;
            textBox2.Visible = false;

            //dacă utilizatorul este logat, îi va trece email-ul în primul textBox iar în caz contrar, va face ca în textBox să se poată scrie
            if (Clasa_Conectare.conectat != "")
                textBox3.Text = Clasa_Conectare.conectat;
            else if (Clasa_Conectare.conectat == "")
                textBox3.ReadOnly = false;
            //

            //stabilește cine începe jocul printr-o variabilă aleatoare
            Random rnd = new Random();
            int nr = rnd.Next(0, 2);
            if (nr == 0)
                textBox1.Text = "X";
            else
            {
                textBox1.Text = "0";
                b = true;
            }
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //stabilește ce text urmează să fie trecut în butonul curent (X sau 0) conform anumitor date
            if (textBox2.Visible == false && button1.Text == "" && textBox3.Text != "" && textBox4.Text != "" && textBox3.Text != textBox4.Text)
            {
                textBox3.BackColor = System.Drawing.Color.White;
                textBox3.ForeColor = System.Drawing.Color.Black;
                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;

                if (b == false)
                {
                    button1.Text = "X";
                    textBox1.Text = "0";
                    b = true;
                }
                else
                {
                    button1.Text = "0";
                    textBox1.Text = "X";
                    b = false;
                }
                i++;
            }
            //

            //stabilește dacă jocul s-a terminat
            else if(textBox2.Visible == true)
            {
                if(Clasa_Intrebari.Limba == 0)
                MessageBox.Show("Joc terminat. Nu se mai pot efectua modificări.", "Sfârșit de joc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show(Class3.Titlu[41], Class3.Titlu[103], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //

            //stabilește dacă nu sunt completate datele esențiale sau dacă se repetă
            else if(textBox3.Text == "" || textBox4.Text == "")
            {
                //stabilește culoarea textBox-urilor în funcție de gradul de completare a fiecăruia
                if(textBox3.Text == "")
                {
                    textBox3.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox3.ForeColor = System.Drawing.Color.White;
                }
                else if(textBox3.Text != "")
                {
                    textBox3.BackColor = System.Drawing.Color.White;
                    textBox3.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox4.Text == "")
                {
                    textBox4.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox4.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox4.Text != "")
                {
                    textBox4.BackColor = System.Drawing.Color.White;
                    textBox4.ForeColor = System.Drawing.Color.Black;
                }
                //

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Completați datele înainte de a începe jocul.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(Class3.Titlu[57], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(textBox3.Text == textBox4.Text)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    if(Class2.Gen == 1)
                    MessageBox.Show("Nu poți juca cu tine însuți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if(Class2.Gen == 0)
                    MessageBox.Show("Nu poți juca cu tine însăți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(Class3.Titlu[113], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //

            //verifică dacă, prin apăsarea butonului curent, s-a stabilit un câștigător
                if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X")
                {
                    label2.Visible = true;
                    textBox2.Visible = true;
                    if (Clasa_Intrebari.Limba == 0)
                        textBox2.Text = "Jucătorul cu X a câştigat!";
                    else textBox2.Text = Class3.Titlu[38];
                x++;
                }
                else if (button1.Text == "0" && button2.Text == "0" && button3.Text == "0")
                {
                    label2.Visible = true;
                    textBox2.Visible = true;
                    if (Clasa_Intrebari.Limba == 0)
                        textBox2.Text = "Jucătorul cu 0 a câştigat!";
                    else textBox2.Text = Class3.Titlu[39];
                o++;
                }
                else if (button1.Text == "X" && button4.Text == "X" && button7.Text == "X")
                {
                    label2.Visible = true;
                    textBox2.Visible = true;
                    if (Clasa_Intrebari.Limba == 0)
                        textBox2.Text = "Jucătorul cu X a câştigat!";
                    else textBox2.Text = Class3.Titlu[38];
                x++;
                }
                else if (button1.Text == "0" && button4.Text == "0" && button7.Text == "0")
                {
                    label2.Visible = true;
                    textBox2.Visible = true;
                    if (Clasa_Intrebari.Limba == 0)
                        textBox2.Text = "Jucătorul cu 0 a câştigat!";
                    else textBox2.Text = Class3.Titlu[39];
                o++;
                }
                else if (button1.Text == "X" && button5.Text == "X" && button9.Text == "X")
                {
                    label2.Visible = true;
                    textBox2.Visible = true;
                    if (Clasa_Intrebari.Limba == 0)
                        textBox2.Text = "Jucătorul cu X a câştigat!";
                    else textBox2.Text = Class3.Titlu[38];
                x++;
                }
                else if (button1.Text == "0" && button5.Text == "0" && button9.Text == "0")
                {
                    label2.Visible = true;
                    textBox2.Visible = true;
                    if (Clasa_Intrebari.Limba == 0)
                        textBox2.Text = "Jucătorul cu 0 a câştigat!";
                    else textBox2.Text = Class3.Titlu[39];
                o++;
                }
            //

            //verifică dacă s-au completat toate spațiile și, în caz afirmativ, stabilește că nimeni nu a câștigat
                else if (i > 9 && textBox2.Visible == false)
                {
                    label2.Visible = true;
                    textBox2.Visible = true;
                    if (Clasa_Intrebari.Limba == 0)
                        textBox2.Text = "Nimeni nu a câştigat.";
                    else textBox2.Text = Class3.Titlu[40];
                }
            //

            //la terminarea meciului, trece în tabelul "Xand0" rezultatul final
            if(textBox2.Visible == true)
            {
                    SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                    con.Open();
                    DateTime dateTime = DateTime.Now;
                    string querry = @"INSERT INTO Xand0 (Email_X, Email_0, Win_X, Win_0, Overall, Date) VALUES ('" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + x + "' , '" + o + "' , '" + 1 + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + "')";

                    SqlCommand com = new SqlCommand(querry, con);
                    com.ExecuteNonQuery();
            }
            //
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //stabilește ce text urmează să fie trecut în butonul curent (X sau 0) conform anumitor date
            if (textBox2.Visible == false && button2.Text == "" && textBox3.Text != "" && textBox4.Text != "" && textBox3.Text != textBox4.Text)
            {
                textBox3.BackColor = System.Drawing.Color.White;
                textBox3.ForeColor = System.Drawing.Color.Black;
                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;

                if (b == false)
                {
                    button2.Text = "X";
                    textBox1.Text = "0";
                    b = true;
                }
                else
                {
                    button2.Text = "0";
                    textBox1.Text = "X";
                    b = false;
                }
                i++;
            }
            //

            //stabilește dacă jocul s-a terminat
            else if (textBox2.Visible == true)
            {
                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Joc terminat. Nu se mai pot efectua modificări.", "Sfârșit de joc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show(Class3.Titlu[41], Class3.Titlu[103], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //

            //stabilește dacă nu sunt completate datele esențiale sau dacă se repetă
            else if (textBox3.Text == "" || textBox4.Text == "")
            {
                //stabilește culoarea textBox-urilor în funcție de gradul de completare a fiecăruia
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox3.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox3.Text != "")
                {
                    textBox3.BackColor = System.Drawing.Color.White;
                    textBox3.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox4.Text == "")
                {
                    textBox4.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox4.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox4.Text != "")
                {
                    textBox4.BackColor = System.Drawing.Color.White;
                    textBox4.ForeColor = System.Drawing.Color.Black;
                }
                //

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Completați datele înainte de a începe jocul.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(Class3.Titlu[57], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox3.Text == textBox4.Text)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    if (Class2.Gen == 1)
                        MessageBox.Show("Nu poți juca cu tine însuți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Class2.Gen == 0)
                        MessageBox.Show("Nu poți juca cu tine însăți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(Class3.Titlu[113], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //

            //verifică dacă, prin apăsarea butonului curent, s-a stabilit un câștigător
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button1.Text == "0" && button2.Text == "0" && button3.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button5.Text == "X" && button2.Text == "X" && button8.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button5.Text == "0" && button2.Text == "0" && button8.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            //

            //verifică dacă s-au completat toate spațiile și, în caz afirmativ, stabilește că nimeni nu a câștigat
            else if (i > 9 && textBox2.Visible == false)
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Nimeni nu a câştigat.";
                else textBox2.Text = Class3.Titlu[40];
            }
            //

            //la terminarea meciului, trece în tabelul "Xand0" rezultatul final
            if (textBox2.Visible == true)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                DateTime dateTime = DateTime.Now;
                string querry = @"INSERT INTO Xand0 (Email_X, Email_0, Win_X, Win_0, Overall, Date) VALUES ('" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + x + "' , '" + o + "' , '" + 1 + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + "')";

                SqlCommand com = new SqlCommand(querry, con);
                com.ExecuteNonQuery();
            }
            //
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //stabilește ce text urmează să fie trecut în butonul curent (X sau 0) conform anumitor date
            if (textBox2.Visible == false && button3.Text == "" && textBox3.Text != "" && textBox4.Text != "" && textBox3.Text != textBox4.Text)
            {
                textBox3.BackColor = System.Drawing.Color.White;
                textBox3.ForeColor = System.Drawing.Color.Black;
                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;

                if (b == false)
                {
                    button3.Text = "X";
                    textBox1.Text = "0";
                    b = true;
                }
                else
                {
                    button3.Text = "0";
                    textBox1.Text = "X";
                    b = false;
                }
                i++;
            }
            //

            //stabilește dacă jocul s-a terminat
            else if (textBox2.Visible == true)
            {
                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Joc terminat. Nu se mai pot efectua modificări.", "Sfârșit de joc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show(Class3.Titlu[41], Class3.Titlu[103], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //

            //stabilește dacă nu sunt completate datele esențiale sau dacă se repetă
            else if (textBox3.Text == "" || textBox4.Text == "")
            {
                //stabilește culoarea textBox-urilor în funcție de gradul de completare a fiecăruia
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox3.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox3.Text != "")
                {
                    textBox3.BackColor = System.Drawing.Color.White;
                    textBox3.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox4.Text == "")
                {
                    textBox4.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox4.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox4.Text != "")
                {
                    textBox4.BackColor = System.Drawing.Color.White;
                    textBox4.ForeColor = System.Drawing.Color.Black;
                }
                //

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Completați datele înainte de a începe jocul.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(Class3.Titlu[57], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox3.Text == textBox4.Text)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    if (Class2.Gen == 1)
                        MessageBox.Show("Nu poți juca cu tine însuți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Class2.Gen == 0)
                        MessageBox.Show("Nu poți juca cu tine însăți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(Class3.Titlu[113], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //

            //verifică dacă, prin apăsarea butonului curent, s-a stabilit un câștigător
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button1.Text == "0" && button2.Text == "0" && button3.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button3.Text == "X" && button6.Text == "X" && button9.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button3.Text == "0" && button6.Text == "0" && button9.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button3.Text == "0" && button5.Text == "0" && button7.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            //

            //verifică dacă s-au completat toate spațiile și, în caz afirmativ, stabilește că nimeni nu a câștigat
            else if (i > 9 && textBox2.Visible == false)
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Nimeni nu a câştigat.";
                else textBox2.Text = Class3.Titlu[40];
            }
            //

            //la terminarea meciului, trece în tabelul "Xand0" rezultatul final
            if (textBox2.Visible == true)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                DateTime dateTime = DateTime.Now;
                string querry = @"INSERT INTO Xand0 (Email_X, Email_0, Win_X, Win_0, Overall, Date) VALUES ('" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + x + "' , '" + o + "' , '" + 1 + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + "')";

                SqlCommand com = new SqlCommand(querry, con);
                com.ExecuteNonQuery();
            }
            //
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //stabilește ce text urmează să fie trecut în butonul curent (X sau 0) conform anumitor date
            if (textBox2.Visible == false && button4.Text == "" && textBox3.Text != "" && textBox4.Text != "" && textBox3.Text != textBox4.Text)
            {
                textBox3.BackColor = System.Drawing.Color.White;
                textBox3.ForeColor = System.Drawing.Color.Black;
                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;

                if (b == false)
                {
                    button4.Text = "X";
                    textBox1.Text = "0";
                    b = true;
                }
                else
                {
                    button4.Text = "0";
                    textBox1.Text = "X";
                    b = false;
                }
                i++;
            }
            //

            //stabilește dacă jocul s-a terminat
            else if (textBox2.Visible == true)
            {
                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Joc terminat. Nu se mai pot efectua modificări.", "Sfârșit de joc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show(Class3.Titlu[41], Class3.Titlu[103], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //

            //stabilește dacă nu sunt completate datele esențiale sau dacă se repetă
            else if (textBox3.Text == "" || textBox4.Text == "")
            {
                //stabilește culoarea textBox-urilor în funcție de gradul de completare a fiecăruia
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox3.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox3.Text != "")
                {
                    textBox3.BackColor = System.Drawing.Color.White;
                    textBox3.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox4.Text == "")
                {
                    textBox4.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox4.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox4.Text != "")
                {
                    textBox4.BackColor = System.Drawing.Color.White;
                    textBox4.ForeColor = System.Drawing.Color.Black;
                }
                //

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Completați datele înainte de a începe jocul.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(Class3.Titlu[57], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox3.Text == textBox4.Text)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    if (Class2.Gen == 1)
                        MessageBox.Show("Nu poți juca cu tine însuți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Class2.Gen == 0)
                        MessageBox.Show("Nu poți juca cu tine însăți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(Class3.Titlu[113], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //

            //verifică dacă, prin apăsarea butonului curent, s-a stabilit un câștigător
            if (button4.Text == "X" && button5.Text == "X" && button6.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button4.Text == "0" && button5.Text == "0" && button6.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button1.Text == "X" && button4.Text == "X" && button7.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button1.Text == "0" && button4.Text == "0" && button7.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            //

            //verifică dacă s-au completat toate spațiile și, în caz afirmativ, stabilește că nimeni nu a câștigat
            else if (i > 9 && textBox2.Visible == false)
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Nimeni nu a câştigat.";
                else textBox2.Text = Class3.Titlu[40];
            }
            //

            //la terminarea meciului, trece în tabelul "Xand0" rezultatul final
            if (textBox2.Visible == true)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                DateTime dateTime = DateTime.Now;
                string querry = @"INSERT INTO Xand0 (Email_X, Email_0, Win_X, Win_0, Overall, Date) VALUES ('" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + x + "' , '" + o + "' , '" + 1 + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + "')";

                SqlCommand com = new SqlCommand(querry, con);
                com.ExecuteNonQuery();
            }
            //
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //stabilește ce text urmează să fie trecut în butonul curent (X sau 0) conform anumitor date
            if (textBox2.Visible == false && button5.Text == "" && textBox3.Text != "" && textBox4.Text != "" && textBox3.Text != textBox4.Text)
            {
                textBox3.BackColor = System.Drawing.Color.White;
                textBox3.ForeColor = System.Drawing.Color.Black;
                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;

                if (b == false)
                {
                    button5.Text = "X";
                    textBox1.Text = "0";
                    b = true;
                }
                else
                {
                    button5.Text = "0";
                    textBox1.Text = "X";
                    b = false;
                }
                i++;
            }
            //

            //stabilește dacă jocul s-a terminat
            else if (textBox2.Visible == true)
            {
                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Joc terminat. Nu se mai pot efectua modificări.", "Sfârșit de joc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show(Class3.Titlu[41], Class3.Titlu[103], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //

            //stabilește dacă nu sunt completate datele esențiale sau dacă se repetă
            else if (textBox3.Text == "" || textBox4.Text == "")
            {
                //stabilește culoarea textBox-urilor în funcție de gradul de completare a fiecăruia
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox3.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox3.Text != "")
                {
                    textBox3.BackColor = System.Drawing.Color.White;
                    textBox3.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox4.Text == "")
                {
                    textBox4.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox4.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox4.Text != "")
                {
                    textBox4.BackColor = System.Drawing.Color.White;
                    textBox4.ForeColor = System.Drawing.Color.Black;
                }
                //

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Completați datele înainte de a începe jocul.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(Class3.Titlu[57], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox3.Text == textBox4.Text)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    if (Class2.Gen == 1)
                        MessageBox.Show("Nu poți juca cu tine însuți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Class2.Gen == 0)
                        MessageBox.Show("Nu poți juca cu tine însăți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(Class3.Titlu[113], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //

            //verifică dacă, prin apăsarea butonului curent, s-a stabilit un câștigător
            if (button4.Text == "X" && button5.Text == "X" && button6.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button4.Text == "0" && button5.Text == "0" && button6.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button5.Text == "X" && button2.Text == "X" && button8.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button5.Text == "0" && button2.Text == "0" && button8.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button3.Text == "0" && button5.Text == "0" && button7.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button1.Text == "X" && button5.Text == "X" && button9.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button1.Text == "0" && button5.Text == "0" && button9.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            //

            //verifică dacă s-au completat toate spațiile și, în caz afirmativ, stabilește că nimeni nu a câștigat
            else if (i > 9 && textBox2.Visible == false)
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Nimeni nu a câştigat.";
                else textBox2.Text = Class3.Titlu[40];
            }
            //

            //la terminarea meciului, trece în tabelul "Xand0" rezultatul final
            if (textBox2.Visible == true)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                DateTime dateTime = DateTime.Now;
                string querry = @"INSERT INTO Xand0 (Email_X, Email_0, Win_X, Win_0, Overall, Date) VALUES ('" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + x + "' , '" + o + "' , '" + 1 + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + "')";

                SqlCommand com = new SqlCommand(querry, con);
                com.ExecuteNonQuery();
            }
            //
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //stabilește ce text urmează să fie trecut în butonul curent (X sau 0) conform anumitor date
            if (textBox2.Visible == false && button6.Text == "" && textBox3.Text != "" && textBox4.Text != "" && textBox3.Text != textBox4.Text)
            {
                textBox3.BackColor = System.Drawing.Color.White;
                textBox3.ForeColor = System.Drawing.Color.Black;
                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;

                if (b == false)
                {
                    button6.Text = "X";
                    textBox1.Text = "0";
                    b = true;
                }
                else
                {
                    button6.Text = "0";
                    textBox1.Text = "X";
                    b = false;
                }
                i++;
            }
            //

            //stabilește dacă jocul s-a terminat
            else if (textBox2.Visible == true)
            {
                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Joc terminat. Nu se mai pot efectua modificări.", "Sfârșit de joc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show(Class3.Titlu[41], Class3.Titlu[103], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //

            //stabilește dacă nu sunt completate datele esențiale sau dacă se repetă
            else if (textBox3.Text == "" || textBox4.Text == "")
            {
                //stabilește culoarea textBox-urilor în funcție de gradul de completare a fiecăruia
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox3.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox3.Text != "")
                {
                    textBox3.BackColor = System.Drawing.Color.White;
                    textBox3.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox4.Text == "")
                {
                    textBox4.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox4.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox4.Text != "")
                {
                    textBox4.BackColor = System.Drawing.Color.White;
                    textBox4.ForeColor = System.Drawing.Color.Black;
                }
                //

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Completați datele înainte de a începe jocul.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(Class3.Titlu[57], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox3.Text == textBox4.Text)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    if (Class2.Gen == 1)
                        MessageBox.Show("Nu poți juca cu tine însuți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Class2.Gen == 0)
                        MessageBox.Show("Nu poți juca cu tine însăți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(Class3.Titlu[113], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //

            //verifică dacă, prin apăsarea butonului curent, s-a stabilit un câștigător
            if (button4.Text == "X" && button5.Text == "X" && button6.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button4.Text == "0" && button5.Text == "0" && button6.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button3.Text == "X" && button6.Text == "X" && button9.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button3.Text == "0" && button6.Text == "0" && button9.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            //

            //verifică dacă s-au completat toate spațiile și, în caz afirmativ, stabilește că nimeni nu a câștigat
            else if (i > 9 && textBox2.Visible == false)
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Nimeni nu a câştigat.";
                else textBox2.Text = Class3.Titlu[40];
            }
            //

            //la terminarea meciului, trece în tabelul "Xand0" rezultatul final
            if (textBox2.Visible == true)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                DateTime dateTime = DateTime.Now;
                string querry = @"INSERT INTO Xand0 (Email_X, Email_0, Win_X, Win_0, Overall, Date) VALUES ('" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + x + "' , '" + o + "' , '" + 1 + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + "')";

                SqlCommand com = new SqlCommand(querry, con);
                com.ExecuteNonQuery();
            }
            //
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //stabilește ce text urmează să fie trecut în butonul curent (X sau 0) conform anumitor date
            if (textBox2.Visible == false && button7.Text == "" && textBox3.Text != "" && textBox4.Text != "" && textBox3.Text != textBox4.Text)
            {
                textBox3.BackColor = System.Drawing.Color.White;
                textBox3.ForeColor = System.Drawing.Color.Black;
                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;

                if (b == false)
                {
                    button7.Text = "X";
                    textBox1.Text = "0";
                    b = true;
                }
                else
                {
                    button7.Text = "0";
                    textBox1.Text = "X";
                    b = false;
                }
                i++;
            }
            //

            //stabilește dacă jocul s-a terminat
            else if (textBox2.Visible == true)
            {
                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Joc terminat. Nu se mai pot efectua modificări.", "Sfârșit de joc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show(Class3.Titlu[41], Class3.Titlu[103], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //

            //stabilește dacă nu sunt completate datele esențiale sau dacă se repetă
            else if (textBox3.Text == "" || textBox4.Text == "")
            {
                //stabilește culoarea textBox-urilor în funcție de gradul de completare a fiecăruia
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox3.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox3.Text != "")
                {
                    textBox3.BackColor = System.Drawing.Color.White;
                    textBox3.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox4.Text == "")
                {
                    textBox4.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox4.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox4.Text != "")
                {
                    textBox4.BackColor = System.Drawing.Color.White;
                    textBox4.ForeColor = System.Drawing.Color.Black;
                }
                //

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Completați datele înainte de a începe jocul.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(Class3.Titlu[57], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox3.Text == textBox4.Text)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    if (Class2.Gen == 1)
                        MessageBox.Show("Nu poți juca cu tine însuți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Class2.Gen == 0)
                        MessageBox.Show("Nu poți juca cu tine însăți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(Class3.Titlu[113], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //

            //verifică dacă, prin apăsarea butonului curent, s-a stabilit un câștigător
            if (button1.Text == "X" && button4.Text == "X" && button7.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button1.Text == "0" && button4.Text == "0" && button7.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button7.Text == "X" && button8.Text == "X" && button9.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button7.Text == "0" && button8.Text == "0" && button9.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button3.Text == "0" && button5.Text == "0" && button7.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            //

            //verifică dacă s-au completat toate spațiile și, în caz afirmativ, stabilește că nimeni nu a câștigat
            else if (i > 9 && textBox2.Visible == false)
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if(Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Nimeni nu a câştigat.";
                else textBox2.Text = Class3.Titlu[40];
            }
            //

            //la terminarea meciului, trece în tabelul "Xand0" rezultatul final
            if (textBox2.Visible == true)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                DateTime dateTime = DateTime.Now;
                string querry = @"INSERT INTO Xand0 (Email_X, Email_0, Win_X, Win_0, Overall, Date) VALUES ('" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + x + "' , '" + o + "' , '" + 1 + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + "')";

                SqlCommand com = new SqlCommand(querry, con);
                com.ExecuteNonQuery();
            }
            //
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //stabilește ce text urmează să fie trecut în butonul curent (X sau 0) conform anumitor date
            if (textBox2.Visible == false && button8.Text == "" && textBox3.Text != "" && textBox4.Text != "" && textBox3.Text != textBox4.Text)
            {
                textBox3.BackColor = System.Drawing.Color.White;
                textBox3.ForeColor = System.Drawing.Color.Black;
                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;

                if (b == false)
                {
                    button8.Text = "X";
                    textBox1.Text = "0";
                    b = true;
                }
                else
                {
                    button8.Text = "0";
                    textBox1.Text = "X";
                    b = false;
                }
                i++;
            }
            //

            //stabilește dacă jocul s-a terminat
            else if (textBox2.Visible == true)
            {
                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Joc terminat. Nu se mai pot efectua modificări.", "Sfârșit de joc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show(Class3.Titlu[41], Class3.Titlu[103], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //

            //stabilește dacă nu sunt completate datele esențiale sau dacă se repetă
            else if (textBox3.Text == "" || textBox4.Text == "")
            {
                //stabilește culoarea textBox-urilor în funcție de gradul de completare a fiecăruia
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox3.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox3.Text != "")
                {
                    textBox3.BackColor = System.Drawing.Color.White;
                    textBox3.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox4.Text == "")
                {
                    textBox4.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox4.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox4.Text != "")
                {
                    textBox4.BackColor = System.Drawing.Color.White;
                    textBox4.ForeColor = System.Drawing.Color.Black;
                }
                //

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Completați datele înainte de a începe jocul.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(Class3.Titlu[57], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox3.Text == textBox4.Text)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    if (Class2.Gen == 1)
                        MessageBox.Show("Nu poți juca cu tine însuți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Class2.Gen == 0)
                        MessageBox.Show("Nu poți juca cu tine însăți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(Class3.Titlu[113], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //

            //verifică dacă, prin apăsarea butonului curent, s-a stabilit un câștigător
            if (button7.Text == "X" && button8.Text == "X" && button9.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if(Clasa_Intrebari.Limba == 0)
                textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button7.Text == "0" && button8.Text == "0" && button9.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button5.Text == "X" && button2.Text == "X" && button8.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button5.Text == "0" && button2.Text == "0" && button8.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            //

            //verifică dacă s-au completat toate spațiile și, în caz afirmativ, stabilește că nimeni nu a câștigat
            else if (i > 9 && textBox2.Visible == false)
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Nimeni nu a câştigat.";
                else textBox2.Text = Class3.Titlu[40];
            }
            //

            //la terminarea meciului, trece în tabelul "Xand0" rezultatul final
            if (textBox2.Visible == true)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                DateTime dateTime = DateTime.Now;
                string querry = @"INSERT INTO Xand0 (Email_X, Email_0, Win_X, Win_0, Overall, Date) VALUES ('" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + x + "' , '" + o + "' , '" + 1 + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + "')";

                SqlCommand com = new SqlCommand(querry, con);
                com.ExecuteNonQuery();
            }
            //
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //stabilește ce text urmează să fie trecut în butonul curent (X sau 0) conform anumitor date
            if (textBox2.Visible == false && button9.Text == "" && textBox3.Text != "" && textBox4.Text != "" && textBox3.Text != textBox4.Text)
            {
                textBox3.BackColor = System.Drawing.Color.White;
                textBox3.ForeColor = System.Drawing.Color.Black;
                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;

                if (b == false)
                {
                    button9.Text = "X";
                    textBox1.Text = "0";
                    b = true;
                }
                else
                {
                    button9.Text = "0";
                    textBox1.Text = "X";
                    b = false;
                }
                i++;
            }
            //

            //stabilește dacă jocul s-a terminat
            else if (textBox2.Visible == true)
            {
                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Joc terminat. Nu se mai pot efectua modificări.", "Sfârșit de joc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show(Class3.Titlu[41], Class3.Titlu[103], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //

            //stabilește dacă nu sunt completate datele esențiale sau dacă se repetă
            else if (textBox3.Text == "" || textBox4.Text == "")
            {
                //stabilește culoarea textBox-urilor în funcție de gradul de completare a fiecăruia
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox3.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox3.Text != "")
                {
                    textBox3.BackColor = System.Drawing.Color.White;
                    textBox3.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox4.Text == "")
                {
                    textBox4.BackColor = System.Drawing.Color.SaddleBrown;
                    textBox4.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox4.Text != "")
                {
                    textBox4.BackColor = System.Drawing.Color.White;
                    textBox4.ForeColor = System.Drawing.Color.Black;
                }
                //

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Completați datele înainte de a începe jocul.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(Class3.Titlu[57], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox3.Text == textBox4.Text)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    if (Class2.Gen == 1)
                        MessageBox.Show("Nu poți juca cu tine însuți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Class2.Gen == 0)
                        MessageBox.Show("Nu poți juca cu tine însăți.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(Class3.Titlu[113], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //

            //verifică dacă, prin apăsarea butonului curent, s-a stabilit un câștigător
            if (button1.Text == "X" && button5.Text == "X" && button9.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button1.Text == "0" && button5.Text == "0" && button9.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if(Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button7.Text == "X" && button8.Text == "X" && button9.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button7.Text == "0" && button8.Text == "0" && button9.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            else if (button3.Text == "X" && button6.Text == "X" && button9.Text == "X")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu X a câştigat!";
                else textBox2.Text = Class3.Titlu[38];
                x++;
            }
            else if (button3.Text == "0" && button6.Text == "0" && button9.Text == "0")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Jucătorul cu 0 a câştigat!";
                else textBox2.Text = Class3.Titlu[39];
                o++;
            }
            //

            //verifică dacă s-au completat toate spațiile și, în caz afirmativ, stabilește că nimeni nu a câștigat
            else if (i > 9 && textBox2.Visible == false)
            {
                label2.Visible = true;
                textBox2.Visible = true;
                if (Clasa_Intrebari.Limba == 0)
                    textBox2.Text = "Nimeni nu a câştigat.";
                else textBox2.Text = Class3.Titlu[40];
            }
            //

            //la terminarea meciului, trece în tabelul "Xand0" rezultatul final
            if (textBox2.Visible == true)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                DateTime dateTime = DateTime.Now;
                string querry = @"INSERT INTO Xand0 (Email_X, Email_0, Win_X, Win_0, Overall, Date) VALUES ('" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + x + "' , '" + o + "' , '" + 1 + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + "')";

                SqlCommand com = new SqlCommand(querry, con);
                com.ExecuteNonQuery();
            }
            //
        }

        //reapelarea Form-ului curent pentru reîmprospătarea datelor
        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Joc_Xsi0 f24 = new Joc_Xsi0();
            f24.Show();
        }
        //

        //informații suplimentare legate de butoane
        ToolTip tip = new ToolTip();
        private void button10_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce înapoi.", button10);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[124], button10);
            }
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a începe un joc nou.", button11);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[138], button11);
            }
        }
        //

        //trecerea la Form-ul cu meniul jocurilor
        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Meniu_Jocuri f33 = new Meniu_Jocuri();
            f33.Show();
        }
        //

        //închiderea aplicației
        private void Form24_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //
    }
}
