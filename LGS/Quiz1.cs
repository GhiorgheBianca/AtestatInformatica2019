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
    public partial class Quiz1 : Form
    {
        public Quiz1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //verificarea întrebărilor, actualizarea punctajului în cazul răspunsurilor corecte și actuaizarea imaginii din dreptul întrebărilor în funcție de corectitudine
            int p = 0;

            if(radioButton1.Checked == true)
            {
                p++;
                pictureBox4.Image = imageList1.Images[0];
                radioButton1.ForeColor = System.Drawing.Color.Black;
            }
            else if(radioButton2.Checked == true || radioButton3.Checked == true)
            {
                pictureBox4.Image = imageList1.Images[1];
            }


            if (radioButton6.Checked == true)
            {
                p++;
                pictureBox6.Image = imageList1.Images[0];
                radioButton6.ForeColor = System.Drawing.Color.Black;
            }
            else if (radioButton4.Checked == true || radioButton5.Checked == true)
            {
                pictureBox6.Image = imageList1.Images[1];
            }


            if (radioButton7.Checked == true)
            {
                p++;
                pictureBox5.Image = imageList1.Images[0];
                radioButton7.ForeColor = System.Drawing.Color.Black;
            }
            else if (radioButton8.Checked == true || radioButton9.Checked == true)
            {
                pictureBox5.Image = imageList1.Images[1];
            }


            if (radioButton11.Checked == true)
            {
                p++;
                pictureBox3.Image = imageList1.Images[0];
                radioButton11.ForeColor = System.Drawing.Color.Black;
            }
            else if (radioButton10.Checked == true || radioButton12.Checked == true)
            {
                pictureBox3.Image = imageList1.Images[1];
            }


            if (radioButton24.Checked == true)
            {
                p++;
                pictureBox2.Image = imageList1.Images[0];
                radioButton24.ForeColor = System.Drawing.Color.Black;
            }
            else if (radioButton22.Checked == true || radioButton23.Checked == true)
            {
                pictureBox2.Image = imageList1.Images[1];
            }


            if (radioButton21.Checked == true)
            {
                p++;
                pictureBox1.Image = imageList1.Images[0];
                radioButton21.ForeColor = System.Drawing.Color.Black;
            }
            else if (radioButton20.Checked == true || radioButton19.Checked == true)
            {
                pictureBox1.Image = imageList1.Images[1];
            }


            if (radioButton17.Checked == true)
            {
                p++;
                pictureBox8.Image = imageList1.Images[0];
                radioButton17.ForeColor = System.Drawing.Color.Black;
            }
            else if (radioButton16.Checked == true || radioButton18.Checked == true)
            {
                pictureBox8.Image = imageList1.Images[1];
            }


            if (radioButton13.Checked == true)
            {
                p++;
                pictureBox7.Image = imageList1.Images[0];
                radioButton13.ForeColor = System.Drawing.Color.Black;
            }
            else if (radioButton14.Checked == true || radioButton15.Checked == true)
            {
                pictureBox7.Image = imageList1.Images[1];
            }
            //

            //afișarea punctajului obținut și, dacă e maxim, întreabă utilizatorul unde dorește să fie redirecționat
            if (Clasa_Intrebari.Limba == 0)
                MessageBox.Show("Punctaj: " + p + "/8", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            else MessageBox.Show("Score: " + p + "/8", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            if (p == 8)
            {
                if (Clasa_Conectare.conectat != "")
                {
                    int lastid = 0;
                    DateTime dateTime = DateTime.Now;

                    //trece în tabel că testul de acomodare a fost făcut dacă utilizatorul este conectat
                    SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                    con.Open();

                    string querry = @"SELECT * FROM Results_Quiz";

                    SqlCommand com = new SqlCommand(querry, con);
                    SqlDataReader reader = com.ExecuteReader();

                    //notează numărul ultimului id
                    while (reader.Read())
                        if (reader.HasRows)
                        {
                            lastid = Int32.Parse(reader["Id"].ToString());
                        }

                    reader.Close();

                    querry = @"INSERT INTO Results_Quiz (Id, Email, Number, Correct, Incorrect, Time, Date, First) VALUES ('" + (lastid + 1) + "' , '" + Clasa_Conectare.conectat + "' , '" + 0 + "' , '" + 0 + "' , '" + 0 + "' , '" + "nu" + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + "' , '" + 1 + "')";

                    SqlCommand com1 = new SqlCommand(querry, con);
                    com1.ExecuteNonQuery();

                    con.Close();
                    //
                }

                //reține că testul a fost făcut
                Class3.Test_acomodare = true;

                //alege limba pentru întrebare
                if (Clasa_Intrebari.Limba == 0)
                {
                    //alege următorul Form în funcție de răspunsul utilizatorului
                    DialogResult dialog_res = MessageBox.Show("Felicitări! Dorești să continui testarea?", "Întrebare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog_res == DialogResult.Yes)
                    {
                        this.Hide();
                        Form41 f41 = new Form41();
                        f41.Show();
                    }
                    else if (dialog_res == DialogResult.No)
                    {
                        this.Hide();
                        Meniu_Jocuri f33 = new Meniu_Jocuri();
                        f33.Show();
                    }
                    //
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    //alege următorul Form în funcție de răspunsul utilizatorului
                    DialogResult dialog_res = MessageBox.Show(Class3.Titlu[178], Class3.Titlu[177], MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog_res == DialogResult.Yes)
                    {
                        this.Hide();
                        Form41 f41 = new Form41();
                        f41.Show();
                    }
                    else if (dialog_res == DialogResult.No)
                    {
                        this.Hide();
                        Meniu_Jocuri f33 = new Meniu_Jocuri();
                        f33.Show();
                    }
                    //
                }
            }
            //
        }

        //trecerea la Form-ul cuprinsului
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }
        //

        //corectarea întrebărilor în cazul celor care sunt bifate cu răspunsul greșit
        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true || radioButton3.Checked == true)
            {
                radioButton1.ForeColor = System.Drawing.Color.Green;
            }

            if (radioButton4.Checked == true || radioButton5.Checked == true)
            {
                radioButton6.ForeColor = System.Drawing.Color.Green;
            }

            if (radioButton8.Checked == true || radioButton9.Checked == true)
            {
                radioButton7.ForeColor = System.Drawing.Color.Green;
            }

            if (radioButton10.Checked == true || radioButton12.Checked == true)
            {
                radioButton11.ForeColor = System.Drawing.Color.Green;
            }

            if (radioButton22.Checked == true || radioButton23.Checked == true)
            {
                radioButton24.ForeColor = System.Drawing.Color.Green;
            }

            if (radioButton20.Checked == true || radioButton19.Checked == true)
            {
                radioButton21.ForeColor = System.Drawing.Color.Green;
            }

            if (radioButton16.Checked == true || radioButton18.Checked == true)
            {
                radioButton17.ForeColor = System.Drawing.Color.Green;
            }

            if (radioButton14.Checked == true || radioButton15.Checked == true)
            {
                radioButton13.ForeColor = System.Drawing.Color.Green;
            }
        }
        //

        //închiderea aplicației
        private void Form12_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //

        private void Form12_Load(object sender, EventArgs e)
        {
            //stabilirea limbii pentru acest Form și înlocuirea cu textul tradus, în cazul în care limba selectată este engleză
            if (Clasa_Intrebari.Limba == 1)
            {
                groupBox1.Text = Class3.Titlu[21];
                groupBox2.Text = Class3.Titlu[22];
                groupBox3.Text = Class3.Titlu[23];
                groupBox4.Text = Class3.Titlu[24];
                groupBox5.Text = Class3.Titlu[28];
                groupBox6.Text = Class3.Titlu[27];
                groupBox7.Text = Class3.Titlu[26];
                groupBox8.Text = Class3.Titlu[25];
                radioButton24.Text = Class3.Titlu[29];
                radioButton21.Text = Class3.Titlu[30];
                radioButton20.Text = Class3.Titlu[31];
                radioButton19.Text = Class3.Titlu[32];
                radioButton18.Text = Class3.Titlu[33];
                button2.Text = Class3.Titlu[13];
                button1.Text = Class3.Titlu[34];
                button3.Text = Class3.Titlu[35];
            }
            //
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        //informații suplimentare legate de butoane
        ToolTip tip = new ToolTip();
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

        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a verifica întrebările.", button1);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[122], button1);
            }
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a corecta întrebările greșite.", button3);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[123], button3);
            }
        }
        //
    }
}
