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
    public partial class Form42 : Form
    {
        public Form42()
        {
            InitializeComponent();
        }

        //închiderea aplicației
        private void Form42_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //

        int corect;
        string where;
        bool isActive;

        private void Form42_Load(object sender, EventArgs e)
        {
            //stabilește limba în care va fi tradus textul și îl preia din fișiere de tip ".txt"
            if (Clasa_Intrebari.Limba == 1)
            {
                label4.Text = Class3.Titlu[180] + Clasa_Intrebari.Total.ToString();
                label2.Text = Class3.Titlu[181] + Clasa_Intrebari.Corecte.ToString();
                label3.Text = Class3.Titlu[182] + Clasa_Intrebari.Gresite.ToString();
                label1.Text = Class3.Titlu[183] + (Clasa_Intrebari.Total - Clasa_Intrebari.Corecte - Clasa_Intrebari.Gresite).ToString();
                label5.Text = Class3.Titlu[210];

                button1.Text = Class3.Titlu[34];
                button2.Text = Class3.Titlu[52];
                button3.Text = Class3.Titlu[211];
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                label4.Text = "Total: " + Clasa_Intrebari.Total.ToString();
                label2.Text = "Corecte: " + Clasa_Intrebari.Corecte.ToString();
                label3.Text = "Greșite: " + Clasa_Intrebari.Gresite.ToString();
                label1.Text = "Rămase: " + (Clasa_Intrebari.Total - Clasa_Intrebari.Corecte - Clasa_Intrebari.Gresite).ToString();
            }
            //

            //pornește cronometrul și stabilește vizibilitatea unor obiecte
            timer1.Enabled = true;
            label5.Visible = false;
            richTextBox1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            isActive = true;
            //

            //schimbă poziția unui obiect
            groupBox1.Location = new Point(91, 109);


            //caută în tabelul Questions întrebarea la care s-a ajuns
            SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
            con.Open();

            string querry = "";

            if (Clasa_Intrebari.Limba == 0)
                querry = @"SELECT * FROM Questions WHERE Id = '" + Clasa_Intrebari.Questions[Clasa_Intrebari.Numar_Intrebare] + "'";
            else if (Clasa_Intrebari.Limba == 1)
                querry = @"SELECT * FROM Questions WHERE Id = '" + Clasa_Intrebari.Questions[Clasa_Intrebari.Numar_Intrebare] * 1000 + "'";

            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            if (reader.HasRows == true)
            {
                    //afișează întrebarea când a fost găsită împreună cu răspunsurile el
                    groupBox1.Text = reader["Question"].ToString();
                    checkBox1.Text = reader["Option1"].ToString();
                    checkBox2.Text = reader["Option2"].ToString();
                    checkBox3.Text = reader["Option3"].ToString();
                    //

                    //ține minte locația, răspunsurile corecte și numărul întrebării care urmează
                    corect = Int32.Parse(reader["Answer"].ToString());
                    where = reader["Location"].ToString();
                    Clasa_Intrebari.Numar_Intrebare++;
                    //
            }
            reader.Close();
            con.Close();
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dacă textul butonului este "Verifică" sau "Check"
            if (button1.Text == "Verifică" || button1.Text == "Check")
            {
                //cronometrul se oprește
                isActive = false;

                bool rasp1 = false, rasp2 = false, rasp3 = false, bine = true;
                int aux = corect;

                //stabilește care răspunsuri sunt corecte
                while (aux != 0)
                {
                    if (aux % 10 == 1)
                        rasp1 = true;
                    else if (aux % 10 == 2)
                        rasp2 = true;
                    else if (aux % 10 == 3)
                        rasp3 = true;

                    aux = aux / 10;
                }
                //


                //verifică prima opțiune
                //dacă este bifată
                if (checkBox1.Checked == true)
                {
                    //dacă răspunsul este corect
                    if (rasp1 == true)
                    {
                        pictureBox1.Image = imageList1.Images[0];
                        checkBox1.ForeColor = System.Drawing.Color.Green;
                    }
                    //

                    //dacă răspunsul este greșit
                    else if (rasp1 == false)
                    {
                        pictureBox1.Image = imageList1.Images[1];
                        checkBox1.ForeColor = System.Drawing.Color.Red;

                        label5.Visible = true;
                        richTextBox1.Visible = true;

                        string text = Application.StartupPath;
                        text = text.Substring(0, text.Length - 10);
                        text = text + where;

                        string text1 = System.IO.File.ReadAllText(text);
                        richTextBox1.Text = text1;

                        bine = false;
                        groupBox1.Location = new Point(78, 76);
                        button3.Location = new Point(578, 264);
                    }
                    //
                }
                //dacă nu este bifată
                else if (checkBox1.Checked == false)
                {
                    //dacă răspunsul este corect
                    if (rasp1 == true)
                    {
                        checkBox1.ForeColor = System.Drawing.Color.Green;

                        label5.Visible = true;
                        richTextBox1.Visible = true;

                        string text = Application.StartupPath;
                        text = text.Substring(0, text.Length - 10);
                        text = text + where;

                        string text1 = System.IO.File.ReadAllText(text);
                        richTextBox1.Text = text1;

                        bine = false;
                        groupBox1.Location = new Point(78, 76);
                        button3.Location = new Point(578, 264);
                    }
                    //
                }


                //verifică a doua opțiune
                //dacă este bifată
                if (checkBox2.Checked == true)
                {
                    //dacă răspunsul este corect
                    if (rasp2 == true)
                    {
                        pictureBox2.Image = imageList1.Images[0];
                        checkBox2.ForeColor = System.Drawing.Color.Green;
                    }
                    //

                    //dacă răspunsul este greșit
                    else if (rasp2 == false)
                    {
                        pictureBox2.Image = imageList1.Images[1];
                        checkBox2.ForeColor = System.Drawing.Color.Red;

                        label5.Visible = true;
                        richTextBox1.Visible = true;

                        string text = Application.StartupPath;
                        text = text.Substring(0, text.Length - 10);
                        text = text + where;

                        string text1 = System.IO.File.ReadAllText(text);
                        richTextBox1.Text = text1;

                        bine = false;
                        groupBox1.Location = new Point(78, 76);
                        button3.Location = new Point(578, 264);
                    }
                    //
                }
                //dacă nu este bifată
                else if (checkBox2.Checked == false)
                {
                    //dacă răspunsul este corect
                    if (rasp2 == true)
                    {
                        checkBox2.ForeColor = System.Drawing.Color.Green;

                        label5.Visible = true;
                        richTextBox1.Visible = true;

                        string text = Application.StartupPath;
                        text = text.Substring(0, text.Length - 10);
                        text = text + where;

                        string text1 = System.IO.File.ReadAllText(text);
                        richTextBox1.Text = text1;

                        bine = false;
                        groupBox1.Location = new Point(78, 76);
                        button3.Location = new Point(578, 264);
                    }
                    //
                }


                //verifică a treia opțiune
                //dacă este bifată
                if (checkBox3.Checked == true)
                {
                    //dacă răspunsul este corect
                    if (rasp3 == true)
                    {
                        pictureBox3.Image = imageList1.Images[0];
                        checkBox3.ForeColor = System.Drawing.Color.Green;
                    }
                    //

                    //dacă răspunsul este greșit
                    else if (rasp3 == false)
                    {
                        pictureBox3.Image = imageList1.Images[1];
                        checkBox3.ForeColor = System.Drawing.Color.Red;

                        label5.Visible = true;
                        richTextBox1.Visible = true;

                        string text = Application.StartupPath;
                        text = text.Substring(0, text.Length - 10);
                        text = text + where;

                        string text1 = System.IO.File.ReadAllText(text);
                        richTextBox1.Text = text1;

                        bine = false;
                        groupBox1.Location = new Point(78, 76);
                        button3.Location = new Point(578, 264);
                    }
                    //
                }
                //dacă nu este bifată
                else if (checkBox3.Checked == false)
                {
                    //dacă răspunsul este corect
                    if (rasp3 == true)
                    {
                        checkBox3.ForeColor = System.Drawing.Color.Green;

                        label5.Visible = true;
                        richTextBox1.Visible = true;

                        string text = Application.StartupPath;
                        text = text.Substring(0, text.Length - 10);
                        text = text + where;

                        string text1 = System.IO.File.ReadAllText(text);
                        richTextBox1.Text = text1;

                        bine = false;
                        groupBox1.Location = new Point(78, 76);
                        button3.Location = new Point(578, 264);
                    }
                    //
                }

                //actualizează numărul răspunsurilor corecte/greșite
                if (bine == true)
                    Clasa_Intrebari.Corecte++;
                else if (bine == false)
                    Clasa_Intrebari.Gresite++;

                if (Clasa_Intrebari.Limba == 1)
                {
                    button1.Text = Class3.Titlu[179];
                    label2.Text = Class3.Titlu[181] + Clasa_Intrebari.Corecte.ToString();
                    label3.Text = Class3.Titlu[182] + Clasa_Intrebari.Gresite.ToString();
                    label1.Text = Class3.Titlu[183] + (Clasa_Intrebari.Total - Clasa_Intrebari.Corecte - Clasa_Intrebari.Gresite).ToString();
                }
                else if (Clasa_Intrebari.Limba == 0)
                {
                    button1.Text = "Următoarea";
                    label2.Text = "Corecte: " + Clasa_Intrebari.Corecte.ToString();
                    label3.Text = "Greșite: " + Clasa_Intrebari.Gresite.ToString();
                    label1.Text = "Rămase: " + (Clasa_Intrebari.Total - Clasa_Intrebari.Corecte - Clasa_Intrebari.Gresite).ToString();
                }
                //

                //dacă nu mai sunt întrebări
                if (Clasa_Intrebari.Total - Clasa_Intrebari.Corecte - Clasa_Intrebari.Gresite == 0)
                {
                    button3.Visible = false;

                    //apare un mesaj cu numărul punctelor obținute, conform limbii alese
                    if (Clasa_Intrebari.Limba == 0)
                    {
                        if (Clasa_Intrebari.Corecte > 1 && Clasa_Intrebari.Corecte < 20)
                            MessageBox.Show("Ați obținut " + Clasa_Intrebari.Corecte.ToString() + " puncte.", "Test terminat", MessageBoxButtons.OK, MessageBoxIcon.None);
                        else if (Clasa_Intrebari.Corecte == 1)
                            MessageBox.Show("Ați obținut " + Clasa_Intrebari.Corecte.ToString() + " punct.", "Test terminat", MessageBoxButtons.OK, MessageBoxIcon.None);
                        else if (Clasa_Intrebari.Corecte > 19)
                            MessageBox.Show("Ați obținut " + Clasa_Intrebari.Corecte.ToString() + " de puncte.", "Test terminat", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else if (Clasa_Intrebari.Limba == 1)
                    {
                        if (Clasa_Intrebari.Corecte > 1)
                            MessageBox.Show(Class3.Titlu[185] + Clasa_Intrebari.Corecte.ToString() + Class3.Titlu[186], Class3.Titlu[188], MessageBoxButtons.OK, MessageBoxIcon.None);
                        else if (Clasa_Intrebari.Corecte == 1)
                            MessageBox.Show(Class3.Titlu[185] + Clasa_Intrebari.Corecte.ToString() + Class3.Titlu[187], Class3.Titlu[188], MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    //

                    //schimbă textul butonului
                    if (Clasa_Intrebari.Limba == 0)
                        button1.Text = "Refacere";
                    else if (Clasa_Intrebari.Limba == 1)
                        button1.Text = Class3.Titlu[184];
                    //

                    button2.Visible = true;

                    //dacă utilizatorul este conectat
                    if (Clasa_Conectare.conectat != "")
                    {
                        //caută în tabelul Results_Quiz
                        SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                        con.Open();

                        int id = 0, c = 0, lastid = 0;
                        string querry = @"SELECT * FROM Results_Quiz";

                        SqlCommand com = new SqlCommand(querry, con);
                        SqlDataReader reader = com.ExecuteReader();

                        while (reader.Read())
                            if (reader.HasRows)
                            {
                                if (c == 0 && reader["Email"].ToString() == Clasa_Conectare.conectat)
                                {
                                    //reține id-ul primului rezultat din tabel cu emailul conectat
                                    id = Int32.Parse(reader["Id"].ToString());
                                    c++;
                                }
                                else if (reader["Email"].ToString() == Clasa_Conectare.conectat)
                                    c++;

                                //reține ultimul id din tabel
                                lastid = Int32.Parse(reader["Id"].ToString());
                            }

                        reader.Close();

                        //dacă sunt mai puțin de 20 de rezultate pe același cont
                        if (c < 20)
                        {
                            DateTime dateTime = DateTime.Now;

                            //crează o linie nouă în tabel
                            querry = @"INSERT INTO Results_Quiz (Id, Email, Number, Correct, Incorrect, Time, Date, First) VALUES ('" + (lastid + 1) + "' , '" + Clasa_Conectare.conectat + "' , '" + Clasa_Intrebari.Total + "' , '" + Clasa_Intrebari.Corecte + "' , '" + Clasa_Intrebari.Gresite + "' , '" + (Class2.TimeMin.ToString() + "," + Class2.TimeSec.ToString() + "," + Class2.TimeCs.ToString()) + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + " " + dateTime.Hour.ToString() + ":" + dateTime.Minute.ToString() + ":" + dateTime.Second.ToString() + "' , '" + 0 + "')";

                            SqlCommand com1 = new SqlCommand(querry, con);
                            com1.ExecuteNonQuery();
                            //
                        }
                        //dacă sunt mai mult de 20 de rezultate pe același cont
                        else if (c >= 20)
                        {
                            DateTime dateTime = DateTime.Now;

                            //actualizează rezultatul cel mai vechi de pe emailul conectat
                            querry = @"UPDATE Results_Quiz SET Id = @id , Number = @number , Correct = @correct , Incorrect = @incorrect , Time = @time , Date = @date , First = @first WHERE Email = '" + Clasa_Conectare.conectat + "' AND Id = '" + id + "'";

                            SqlCommand com1 = new SqlCommand(querry, con);
                            com1.Parameters.AddWithValue("id", (lastid + 1).ToString());
                            com1.Parameters.AddWithValue("number", Clasa_Intrebari.Total.ToString());
                            com1.Parameters.AddWithValue("correct", Clasa_Intrebari.Corecte.ToString());
                            com1.Parameters.AddWithValue("incorrect", Clasa_Intrebari.Gresite.ToString());
                            com1.Parameters.AddWithValue("time", (Class2.TimeMin.ToString() + "," + Class2.TimeSec.ToString() + "," + Class2.TimeCs.ToString()));
                            com1.Parameters.AddWithValue("date", dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + " " + dateTime.Hour.ToString() + ":" + dateTime.Minute.ToString() + ":" + dateTime.Second.ToString());
                            com1.Parameters.AddWithValue("first", "0");

                            com1.ExecuteNonQuery();
                            //
                        }
                        con.Close();
                    }
                }
            }
            //

            //dacă textul butonului este "Următoarea" sau "Next"
            else if (button1.Text == "Următoarea" || button1.Text == "Next")
            {
                //butonul își modifică textul
                if (Clasa_Intrebari.Limba == 0)
                    button1.Text = "Verifică";
                else if (Clasa_Intrebari.Limba == 1)
                    button1.Text = Class3.Titlu[34];
                //

                //se modifică vizibilitatea unor obiecte
                label5.Visible = false;
                richTextBox1.Visible = false;
                //

                //se reapelează Form-ul curent
                this.Hide();
                Form42 f42 = new Form42();
                f42.Show();
                //
            }
            //

            //dacă textul butonului este "Refacere" sau "Again"
            else if (button1.Text == "Refacere" || button1.Text == "Again")
            {
                //se trece la Form-ul cu alegerea numărului de întrebări
                this.Hide();
                Form41 f41 = new Form41();
                f41.Show();
                //
            }
            //
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //când cronometrul merge, cresc milisecundele, secundele și minutele
            if (isActive == true)
            {
                Class2.TimeCs++;

                if (Class2.TimeCs >= 100)
                {
                    Class2.TimeSec++;
                    Class2.TimeCs = 0;

                    if (Class2.TimeSec >= 60)
                    {
                        Class2.TimeMin++;
                        Class2.TimeSec = 0;
                    }
                }
            }
            //

            //se actualizează timpul de pe pagină
            DrawTime();

            //dacă limita de timp este întrecută, apare un mesaj iar apoi testul se anulează
            if ((Clasa_Intrebari.Total <= 5 && Class2.TimeMin >= 5) || (Clasa_Intrebari.Total > 5 && Clasa_Intrebari.Total < 10 && Class2.TimeMin >= 10) || (Clasa_Intrebari.Total >= 10 && Clasa_Intrebari.Total < 20 && Class2.TimeMin >= 15) || (Clasa_Intrebari.Total >= 20 && Clasa_Intrebari.Total < 30 && Class2.TimeMin >= 20) || (Clasa_Intrebari.Total >= 30 && Class2.TimeMin >= 30))
            {
                timer1.Stop();
                if (Clasa_Intrebari.Limba == 0)
                {
                    MessageBox.Show("Ți-a luat prea mult timp să termini chestionarul.", "Timp expirat", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    MessageBox.Show(Class3.Titlu[190], Class3.Titlu[189], MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                this.Hide();
                Form41 f41 = new Form41();
                f41.Show();
            }
            //
        }

        private void DrawTime()
        {
            //se alege textul și formatul
            label8.Text = String.Format("{00:00}", Class2.TimeCs);
            label7.Text = String.Format("{00:00}", Class2.TimeSec) + " .";
            label6.Text = String.Format("{00:00}", Class2.TimeMin) + " :";
            //
        }

        //trece la pagina cuprinsului
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }
        //

        private void button3_Click(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                if (Class2.Gen == 0)
                {
                    isActive = false;
                    DialogResult dialog = MessageBox.Show("Ești sigură că vrei să părăsești pagina?", "Chestionar neterminat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        //anulează testul, oprește cronometrul și revine la cuprins
                        timer1.Stop();
                        this.Hide();
                        Form4 f4 = new Form4();
                        f4.Show();
                        //
                    }
                    else isActive = true;
                }
                else if (Class2.Gen == 1)
                {
                    isActive = false;
                    DialogResult dialog = MessageBox.Show("Ești sigur că vrei să părăsești pagina?", "Chestionar neterminat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        //anulează testul, oprește cronometrul și revine la cuprins
                        timer1.Stop();
                        this.Hide();
                        Form4 f4 = new Form4();
                        f4.Show();
                        //
                    }
                    else isActive = true;
                }
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                isActive = false;
                DialogResult dialog = MessageBox.Show(Class3.Titlu[200], Class3.Titlu[202], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    //anulează testul, oprește cronometrul și revine la cuprins
                    timer1.Stop();
                    this.Hide();
                    Form4 f4 = new Form4();
                    f4.Show();
                    //
                }
                else isActive = true;
            }
        }
    }
}
