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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //stabilirea locație bazei de date pentru întreaga aplicație
            string a = Application.StartupPath;
            a = a.Substring(0, a.Length - 10);
            a = a + @"\Database1.mdf";

            string b = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + a + "; Integrated Security = True";

            Clasa_Conectare.variabila = b;
            //


            //stabilirea contului care era înregistrat ultima dată
            SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
            con.Open();
            string querry = @"SELECT * FROM Accounts WHERE Connection = '" + 1 + "' ";
            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();

            Clasa_Conectare.conectat = "";

            while(reader.Read())
            if(reader.HasRows == true)
            {
                //reține mailul și statusul
                Clasa_Conectare.conectat = reader["Email"].ToString();
                Clasa_Conectare.Status = Int32.Parse(reader["Status"].ToString());
            }
            reader.Close();
            //

            //stabilește dacă testul de acolodare a fost făcut de către utilizator
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
            //

            //începerea timer-ului
            timer1.Enabled = true;
            //
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //creșterea valorii progressBar-ului
            progressBar1.Value++;
            if (progressBar1.Value == 50)
            {
                //grăbirea procesului când progressBar-ul ajunge la valoarea 50
                timer1.Interval = 20;
            }
            else if (progressBar1.Value == 100)
            {
                //oprirea progressBar-ului când acesta ajunge la valoarea 100 și trecerea la următorul Form
                timer1.Enabled = false;
                this.Hide();
                SchimbLimba f25 = new SchimbLimba();
                f25.Show();
            }
            //
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
