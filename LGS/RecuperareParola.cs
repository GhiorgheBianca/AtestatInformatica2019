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
    public partial class RecuperareParola : Form
    {
        public RecuperareParola()
        {
            InitializeComponent();
        }

        int greseli = 0;

        //revenirea la pagina de conectare
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f32 = new Login();
            f32.Show();
        }
        //

        //închiderea aplicației
        private void Form37_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //

        private void Form37_Load(object sender, EventArgs e)
        {
            //stabilirea limbii și actualizarea textelor dacă limba selectată este engleza
            if (Clasa_Intrebari.Limba == 1)
            {
                label4.Text = Class3.Titlu[98];
                label1.Text = Class3.Titlu[99];
                label2.Text = Class3.Titlu[100];
                label3.Text = Class3.Titlu[43];

                textBox1.Left = +206;
                textBox2.Left = +137;
                textBox3.Left = +100;
            }
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool gasit = false;

            SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
            con.Open();
            string querry = @"SELECT * FROM Accounts WHERE Email = '" + textBox4.Text + "' ";
            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
                if (reader.HasRows == true)
                {
                    gasit = true;

                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;

                    if (Clasa_Intrebari.Limba == 1)
                        textBox1.Text = Class3.Titlu[91 + Int32.Parse(reader["Security_Question"].ToString())];
                    else if (Clasa_Intrebari.Limba == 0)
                        textBox1.Text = comboBox5.Items[Int32.Parse(reader["Security_Question"].ToString())].ToString();

                    if (textBox2.Text == reader["Security_Answer"].ToString())
                        textBox3.Text = reader["Password"].ToString();
                    else if (textBox2.Text != reader["Security_Answer"].ToString() && textBox2.Text != "" && greseli < 2)
                    {
                        greseli++;
                        if (Clasa_Intrebari.Limba == 0)
                            MessageBox.Show("Răspuns incorect!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else MessageBox.Show(Class3.Titlu[101], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(greseli >= 2)
                    {
                        if (Clasa_Intrebari.Limba == 0)
                            MessageBox.Show("Răspuns incorect! Ați greșit de prea multe ori.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else MessageBox.Show(Class3.Titlu[102], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        this.Hide();
                        Login f32 = new Login();
                        f32.Show();
                    }
                }
            if (gasit == false)
            {
                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Email invalid!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Clasa_Intrebari.Limba == 1)
                    MessageBox.Show(Class3.Titlu[47], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
