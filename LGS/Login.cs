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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        int i = 0;

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
            con.Open();
            
            string querry = @"SELECT * FROM Accounts WHERE Email = '" + textBox2.Text + "' ";

            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();

            if (reader.HasRows == true)
            {
                textBox2.BackColor = System.Drawing.Color.White;
                textBox2.ForeColor = System.Drawing.Color.Black;
                textBox2.Font = new Font(textBox2.Font.FontFamily, textBox2.Font.Size, FontStyle.Regular);

                con.Close();
                con.Open();
                querry = @"SELECT * FROM Accounts WHERE Email = '" + textBox2.Text + "' AND Password = '" + textBox1.Text + "' ";

                SqlCommand com1 = new SqlCommand(querry, con);
                reader = com1.ExecuteReader();

                while (reader.Read())
                    if(reader.HasRows == true)
                        Clasa_Conectare.Status = Int32.Parse(reader["Status"].ToString());

                if (reader.HasRows == true)
                {
                    reader.Close();

                    string querry1 = @"UPDATE Accounts SET Connection = @connection WHERE Email = '" + textBox2.Text + "' AND Password = '" + textBox1.Text + "' ";
                    SqlCommand com2 = new SqlCommand(querry1, con);
                    com2.Parameters.AddWithValue("connection", "1");
                    com2.ExecuteNonQuery();


                    Clasa_Conectare.conectat = textBox2.Text;
                    textBox1.BackColor = System.Drawing.Color.White;
                    textBox1.ForeColor = System.Drawing.Color.Black;
                    this.Hide();
                    Profil f35 = new Profil();
                    f35.Show();
                }
                else
                {
                    textBox1.BackColor = System.Drawing.Color.DarkOrange;
                    textBox1.ForeColor = System.Drawing.Color.White;
                    textBox2.BackColor = System.Drawing.Color.White;
                    textBox2.ForeColor = System.Drawing.Color.Black;
                    textBox2.Font = new Font(textBox2.Font.FontFamily, textBox2.Font.Size, FontStyle.Regular);

                    if (Clasa_Intrebari.Limba == 0)
                        MessageBox.Show("Parolă incorectă!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show(Class3.Titlu[48], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                textBox2.BackColor = System.Drawing.Color.DarkOrange;
                textBox2.ForeColor = System.Drawing.Color.White;
                textBox2.Font = new Font(textBox2.Font.FontFamily, textBox2.Font.Size, FontStyle.Bold);

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Email invalid!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if(Clasa_Intrebari.Limba == 1)
                    MessageBox.Show(Class3.Titlu[47], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reader.Close();

            if (Clasa_Conectare.conectat != "")
            {
                querry = @"SELECT * FROM Results_Quiz WHERE Email = '" + Clasa_Conectare.conectat + "' ";
                SqlCommand com1 = new SqlCommand(querry, con);
                SqlDataReader reader1 = com1.ExecuteReader();

                if (reader1.HasRows == true)
                {
                    Class3.Test_acomodare = true;
                }
                else Class3.Test_acomodare = false;

                reader1.Close();
                con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void Form32_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form32_Load(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 1)
            {
                label3.Text = Class3.Titlu[42];
                label1.Text = Class3.Titlu[43];
                label5.Text = Class3.Titlu[44];
                label4.Text = Class3.Titlu[45];
                button1.Text = Class3.Titlu[46];
                label6.Text = Class3.Titlu[97];
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreareCont f34 = new CreareCont();
            f34.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                button5.Image = imageList2.Images[1];
                textBox1.UseSystemPasswordChar = false;
                i = 1;
            }
            else if (i == 1)
            {
                button5.Image = imageList2.Images[0];
                textBox1.UseSystemPasswordChar = true;
                i = 0;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            RecuperareParola f37 = new RecuperareParola();
            f37.Show();
        }
    }
}
