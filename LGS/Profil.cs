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
    public partial class Profil : Form
    {
        public Profil()
        {
            InitializeComponent();
        }

        int id, i = 0;
        bool bday = false, was = false, first = false;

        string[] nume_prenume = new string[100];

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Editează" || button1.Text == "Edit")
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;

                button2.Enabled = false;
                button4.Enabled = false;

                if (Clasa_Intrebari.Limba == 0)
                    button1.Text = "Gata";
                else if (Clasa_Intrebari.Limba == 1)
                    button1.Text = Class3.Titlu[74];
            }
            else if(button1.Text == "Gata" || button1.Text == "Done")
            {
                bool gata = true;
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    textBox1.BackColor = System.Drawing.Color.White;
                    textBox1.ForeColor = System.Drawing.Color.Black;
                    textBox2.BackColor = System.Drawing.Color.White;
                    textBox2.ForeColor = System.Drawing.Color.Black;
                    textBox3.BackColor = System.Drawing.Color.White;
                    textBox3.ForeColor = System.Drawing.Color.Black;


                    SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);

                    con.Open();
                    string querry;
                    if(comboBox1.Text != "      -" && comboBox2.Text != "      -" && comboBox3.Text != "         -")
                        querry = @"UPDATE Accounts SET Name = @name , Email = @email , Password = @password , Birthday = @birthday WHERE Id = '" + id + "' ";
                    else querry = @"UPDATE Accounts SET Name = @name , Email = @email , Password = @password WHERE Id = '" + id + "' ";

                    SqlCommand com = new SqlCommand(querry, con);
                    com.Parameters.AddWithValue("name", textBox1.Text);
                    com.Parameters.AddWithValue("email", textBox2.Text);
                    com.Parameters.AddWithValue("password", textBox3.Text);

                    if (comboBox1.Text != "      -" && comboBox2.Text != "      -" && comboBox3.Text != "         -")
                        com.Parameters.AddWithValue("birthday", comboBox2.Text + "/" + comboBox1.Text + "/" + comboBox3.Text);
                    else if((comboBox1.Text == "      -" && (comboBox2.Text != "      -" || comboBox3.Text != "         -")) || (comboBox2.Text == "      -" && (comboBox1.Text != "      -" || comboBox3.Text != "         -")) || (comboBox3.Text == "         -" && (comboBox2.Text != "      -" || comboBox1.Text != "      -")))
                    {
                        gata = false;
                        //în cazul necompletării unui spațiu din dată
                        //
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


                        if (Clasa_Intrebari.Limba == 0)
                            MessageBox.Show("Există spații necompletate.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (Clasa_Intrebari.Limba == 1)
                            MessageBox.Show(Class3.Titlu[77], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(comboBox1.Text == "      -" && comboBox2.Text == "      -" && comboBox3.Text == "         -" && was == false)
                    {
                        comboBox1.BackColor = System.Drawing.Color.Firebrick;
                        comboBox1.ForeColor = System.Drawing.Color.White;
                        comboBox2.BackColor = System.Drawing.Color.Firebrick;
                        comboBox2.ForeColor = System.Drawing.Color.White;
                        comboBox3.BackColor = System.Drawing.Color.Firebrick;
                        comboBox3.ForeColor = System.Drawing.Color.White;

                        gata = false;
                        if (Clasa_Intrebari.Limba == 0)
                            MessageBox.Show("Nu puteți șterge data nașterii.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (Clasa_Intrebari.Limba == 1)
                            MessageBox.Show(Class3.Titlu[85], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    com.ExecuteNonQuery();
                    con.Close();
                    
                    if (gata == true)
                    {
                        comboBox1.BackColor = System.Drawing.Color.White;
                        comboBox1.ForeColor = System.Drawing.Color.Black;
                        comboBox2.BackColor = System.Drawing.Color.White;
                        comboBox2.ForeColor = System.Drawing.Color.Black;
                        comboBox3.BackColor = System.Drawing.Color.White;
                        comboBox3.ForeColor = System.Drawing.Color.Black;

                        button2.Enabled = true;
                        button4.Enabled = true;

                        textBox1.ReadOnly = true;
                        textBox2.ReadOnly = true;
                        textBox3.ReadOnly = true;
                        comboBox1.Enabled = false;
                        comboBox2.Enabled = false;
                        comboBox3.Enabled = false;
                        button5.Visible = false;

                        Class3.Adevarat = false;
                        Class3.Parola = textBox3.Text;
                        Clasa_Conectare.conectat = textBox2.Text;

                        textBox3.UseSystemPasswordChar = true;
                        i = 0;
                        button5.Image = imageList2.Images[0];
                    }

                    if (Clasa_Intrebari.Limba == 0 && gata == true)
                        button1.Text = "Editează";
                    else if (Clasa_Intrebari.Limba == 1 && gata == true)
                        button1.Text = Class3.Titlu[75];
                }
                else
                {
                    //în cazul necompletării mai multor spații
                    //
                    if (textBox1.Text == "")
                    {
                        textBox1.BackColor = System.Drawing.Color.Firebrick;
                        textBox1.ForeColor = System.Drawing.Color.White;
                    }
                    else if (textBox1.Text != "")
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


                    if (Clasa_Intrebari.Limba == 0)
                        MessageBox.Show("Există spații necompletate.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (Clasa_Intrebari.Limba == 1)
                        MessageBox.Show(Class3.Titlu[77], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form35_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form35_Load(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 1)
            {
                label1.Text = Class3.Titlu[76];
                button1.Text = Class3.Titlu[75];
                label3.Text = Class3.Titlu[78];
                label4.Text = Class3.Titlu[79];
                button4.Text = Class3.Titlu[80];
                button2.Text = Class3.Titlu[81];
                button6.Text = Class3.Titlu[84];
                button7.Text = Class3.Titlu[87];
                tabControl1.TabPages[1].Text = Class3.Titlu[107];
                tabControl1.TabPages[0].Text = Class3.Titlu[51];
                chart1.Titles[0].Text = Class3.Titlu[108];
                chart1.Series[0].LegendText = Class3.Titlu[115];
                label5.Text = Class3.Titlu[110];
                label6.Text = Class3.Titlu[111];
                label7.Text = Class3.Titlu[112];
                chart2.Titles[0].Text = Class3.Titlu[109];
                label8.Text = Class3.Titlu[114];
                label9.Text = Class3.Titlu[116];
                label10.Text = Class3.Titlu[66];
            }


            SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);

            con.Open();
            string querry = @"SELECT * FROM Accounts";

            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();

            textBox2.Text = Clasa_Conectare.conectat;
            while (reader.Read())
            {
                string email = reader["Email"].ToString();
                if (email == Clasa_Conectare.conectat)
                {
                    textBox1.Text = reader["Name"].ToString();
                    nume_prenume = textBox1.Text.Split(' ').Select(text => text.ToString()).ToArray();
                    Clasa_Conectare.nume_utilizator = nume_prenume[1];
                    Class2.Gen = Int32.Parse(reader["Gender"].ToString());
                    pictureBox1.Image = imageList1.Images[Class2.Gen];
                    id = Int32.Parse(reader["Id"].ToString());
                    textBox3.Text = reader["Password"].ToString();
                    Class3.Parola = reader["Password"].ToString();
                    if (reader["Birthday"].ToString() != "")
                    {
                        DateTime data = Convert.ToDateTime(reader["Birthday"]);
                        string zi = data.Day.ToString(), luna = data.Month.ToString(), an = data.Year.ToString();
                        comboBox1.Text = zi;
                        comboBox2.Text = luna;
                        comboBox3.Text = an;

                        DateTime dateTime = DateTime.Now;
                        if (dateTime.Day == Int32.Parse(zi) && dateTime.Month == Int32.Parse(luna))
                        {
                            bday = true;
                            button6.Visible = true;
                        }
                    }
                    else was = true;

                    Clasa_Conectare.Status = Int32.Parse(reader["Status"].ToString());
                    if(Clasa_Conectare.Status == 1)
                    {
                        button8.Visible = true;
                        if(Clasa_Intrebari.Limba == 1)
                            button8.Text = Class3.Titlu[120];
                    }
                }
            }
            reader.Close();
            con.Close();

            int meciuri = 0, castigate = 0, pierdute = 0, last_month = 0;
            string[] player = new string[100];

            con.Open();
            querry = @"SELECT * FROM Xand0";
            SqlCommand com1 = new SqlCommand(querry, con);
            SqlDataReader reader1 = com1.ExecuteReader();

            while (reader1.Read())
            {
                if (reader1["Email_X"].ToString() == Clasa_Conectare.conectat || reader1["Email_0"].ToString() == Clasa_Conectare.conectat)
                {
                    DateTime dateTime = DateTime.Now;
                    DateTime date = Convert.ToDateTime(reader1["Date"]);
                    meciuri++;
                    if (reader1["Email_X"].ToString() == Clasa_Conectare.conectat)
                    {
                        if(Int32.Parse(reader1["Win_X"].ToString()) == 1)
                            castigate = castigate + Int32.Parse(reader1["Win_X"].ToString());
                        else if(Int32.Parse(reader1["Win_X"].ToString()) == 0 && Int32.Parse(reader1["Win_0"].ToString()) == 1)
                            pierdute = pierdute + Int32.Parse(reader1["Win_0"].ToString());


                        if ((dateTime.Month - date.Month == 1 && date.Day >= dateTime.Day && dateTime.Year - date.Year < 1) || (dateTime.Month - date.Month == 0 && dateTime.Year - date.Year < 1))
                        {
                            last_month++;

                            if (Int32.Parse(reader1["Win_X"].ToString()) == 1)
                                chart1.Series["Meciuri"].Points.AddXY("", 1);
                            else if (Int32.Parse(reader1["Win_X"].ToString()) == 0 && Int32.Parse(reader1["Win_0"].ToString()) == 0)
                                chart1.Series["Meciuri"].Points.AddXY("", 0);
                            else if (Int32.Parse(reader1["Win_X"].ToString()) == 0 && Int32.Parse(reader1["Win_0"].ToString()) == 1)
                                chart1.Series["Meciuri"].Points.AddXY("", -1);
                        }

                        player = reader1["Email_0"].ToString().Split('@').Select(text => text.ToString()).ToArray();
                    }
                    else if (reader1["Email_0"].ToString() == Clasa_Conectare.conectat)
                    {
                        if (Int32.Parse(reader1["Win_0"].ToString()) == 1)
                            castigate = castigate + Int32.Parse(reader1["Win_0"].ToString());
                        else if (Int32.Parse(reader1["Win_0"].ToString()) == 0 && Int32.Parse(reader1["Win_X"].ToString()) == 1)
                            pierdute = pierdute + Int32.Parse(reader1["Win_X"].ToString());


                        if ((dateTime.Month - date.Month == 1 && date.Day >= dateTime.Day && dateTime.Year - date.Year < 1) || (dateTime.Month - date.Month == 0 && dateTime.Year - date.Year < 1))
                        {
                            last_month++;

                            if (Int32.Parse(reader1["Win_0"].ToString()) == 1)
                                chart1.Series["Meciuri"].Points.AddXY("", 1);
                            else if (Int32.Parse(reader1["Win_X"].ToString()) == 0 && Int32.Parse(reader1["Win_0"].ToString()) == 0)
                                chart1.Series["Meciuri"].Points.AddXY("", 0);
                            else if (Int32.Parse(reader1["Win_0"].ToString()) == 0 && Int32.Parse(reader1["Win_X"].ToString()) == 1)
                                chart1.Series["Meciuri"].Points.AddXY("", -1);
                        }

                        player = reader1["Email_X"].ToString().Split('@').Select(text => text.ToString()).ToArray();
                    }
                }
            }
            if (Clasa_Intrebari.Limba == 0)
            {
                chart2.Series["Meciuri"].Points.AddXY("Câștigate", castigate);
                chart2.Series["Meciuri"].Points.AddXY("Pierdute", pierdute);
                chart2.Series["Meciuri"].Points.AddXY("Remiză", meciuri - castigate - pierdute);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                chart2.Series["Meciuri"].Points.AddXY("Win", castigate);
                chart2.Series["Meciuri"].Points.AddXY("Lost", pierdute);
                chart2.Series["Meciuri"].Points.AddXY("Draw", meciuri - castigate - pierdute);
            }
            label8.Text = label8.Text + meciuri.ToString();
            label9.Text = label9.Text + player[0];


            if (meciuri == 0)
            {
                chart1.Visible = false;
                chart2.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                panel1.Visible = false;
                panel3.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                if (Clasa_Intrebari.Limba == 0)
                {
                    label7.Text = "Nu ați jucat acest joc încă.";
                    label7.Location = new Point(200, 62);
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    label7.Text = Class3.Titlu[117];
                    label7.Location = new Point(150, 62);
                }
                label7.Font = new Font("Times New Roman", 32, FontStyle.Italic);
                label7.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                label7.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            }
            else if (last_month == 0)
            {
                chart1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                panel1.Visible = false;
                if (Clasa_Intrebari.Limba == 0)
                {
                    label7.Text = "Nu ați jucat acest joc de mai mult de o lună.";
                    label7.Location = new Point(29, 72);
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    label7.Text = Class3.Titlu[118];
                    label7.Location = new Point(29, 72);
                }
                label7.Font = new Font("Times New Roman", 18, FontStyle.Italic);
                label7.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                label7.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            }

            reader1.Close();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Gata")
            {
                if (Class2.Gen == 0)
                {
                    if (MessageBox.Show("Ești sigură că vrei să părăsești pagina?", "Date nesalvate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        this.Hide();
                        Form4 f4 = new Form4();
                        f4.Show();
                    }
                }
                else if(Class2.Gen == 1)
                {
                    if (MessageBox.Show("Ești sigur că vrei să părăsești pagina?", "Date nesalvate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        this.Hide();
                        Form4 f4 = new Form4();
                        f4.Show();
                    }
                }
            }
            else if(button1.Text == "Done")
            {
                if (MessageBox.Show(Class3.Titlu[200], Class3.Titlu[201], MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.Hide();
                    Form4 f4 = new Form4();
                    f4.Show();
                }
            }
            else if(button1.Text == "Editează" || button1.Text == "Edit")
            {
                this.Hide();
                Form4 f4 = new Form4();
                f4.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 1)
            {
                if (MessageBox.Show("Are you sure you want to delete your account?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);

                    con.Open();
                    string querry = @"DELETE FROM Accounts WHERE Id = '" + id + "' ";

                    SqlCommand com = new SqlCommand(querry, con);

                    com.ExecuteNonQuery();
                    con.Close();

                    this.Hide();
                    Form4 f4 = new Form4();
                    f4.Show();
                }
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                if (Class2.Gen == 0)
                {
                    if (MessageBox.Show("Ești sigură că vrei să îți ștergi contul?", "Șterge", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);

                        con.Open();
                        string querry = @"DELETE FROM Accounts WHERE Id = '" + id + "' ";

                        SqlCommand com = new SqlCommand(querry, con);

                        com.ExecuteNonQuery();
                        con.Close();

                        this.Hide();
                        Form4 f4 = new Form4();
                        f4.Show();
                    }
                }
                else if (Class2.Gen == 1)
                {
                    if (MessageBox.Show("Ești sigur că vrei să îți ștergi contul?", "Șterge", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);

                        con.Open();
                        string querry = @"DELETE FROM Accounts WHERE Id = '" + id + "' ";

                        SqlCommand com = new SqlCommand(querry, con);

                        com.ExecuteNonQuery();
                        con.Close();

                        this.Hide();
                        Form4 f4 = new Form4();
                        f4.Show();
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
                LaMultiAni f36 = new LaMultiAni();
                f36.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Gata")
            {
                if (Class2.Gen == 0)
                {
                    if (MessageBox.Show("Ești sigură că vrei să părăsești pagina?", "Date nesalvate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        this.Hide();
                        Meniu_Jocuri f33 = new Meniu_Jocuri();
                        f33.Show();
                    }
                }
                else if (Class2.Gen == 1)
                {
                    if (MessageBox.Show("Ești sigur că vrei să părăsești pagina?", "Date nesalvate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        this.Hide();
                        Meniu_Jocuri f33 = new Meniu_Jocuri();
                        f33.Show();
                    }
                }
            }
            else if (button1.Text == "Done")
            {
                if (MessageBox.Show("Are you sure you want to go?", "Unsaved data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.Hide();
                    Meniu_Jocuri f33 = new Meniu_Jocuri();
                    f33.Show();
                }
            }
            else if (button1.Text == "Editează" || button1.Text == "Edit")
            {
                this.Hide();
                Meniu_Jocuri f33 = new Meniu_Jocuri();
                f33.Show();
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Gata" || button1.Text == "Done")
            {
                if (Class3.Adevarat == false)
                {
                    SchimbParola f38 = new SchimbParola();
                    f38.Show();
                }
                else if (Class3.Adevarat == true)
                {
                    textBox3.ReadOnly = false;
                    button5.Visible = true;
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Gata")
            {
                if (Class2.Gen == 0)
                {
                    if (MessageBox.Show("Ești sigură că vrei să părăsești pagina?", "Date nesalvate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        this.Hide();
                        PagAdmin f39 = new PagAdmin();
                        f39.Show();
                    }
                }
                else if (Class2.Gen == 1)
                {
                    if (MessageBox.Show("Ești sigur că vrei să părăsești pagina?", "Date nesalvate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        this.Hide();
                        PagAdmin f39 = new PagAdmin();
                        f39.Show();
                    }
                }
            }
            else if (button1.Text == "Done")
            {
                if (MessageBox.Show("Are you sure you want to go?", "Unsaved data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.Hide();
                    PagAdmin f39 = new PagAdmin();
                    f39.Show();
                }
            }
            else if (button1.Text == "Editează" || button1.Text == "Edit")
            {
                this.Hide();
                PagAdmin f39 = new PagAdmin();
                f39.Show();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (first == false && tabControl1.SelectedIndex == 1)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();

                string querry = @"SELECT COUNT(*) FROM Results_Quiz WHERE Email = '" + Clasa_Conectare.conectat + "' AND Number != '" + 0 + "'";
                SqlCommand com = new SqlCommand(querry, con);
                int numar = Int32.Parse(com.ExecuteScalar().ToString());

                if (numar != 0)
                {
                    querry = @"SELECT * FROM Results_Quiz WHERE Email = '" + Clasa_Conectare.conectat + "' AND Number != '" + 0 + "'";

                    SqlCommand com1 = new SqlCommand(querry, con);
                    SqlDataReader reader = com1.ExecuteReader();

                    int c = 0, p;

                    if (Clasa_Intrebari.Limba == 1)
                    {
                        chart3.Titles[0].Text = Class3.Titlu[204] + numar.ToString() + Class3.Titlu[205];
                        chart3.Series[0].LegendText = Class3.Titlu[203];

                        label11.Text = Class3.Titlu[208];
                        label15.Text = Class3.Titlu[206];
                        label16.Text = Class3.Titlu[207];
                    }
                    else if (Clasa_Intrebari.Limba == 0)
                    {
                        if (numar > 1 && numar != 20)
                            chart3.Titles[0].Text = "Datele ultimelor " + numar.ToString() + " teste";
                        else if (numar == 1)
                            chart3.Titles[0].Text = "Datele ultimului test";
                        else if (numar == 20)
                            chart3.Titles[0].Text = "Datele ultimelor " + numar.ToString() + " de teste";
                    }

                    while (reader.Read())
                        if (reader.HasRows == true)
                        {
                            c++;

                            if (c == numar - 2)
                            {
                                label12.Text = reader["Date"].ToString();
                                label19.Text = reader["Correct"].ToString() + "/" + reader["Number"];
                            }
                            else if (c == numar - 1)
                            {
                                label13.Text = reader["Date"].ToString();
                                label18.Text = reader["Correct"].ToString() + "/" + reader["Number"];
                            }
                            else if (c == numar)
                            {
                                label14.Text = reader["Date"].ToString();
                                label17.Text = reader["Correct"].ToString() + "/" + reader["Number"];
                            }

                            p = 100 * (Int32.Parse(reader["Correct"].ToString())) / (Int32.Parse(reader["Number"].ToString()));
                            chart3.Series["Procente"].Points.AddXY("", p);
                        }

                    reader.Close();
                    con.Close();

                    first = true;
                }
                else
                {
                    chart3.Visible = false;

                    if (Clasa_Intrebari.Limba == 0)
                    {
                        label20.Text = "Nu ați făcut niciun test.";
                    }
                    else if (Clasa_Intrebari.Limba == 1)
                    {
                        label20.Text = Class3.Titlu[209];
                        label20.Location = new Point(485, 70);
                    }
                    label20.Font = new Font("Times New Roman", 22, FontStyle.Italic);
                    label20.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                    label20.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 1)
            {
                if (MessageBox.Show("Are you sure you want to sign out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                    con.Open();

                    string querry1 = @"UPDATE Accounts SET Connection = @connection WHERE Id = '" + id + "' ";
                    SqlCommand com2 = new SqlCommand(querry1, con);
                    com2.Parameters.AddWithValue("connection", "0");
                    com2.ExecuteNonQuery();


                    Clasa_Conectare.conectat = "";
                    Class2.Gen = 1;
                    Clasa_Conectare.Status = 0;
                    Class3.Test_acomodare = false;

                    this.Hide();
                    Login f32 = new Login();
                    f32.Show();
                }
            }
            else if(Clasa_Intrebari.Limba == 0)
            {
                if (Class2.Gen == 0)
                {
                    if (MessageBox.Show("Ești sigură că vrei să te deconectezi?", "Ieșire", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                        con.Open();

                        string querry1 = @"UPDATE Accounts SET Connection = @connection WHERE Id = '" + id + "' ";
                        SqlCommand com2 = new SqlCommand(querry1, con);
                        com2.Parameters.AddWithValue("connection", "0");
                        com2.ExecuteNonQuery();


                        Clasa_Conectare.conectat = "";
                        Class2.Gen = 1;
                        Clasa_Conectare.Status = 0;
                        Class3.Test_acomodare = false;

                        this.Hide();
                        Login f32 = new Login();
                        f32.Show();
                    }
                }
                else if (Class2.Gen == 1)
                {
                    if (MessageBox.Show("Ești sigur că vrei să te deconectezi?", "Ieșire", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                        con.Open();

                        string querry1 = @"UPDATE Accounts SET Connection = @connection WHERE Id = '" + id + "' ";
                        SqlCommand com2 = new SqlCommand(querry1, con);
                        com2.Parameters.AddWithValue("connection", "0");
                        com2.ExecuteNonQuery();


                        Clasa_Conectare.conectat = "";
                        Class2.Gen = 1;
                        Clasa_Conectare.Status = 0;
                        Class3.Test_acomodare = false;

                        this.Hide();
                        Login f32 = new Login();
                        f32.Show();
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(i == 0)
            {
                button5.Image = imageList2.Images[1];
                textBox3.UseSystemPasswordChar = false;
                i = 1;
            }
            else if(i == 1)
            {
                button5.Image = imageList2.Images[0];
                textBox3.UseSystemPasswordChar = true;
                i = 0;
            }
        }
    }
}
