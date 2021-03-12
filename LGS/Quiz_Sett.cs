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
    public partial class Form41 : Form
    {
        public Form41()
        {
            InitializeComponent();
        }

        //trecerea la Form-ul cuprinsului
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }
        //

        int row_nr = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && row_nr / 2 >= Int32.Parse(comboBox1.Text) && Int32.Parse(comboBox1.Text) > 0)
            {
                int i, nr_intrebari = Int32.Parse(comboBox1.Text);
                int[] v = new int[100];

                //se inițializează vectorul cu valori nule
                for (i = 1; i <= nr_intrebari; i++)
                    v[i] = 0;
                //

                Random rnd = new Random();
                int nr;

                //crearea vectorului de întrebări cu valori aleatorii, conform numărului de întrebări cerute
                i = 1;
                while (i <= nr_intrebari)
                {
                    bool accept = true;
                    nr = rnd.Next(1, row_nr / 2 + 1);
                    v[i] = nr;

                    //asigurarea faptului că valorile nu se repetă
                    for (int k = 1; k < nr_intrebari; k++)
                        for (int j = k + 1; j <= nr_intrebari; j++)
                            if (v[k] == v[j] && v[k] != 0)
                                accept = false;
                    //

                    i++;
                    if (accept == false)
                    {
                        v[i] = 0;
                        i--;
                    }
                }
                //

                //actualizarea datelor pentru pagina cu întrebări
                Clasa_Intrebari.Questions = v;
                Clasa_Intrebari.Numar_Intrebare = 1;
                Clasa_Intrebari.Corecte = 0;
                Clasa_Intrebari.Gresite = 0;
                Clasa_Intrebari.Total = nr_intrebari;
                //

                //trecerea la pagina cu întrebări
                this.Hide();
                Form42 f42 = new Form42();
                f42.Show();
                //
            }

            //apariția unui mesaj în cazul în care nu este completat comboBox-ul
            else if (comboBox1.Text == "")
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    MessageBox.Show("Vă rugăm să scrieți numărul de întrebări înainte de a începe testul.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    MessageBox.Show(Class3.Titlu[196], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //

            //apariția unui mesaj în cazul în care se cer prea multe întrebări
            else if (row_nr / 2 < Int32.Parse(comboBox1.Text))
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    MessageBox.Show("Nu există atât de multe întrebări în baza de date." + " (" + (row_nr / 2).ToString() + ")", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    MessageBox.Show(Class3.Titlu[197] + " (" + (row_nr / 2).ToString() + ")", Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //

            //apariția unui mesaj în cazul în care numărul este mai mic sau egal cu 0
            else if (Int32.Parse(comboBox1.Text) <= 0)
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    MessageBox.Show("Nu puteți alege numere mai mici sau egale cu 0.", "Atenționare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    MessageBox.Show(Class3.Titlu[217], Class3.Titlu[86], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //
        }

        //închiderea aplicației
        private void Form41_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //

        private void Form41_Load(object sender, EventArgs e)
        {
            //actualizarea datelor pentru pagina cu întrebări
            Class2.TimeCs = 0;
            Class2.TimeSec = 0;
            Class2.TimeMin = 0;
            //

            //stabilirea limbii Form-ului, respectiv actualizarea textelor în consecință și poziționarea unor obiecte
            if (Clasa_Intrebari.Limba == 1)
            {
                label1.Location = new Point(84, 66);
                comboBox1.Location = new Point(233, 66);
                label2.Location = new Point(394, 66);
                label4.Location = new Point(254, 43);

                label1.Text = Class3.Titlu[191];
                label2.Text = Class3.Titlu[192];
                label3.Text = Class3.Titlu[193] + Environment.NewLine + Class3.Titlu[194] + Environment.NewLine + Class3.Titlu[195];
            }
            //

            //stabilirea numărului total de întrebări
            SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
            con.Open();

            string querry = @"SELECT COUNT(*) FROM Questions";
            SqlCommand com = new SqlCommand(querry, con);
            int numar = Int32.Parse(com.ExecuteScalar().ToString());
            con.Close();

            row_nr = numar;
            //
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //stabilirea timpului estimat pentru numărul de întrebări alese
            if (comboBox1.Text != "")
            {
                if (Int32.Parse(comboBox1.Text) >= 30)
                    label4.Text = "(max. 30 min.)";
                else if (Int32.Parse(comboBox1.Text) >= 20)
                    label4.Text = "(max. 20 min.)";
                else if (Int32.Parse(comboBox1.Text) >= 10)
                    label4.Text = "(max. 15 min.)";
                else if (Int32.Parse(comboBox1.Text) > 5)
                    label4.Text = "(max. 10 min.)";
                else if (Int32.Parse(comboBox1.Text) <= 5)
                    label4.Text = "(max. 5 min.)";
            }
            //
        }
    }
}
