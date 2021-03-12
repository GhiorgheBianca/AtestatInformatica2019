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
    public partial class CreareCont : Form
    {
        public CreareCont()
        {
            InitializeComponent();
        }

        private void Form34_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form34_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
            con.Open();

            if (checkBox1.Checked == true && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox4.Text != "" && ((comboBox1.Text != "      -" && comboBox2.Text != "      -" && comboBox3.Text != "         -") || (comboBox1.Text == "      -" && comboBox2.Text == "      -" && comboBox3.Text == "         -")) && comboBox5.Text != "" && textBox4.Text != "")
            {
                textBox1.BackColor = System.Drawing.Color.White;
                textBox1.ForeColor = System.Drawing.Color.Black;
                textBox3.BackColor = System.Drawing.Color.White;
                textBox3.ForeColor = System.Drawing.Color.Black;
                comboBox1.BackColor = System.Drawing.Color.White;
                comboBox1.ForeColor = System.Drawing.Color.Black;
                comboBox2.BackColor = System.Drawing.Color.White;
                comboBox2.ForeColor = System.Drawing.Color.Black;
                comboBox3.BackColor = System.Drawing.Color.White;
                comboBox3.ForeColor = System.Drawing.Color.Black;
                comboBox4.BackColor = System.Drawing.Color.White;
                comboBox4.ForeColor = System.Drawing.Color.Black;
                comboBox5.BackColor = System.Drawing.Color.White;
                comboBox5.ForeColor = System.Drawing.Color.Black;
                textBox4.BackColor = System.Drawing.Color.White;
                textBox4.ForeColor = System.Drawing.Color.Black;

                string querry1 = @"SELECT * FROM Accounts WHERE Email = '" + textBox2.Text + "' ";

                SqlCommand com1 = new SqlCommand(querry1, con);
                SqlDataReader reader1 = com1.ExecuteReader();

                if (reader1.HasRows == true)
                {
                    reader1.Close();

                    textBox2.BackColor = System.Drawing.Color.Firebrick;
                    textBox2.ForeColor = System.Drawing.Color.White;

                    if (Clasa_Intrebari.Limba == 0)
                        MessageBox.Show("Email-ul există deja în baza de date.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (Clasa_Intrebari.Limba == 1)
                        MessageBox.Show(Class3.Titlu[72], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (reader1.HasRows == false)
                {
                    reader1.Close();

                    textBox2.BackColor = System.Drawing.Color.White;
                    textBox2.ForeColor = System.Drawing.Color.Black;

                    string Name, Email, Password, Birthday, Security_Answer;
                    int Gender, Connection = 0, Security_Question, Status = 0;
                    Name = textBox1.Text;
                    Email = textBox2.Text;
                    Password = textBox3.Text;
                    Birthday = comboBox2.Text + "/" + comboBox1.Text + "/" + comboBox3.Text;
                    Gender = comboBox4.SelectedIndex;
                    Security_Question = comboBox5.SelectedIndex;
                    Security_Answer = textBox4.Text;

                    string querry;
                    if (comboBox1.Text != "      -" && comboBox2.Text != "      -" && comboBox3.Text != "         -")
                        querry = @"INSERT INTO Accounts (Name, Email, Password, Birthday, Gender, Connection, Security_Question, Security_Answer, Status) VALUES ('" + Name + "' , '" + Email + "' , '" + Password + "' , '" + Birthday + "' , '" + Gender + "' , '" + Connection + "' , '" + Security_Question + "' , '" + Security_Answer + "' , '" + Status + "')";
                    else querry = @"INSERT INTO Accounts (Name, Email, Password, Gender, Connection, Security_Question, Security_Answer, Status) VALUES ('" + Name + "' , '" + Email + "' , '" + Password + "' , '" + Gender + "' , '" + Connection + "' , '" + Security_Question + "' , '" + Security_Answer + "' , '" + Status + "')";

                    SqlCommand com = new SqlCommand(querry, con);
                    com.ExecuteNonQuery();


                    if (Clasa_Intrebari.Limba == 0)
                        MessageBox.Show("Proces finalizat cu succes.", "Date înregistrate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Clasa_Intrebari.Limba == 1)
                        MessageBox.Show(Class3.Titlu[59], Class3.Titlu[88], MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Login f32 = new Login();
                    f32.Show();
                }
            }
            else if(checkBox1.Checked == true)
            {
                if(textBox1.Text == "")
                {
                    textBox1.BackColor = System.Drawing.Color.Firebrick;
                    textBox1.ForeColor = System.Drawing.Color.White;
                }
                else if(textBox1.Text != "")
                {
                    textBox1.BackColor = System.Drawing.Color.White;
                    textBox1.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox2.Text == "")
                {
                    textBox2.BackColor = System.Drawing.Color.Firebrick;
                    textBox2.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox2.Text != "")
                {
                    textBox2.BackColor = System.Drawing.Color.White;
                    textBox2.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox3.Text == "")
                {
                    textBox3.BackColor = System.Drawing.Color.Firebrick;
                    textBox3.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox3.Text != "")
                {
                    textBox3.BackColor = System.Drawing.Color.White;
                    textBox3.ForeColor = System.Drawing.Color.Black;
                }

                if (comboBox1.Text == "      -" && (comboBox2.Text != "      -" || comboBox3.Text != "         -"))
                {
                    comboBox1.BackColor = System.Drawing.Color.Firebrick;
                    comboBox1.ForeColor = System.Drawing.Color.White;
                }
                else if (comboBox1.Text != "")
                {
                    comboBox1.BackColor = System.Drawing.Color.White;
                    comboBox1.ForeColor = System.Drawing.Color.Black;
                }

                if (comboBox2.Text == "      -" && (comboBox1.Text != "      -" || comboBox3.Text != "         -"))
                {
                    comboBox2.BackColor = System.Drawing.Color.Firebrick;
                    comboBox2.ForeColor = System.Drawing.Color.White;
                }
                else if (comboBox2.Text != "")
                {
                    comboBox2.BackColor = System.Drawing.Color.White;
                    comboBox2.ForeColor = System.Drawing.Color.Black;
                }

                if (comboBox3.Text == "         -" && (comboBox2.Text != "      -" || comboBox1.Text != "      -"))
                {
                    comboBox3.BackColor = System.Drawing.Color.Firebrick;
                    comboBox3.ForeColor = System.Drawing.Color.White;
                }
                else if (comboBox3.Text != "")
                {
                    comboBox3.BackColor = System.Drawing.Color.White;
                    comboBox3.ForeColor = System.Drawing.Color.Black;
                }

                if (comboBox4.Text == "")
                {
                    comboBox4.BackColor = System.Drawing.Color.Firebrick;
                    comboBox4.ForeColor = System.Drawing.Color.White;
                }
                else if (comboBox4.Text != "")
                {
                    comboBox4.BackColor = System.Drawing.Color.White;
                    comboBox4.ForeColor = System.Drawing.Color.Black;
                }

                if(comboBox5.Text == "")
                {
                    comboBox5.BackColor = System.Drawing.Color.Firebrick;
                    comboBox5.ForeColor = System.Drawing.Color.White;
                }
                else if(comboBox5.Text != "")
                {
                    comboBox5.BackColor = System.Drawing.Color.White;
                    comboBox5.ForeColor = System.Drawing.Color.Black;
                }

                if (textBox4.Text == "")
                {
                    textBox4.BackColor = System.Drawing.Color.Firebrick;
                    textBox4.ForeColor = System.Drawing.Color.White;
                }
                else if (textBox4.Text != "")
                {
                    textBox4.BackColor = System.Drawing.Color.White;
                    textBox4.ForeColor = System.Drawing.Color.Black;
                }

                if (Clasa_Intrebari.Limba == 0) MessageBox.Show("Vă rugăm să completați toate spațiile obligatorii.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Clasa_Intrebari.Limba == 1) MessageBox.Show(Class3.Titlu[57], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkBox1.Checked == false)
            {
                if (Clasa_Intrebari.Limba == 0) MessageBox.Show("Vă rugăm să bifați căsuța pentru a fi de acord cu procesarea datelor.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (Clasa_Intrebari.Limba == 1) MessageBox.Show(Class3.Titlu[56], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f32 = new Login();
            f32.Show();
        }

        private void Form34_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[0];

            if (Clasa_Intrebari.Limba == 1)
            {
                button1.Text = Class3.Titlu[60];
                label5.Text = Class3.Titlu[61];
                label4.Text = Class3.Titlu[62];
                checkBox1.Text = Class3.Titlu[63];
                label3.Text = Class3.Titlu[64];
                label1.Text = Class3.Titlu[65];
                label6.Text = Class3.Titlu[66];
                label7.Text = Class3.Titlu[67];
                comboBox4.Items.Clear();
                comboBox4.Items.Add(Class3.Titlu[70]);
                comboBox4.Items.Add(Class3.Titlu[71]);
                comboBox1.Left = +126;
                comboBox2.Left = +186;
                comboBox3.Left = +246;
                label6.Left = +339;
                textBox3.Left = +145;
                textBox1.Left = +217;
                comboBox4.Left = +118;
                label8.Text = Class3.Titlu[89];
                comboBox5.Left = +196;
                label9.Text = Class3.Titlu[90];
                textBox4.Left = +124;
                comboBox5.Items.Clear();
                comboBox5.Items.Add(Class3.Titlu[91]);
                comboBox5.Items.Add(Class3.Titlu[92]);
                comboBox5.Items.Add(Class3.Titlu[93]);
                comboBox5.Items.Add(Class3.Titlu[94]);
                comboBox5.Items.Add(Class3.Titlu[95]);
                comboBox5.Items.Add(Class3.Titlu[96]);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 0)
                pictureBox1.Image = imageList1.Images[2];
            else if (comboBox4.SelectedIndex == 1)
                pictureBox1.Image = imageList1.Images[1];
        }
    }
}
