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
    public partial class PagAdmin : Form
    {
        public PagAdmin()
        {
            InitializeComponent();
        }

        bool bday = true, first = false;
        int id_nou, nr_rows;

        private void Form39_Load(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 1)
            {
                label1.Text = Class3.Titlu[145];
                nameLabel.Text = Class3.Titlu[76];
                passwordLabel.Text = Class3.Titlu[78];
                birthdayLabel.Text = Class3.Titlu[79];
                genderLabel.Text = Class3.Titlu[141];
                connectionLabel.Text = Class3.Titlu[142];
                security_QuestionLabel.Text = Class3.Titlu[143];
                security_AnswerLabel.Text = Class3.Titlu[144];
                button1.Text = Class3.Titlu[81];
                button2.Text = Class3.Titlu[146];
                button3.Text = Class3.Titlu[60];
                button4.Text = Class3.Titlu[60];
                label2.Text = Class3.Titlu[141];
                label5.Text = Class3.Titlu[142];
                label10.Text = Class3.Titlu[143];
                label3.Text = Class3.Titlu[148];
                label4.Text = Class3.Titlu[149];
                label7.Text = Class3.Titlu[150];
                label6.Text = Class3.Titlu[151];
                label9.Text = Class3.Titlu[152];
                label8.Text = Class3.Titlu[153];
                label14.Text = Class3.Titlu[154];
                label12.Text = Class3.Titlu[155];
                label11.Text = Class3.Titlu[156];
                label13.Text = Class3.Titlu[157];
                label16.Text = Class3.Titlu[158];
                groupBox1.Text = Class3.Titlu[159];
                button6.Text = Class3.Titlu[34];
                button7.Text = Class3.Titlu[161];
                label19.Text = Class3.Titlu[162];
                textBox1.Text = Class3.Titlu[163];
                tabControl1.TabPages[0].Text = Class3.Titlu[215];
                tabControl1.TabPages[1].Text = Class3.Titlu[107];
                tabControl1.TabPages[2].Text = Class3.Titlu[231];

                genderTextBox.Location = new Point(613, 166);
                connectionTextBox.Location = new Point(613, 192);
                security_QuestionTextBox.Location = new Point(613, 218);
                security_AnswerTextBox.Location = new Point(613, 244);
                statusTextBox.Location = new Point(613, 270);
                label12.Location = new Point(615, 58);
                label11.Location = new Point(615, 85);
                label13.Location = new Point(615, 111);
            }

            SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
            con.Open();
            string querry2 = @"SELECT * FROM Accounts";
            SqlDataAdapter sda = new SqlDataAdapter(querry2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

            if (Clasa_Intrebari.Limba == 0)
            {
                dt.Columns[1].ColumnName = "Nume";
                dt.Columns[3].ColumnName = "Parolă";
                dt.Columns[4].ColumnName = "Data_nașterii";
                dt.Columns[5].ColumnName = "Gen";
                dt.Columns[6].ColumnName = "Conectivitate";
                dt.Columns[7].ColumnName = "Întrebare";
                dt.Columns[8].ColumnName = "Răspuns";
            }

            idTextBox.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            nameTextBox.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            emailTextBox.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            passwordTextBox.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();


            if (dataGridView1.Rows[0].Cells[4].Value.ToString() != "")
            {
                birthdayDateTimePicker.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                birthdayDateTimePicker.Visible = true;
            }
            else
            {
                birthdayDateTimePicker.Visible = false;
            }

            if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "")
                birthdayDateTimePicker.Visible = true;

            genderTextBox.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            connectionTextBox.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            security_QuestionTextBox.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
            security_AnswerTextBox.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
            statusTextBox.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.No;
            if (Clasa_Intrebari.Limba == 0)
            {
                dialogResult = MessageBox.Show("Urmează să ștergi permanent un cont din baza de date. Continui?", "Atențioare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                dialogResult = MessageBox.Show(Class3.Titlu[216], Class3.Titlu[86], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }

            if (dialogResult == DialogResult.Yes)
            {
                if (emailTextBox.Text == Clasa_Conectare.conectat)
                {
                    Clasa_Conectare.conectat = "";
                    this.Hide();
                    Form4 f4 = new Form4();
                    f4.Show();
                }

                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                string querry = @"DELETE FROM Accounts WHERE Id = '" + idTextBox.Text + "' ";

                SqlCommand com = new SqlCommand(querry, con);

                com.ExecuteNonQuery();
                con.Close();

                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);


                idTextBox.Text = "";
                nameTextBox.Text = "";
                emailTextBox.Text = "";
                passwordTextBox.Text = "";

                DateTime date = DateTime.Now;
                birthdayDateTimePicker.Text = date.ToString();

                genderTextBox.Text = "";
                connectionTextBox.Text = "";
                security_QuestionTextBox.Text = "";
                security_AnswerTextBox.Text = "";
                statusTextBox.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "" && emailTextBox.Text != "" && passwordTextBox.Text != "" && genderTextBox.Text != "" && connectionTextBox.Text != "" && security_AnswerTextBox.Text != "" && security_QuestionTextBox.Text != "" && statusTextBox.Text != "")
            {

                button4.Visible = false;

                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();

                string querry1 = @"SELECT * FROM Accounts WHERE Email = '" + emailTextBox.Text + "' ";

                SqlCommand com1 = new SqlCommand(querry1, con);
                SqlDataReader reader1 = com1.ExecuteReader();

                if (reader1.HasRows == true)
                {
                    reader1.Close();

                    if (Clasa_Intrebari.Limba == 0)
                        MessageBox.Show("Email-ul există deja în baza de date.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (Clasa_Intrebari.Limba == 1)
                        MessageBox.Show(Class3.Titlu[72], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (reader1.HasRows == false)
                {
                    reader1.Close();

                    emailTextBox.BackColor = System.Drawing.Color.White;
                    emailTextBox.ForeColor = System.Drawing.Color.Black;

                    string Name, Email, Password, Security_Answer;
                    int Gender, Connection = 0, Security_Question, Status = 0;
                    Name = nameTextBox.Text;
                    Email = emailTextBox.Text;
                    Password = passwordTextBox.Text;
                    Gender = Int32.Parse(genderTextBox.Text);
                    Security_Question = Int32.Parse(security_QuestionTextBox.Text);
                    Security_Answer = security_AnswerTextBox.Text;
                    DateTime dateTime = birthdayDateTimePicker.Value;

                    string querry;
                    if (bday == true)
                        querry = @"INSERT INTO Accounts (Name, Email, Password, Birthday, Gender, Connection, Security_Question, Security_Answer, Status) VALUES ('" + Name + "' , '" + Email + "' , '" + Password + "' , '" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString() + "' , '" + Gender + "' , '" + Connection + "' , '" + Security_Question + "' , '" + Security_Answer + "' , '" + Status + "')";
                    else
                    {
                        querry = @"INSERT INTO Accounts (Name, Email, Password, Gender, Connection, Security_Question, Security_Answer, Status) VALUES ('" + Name + "' , '" + Email + "' , '" + Password + "' , '" + Gender + "' , '" + Connection + "' , '" + Security_Question + "' , '" + Security_Answer + "' , '" + Status + "')";
                        birthdayDateTimePicker.Visible = false;
                    }

                    SqlCommand com = new SqlCommand(querry, con);
                    com.ExecuteNonQuery();


                    string querry2 = @"SELECT * FROM Accounts";
                    SqlDataAdapter sda = new SqlDataAdapter(querry2, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    con.Close();

                    if (Clasa_Intrebari.Limba == 0)
                    {
                        dt.Columns[1].ColumnName = "Nume";
                        dt.Columns[3].ColumnName = "Parolă";
                        dt.Columns[4].ColumnName = "Data_nașterii";
                        dt.Columns[5].ColumnName = "Gen";
                        dt.Columns[6].ColumnName = "Conectivitate";
                        dt.Columns[7].ColumnName = "Întrebare";
                        dt.Columns[8].ColumnName = "Răspuns";
                    }

                    idTextBox.Text = dataGridView1.Rows[id_nou].Cells[0].Value.ToString();
                }

                reader1.Close();
                con.Close();
            }
            else
            {
                if (nameTextBox.Text == "")
                    pictureBox1.Visible = true;
                else if (nameTextBox.Text != "")
                    pictureBox1.Visible = false;

                if (passwordTextBox.Text == "")
                    pictureBox3.Visible = true;
                else if (passwordTextBox.Text != "")
                    pictureBox3.Visible = false;

                if (emailTextBox.Text == "")
                    pictureBox2.Visible = true;
                else if (emailTextBox.Text != "")
                    pictureBox2.Visible = false;

                if (genderTextBox.Text == "")
                    pictureBox4.Visible = true;
                else if (genderTextBox.Text != "")
                    pictureBox4.Visible = false;

                if (connectionTextBox.Text == "")
                    pictureBox5.Visible = true;
                else if (connectionTextBox.Text != "")
                    pictureBox5.Visible = false;

                if (security_QuestionTextBox.Text == "")
                    pictureBox6.Visible = true;
                else if (security_QuestionTextBox.Text != "")
                    pictureBox6.Visible = false;

                if (security_AnswerTextBox.Text == "")
                    pictureBox7.Visible = true;
                else if (security_AnswerTextBox.Text != "")
                    pictureBox7.Visible = false;

                if (statusTextBox.Text == "")
                    pictureBox8.Visible = true;
                else if (statusTextBox.Text != "")
                    pictureBox8.Visible = false;

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Există spații necompletate.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Clasa_Intrebari.Limba == 1)
                    MessageBox.Show(Class3.Titlu[77], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form39_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Fără" || button4.Text == "Without")
            {
                bday = false;
                birthdayDateTimePicker.Enabled = false;

                if (Clasa_Intrebari.Limba == 0)
                    button4.Text = "Cu";
                else if (Clasa_Intrebari.Limba == 1)
                    button4.Text = Class3.Titlu[139];
            }
            else if (button4.Text == "Cu" || button4.Text == "With")
            {
                bday = true;
                birthdayDateTimePicker.Enabled = true;

                if (Clasa_Intrebari.Limba == 0)
                    button4.Text = "Fără";
                else if (Clasa_Intrebari.Limba == 1)
                    button4.Text = Class3.Titlu[140];
            }

            if (button4.Text == "Modif." || button4.Text == "Add")
            {
                birthdayDateTimePicker.Visible = true;
                birthdayDateTimePicker.Enabled = true;

                if (Clasa_Intrebari.Limba == 0)
                    button4.Text = "Renunț";
                else if (Clasa_Intrebari.Limba == 1)
                    button4.Text = Class3.Titlu[147];
            }
            else if (button4.Text == "Renunț" || button4.Text == "Cancel")
            {
                birthdayDateTimePicker.Visible = false;
                birthdayDateTimePicker.Enabled = false;

                if (Clasa_Intrebari.Limba == 0)
                    button4.Text = "Modif.";
                else if (Clasa_Intrebari.Limba == 1)
                    button4.Text = Class3.Titlu[60];
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        bool conectat;

        private void button2_Click(object sender, EventArgs e)
        {
            birthdayDateTimePicker.Enabled = true;

            if (nameTextBox.Text != "" && emailTextBox.Text != "" && passwordTextBox.Text != "" && genderTextBox.Text != "" && connectionTextBox.Text != "" && security_AnswerTextBox.Text != "" && security_QuestionTextBox.Text != "" && statusTextBox.Text != "")
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;

                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                string querry;
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString() != "")
                    querry = @"UPDATE Accounts SET Name = @name , Email = @email , Password = @password , Birthday = @birthday , Gender = @gender , Connection = @connection , Security_Question = @question , Security_Answer = @answer , Status = @status WHERE Id = '" + idTextBox.Text + "' ";
                else querry = @"UPDATE Accounts SET Name = @name , Email = @email , Password = @password , Gender = @gender , Connection = @connection , Security_Question = @question , Security_Answer = @answer , Status = @status WHERE Id = '" + idTextBox.Text + "' ";

                SqlCommand com = new SqlCommand(querry, con);
                com.Parameters.AddWithValue("name", nameTextBox.Text);
                com.Parameters.AddWithValue("email", emailTextBox.Text);
                com.Parameters.AddWithValue("password", passwordTextBox.Text);
                com.Parameters.AddWithValue("gender", genderTextBox.Text);
                com.Parameters.AddWithValue("connection", connectionTextBox.Text);
                com.Parameters.AddWithValue("question", security_QuestionTextBox.Text);
                com.Parameters.AddWithValue("answer", security_AnswerTextBox.Text);
                com.Parameters.AddWithValue("status", statusTextBox.Text);

                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() != "")
                {
                    DateTime dateTime = birthdayDateTimePicker.Value;
                    com.Parameters.AddWithValue("birthday", dateTime.Month.ToString() + "/" + dateTime.Day.ToString() + "/" + dateTime.Year.ToString());
                }

                com.ExecuteNonQuery();

                if (conectat == true)
                    Clasa_Conectare.conectat = emailTextBox.Text;

                string querry2 = @"SELECT * FROM Accounts";
                SqlDataAdapter sda = new SqlDataAdapter(querry2, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();

                if (Clasa_Intrebari.Limba == 0)
                {
                    dt.Columns[1].ColumnName = "Nume";
                    dt.Columns[3].ColumnName = "Parolă";
                    dt.Columns[4].ColumnName = "Data_nașterii";
                    dt.Columns[5].ColumnName = "Gen";
                    dt.Columns[6].ColumnName = "Conectivitate";
                    dt.Columns[7].ColumnName = "Întrebare";
                    dt.Columns[8].ColumnName = "Răspuns";
                }

                button4.Visible = false;
            }
            else
            {
                if (nameTextBox.Text == "")
                    pictureBox1.Visible = true;
                else if (nameTextBox.Text != "")
                    pictureBox1.Visible = false;

                if (passwordTextBox.Text == "")
                    pictureBox3.Visible = true;
                else if (passwordTextBox.Text != "")
                    pictureBox3.Visible = false;

                if (emailTextBox.Text == "")
                    pictureBox2.Visible = true;
                else if (emailTextBox.Text != "")
                    pictureBox2.Visible = false;

                if (genderTextBox.Text == "")
                    pictureBox4.Visible = true;
                else if (genderTextBox.Text != "")
                    pictureBox4.Visible = false;

                if (connectionTextBox.Text == "")
                    pictureBox5.Visible = true;
                else if (connectionTextBox.Text != "")
                    pictureBox5.Visible = false;

                if (security_QuestionTextBox.Text == "")
                    pictureBox6.Visible = true;
                else if (security_QuestionTextBox.Text != "")
                    pictureBox6.Visible = false;

                if (security_AnswerTextBox.Text == "")
                    pictureBox7.Visible = true;
                else if (security_AnswerTextBox.Text != "")
                    pictureBox7.Visible = false;

                if (statusTextBox.Text == "")
                    pictureBox8.Visible = true;
                else if (statusTextBox.Text != "")
                    pictureBox8.Visible = false;

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Există spații necompletate.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Clasa_Intrebari.Limba == 1)
                    MessageBox.Show(Class3.Titlu[77], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            nameTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            emailTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            passwordTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();

            DateTime date = DateTime.Now;
            if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString() != "")
            {
                birthdayDateTimePicker.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
                birthdayDateTimePicker.Visible = true;
                birthdayDateTimePicker.Enabled = true;
            }
            else if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString() == "")
            {
                birthdayDateTimePicker.Visible = false;
            }

            if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() == "")
            {
                birthdayDateTimePicker.Visible = true;
                birthdayDateTimePicker.Enabled = true;
                button4.Visible = true;

                if (Clasa_Intrebari.Limba == 0)
                {
                    button4.Text = "Fără";
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    button4.Text = Class3.Titlu[140];
                }
            }
            else if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() != "" && dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString() == "")
            {
                button4.Visible = true;

                if (Clasa_Intrebari.Limba == 0)
                {
                    button4.Text = "Modif.";
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    button4.Text = Class3.Titlu[60];
                }
            }
            else button4.Visible = false;

            genderTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
            connectionTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
            security_QuestionTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
            security_AnswerTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
            statusTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString();

            id_nou = dataGridView1.CurrentCell.RowIndex;

            if (Clasa_Conectare.conectat == emailTextBox.Text)
                conectat = true;
            else conectat = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profil f35 = new Profil();
            f35.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "";
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            passwordTextBox.Text = "";

            DateTime date = DateTime.Now;
            birthdayDateTimePicker.Text = date.ToString();

            genderTextBox.Text = "";
            connectionTextBox.Text = "";
            security_QuestionTextBox.Text = "";
            security_AnswerTextBox.Text = "";
            statusTextBox.Text = "";

            button7.Visible = true;

            int results = 0;
            DataTable tabel = new DataTable();


            if (Clasa_Intrebari.Limba == 1)
            {
                tabel.Columns.Add("Id", typeof(int));
                tabel.Columns.Add("Name", typeof(string));
                tabel.Columns.Add("Email", typeof(string));
                tabel.Columns.Add("Password", typeof(string));
                tabel.Columns.Add("Birthday", typeof(DateTime));
                tabel.Columns.Add("Gender", typeof(int));
                tabel.Columns.Add("Connection", typeof(int));
                tabel.Columns.Add("Security_Question", typeof(int));
                tabel.Columns.Add("Security_Answer", typeof(string));
                tabel.Columns.Add("Status", typeof(int));
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                tabel.Columns.Add("Id", typeof(int));
                tabel.Columns.Add("Nume", typeof(string));
                tabel.Columns.Add("Email", typeof(string));
                tabel.Columns.Add("Parolă", typeof(string));
                tabel.Columns.Add("Data_nașterii", typeof(DateTime));
                tabel.Columns.Add("Gen", typeof(int));
                tabel.Columns.Add("Conectivitate", typeof(int));
                tabel.Columns.Add("Întrebare", typeof(int));
                tabel.Columns.Add("Răspuns", typeof(string));
                tabel.Columns.Add("Status", typeof(int));
            }

            SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
            con.Open();
            string querry = @"SELECT * FROM Accounts";

            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();

            string[] nume_prenume = new string[50];
            string[] nume_tabel = new string[50];
            while (reader.Read())
            {
                nume_prenume = textBox1.Text.Split(' ').Select(text => text.ToString()).ToArray();
                nume_tabel = reader["Name"].ToString().Split(' ').Select(text => text.ToString()).ToArray();

                if (textBox1.Text != "")
                {
                    if (nume_tabel[0] == nume_prenume[0] && nume_prenume.Length == 1)
                    {
                        results++;

                        if (reader["Birthday"].ToString() == "")
                            tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                        else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                    }
                    else if (nume_tabel[1] == nume_prenume[0] && nume_prenume.Length == 1)
                    {
                        results++;

                        if (reader["Birthday"].ToString() == "")
                            tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                        else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                    }
                    else if (nume_tabel.Length == 3 && nume_prenume.Length == 1)
                    {
                        if (nume_prenume[0] == nume_tabel[2])
                        {
                            results++;

                            if (reader["Birthday"].ToString() == "")
                                tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                            else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                        }
                    }
                    else if (nume_prenume.Length == 2)
                    {
                        if (nume_tabel[0] + " " + nume_tabel[1] == nume_prenume[0] + " " + nume_prenume[1])
                        {
                            results++;

                            if (reader["Birthday"].ToString() == "")
                                tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                            else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                        }
                        else if (nume_tabel.Length == 3)
                        {
                            if (nume_tabel[0] + " " + nume_tabel[2] == nume_prenume[0] + " " + nume_prenume[1])
                            {
                                results++;

                                if (reader["Birthday"].ToString() == "")
                                    tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                                else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                            }
                            else if (nume_tabel[1] + " " + nume_tabel[2] == nume_prenume[0] + " " + nume_prenume[1])
                            {
                                results++;

                                if (reader["Birthday"].ToString() == "")
                                    tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                                else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                            }
                            else if (nume_tabel[2] + " " + nume_tabel[1] == nume_prenume[0] + " " + nume_prenume[1])
                            {
                                results++;

                                if (reader["Birthday"].ToString() == "")
                                    tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                                else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                            }
                        }
                    }
                    else if (nume_prenume.Length == 3 && nume_tabel.Length == 3)
                    {
                        if (nume_tabel[0] + " " + nume_tabel[1] + " " + nume_tabel[2] == nume_prenume[0] + " " + nume_prenume[1] + " " + nume_prenume[2])
                        {
                            results++;

                            if (reader["Birthday"].ToString() == "")
                                tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                            else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                        }
                        else if (nume_tabel[0] + " " + nume_tabel[1] + " " + nume_tabel[2] == nume_prenume[0] + " " + nume_prenume[2] + " " + nume_prenume[1])
                        {
                            results++;

                            if (reader["Birthday"].ToString() == "")
                                tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                            else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                        }
                    }
                    else if (reader["Email"].ToString() == textBox1.Text)
                    {
                        results++;

                        if (reader["Birthday"].ToString() == "")
                            tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                        else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                    }
                }
            }

            reader.Close();
            con.Close();

            dataGridView1.DataSource = tabel;

            if (results == 0)
            {
                label20.Visible = true;

                if (Clasa_Intrebari.Limba == 0)
                    label20.Text = "Nu s-a găsit niciun cont cu datele menționate.";
                else if (Clasa_Intrebari.Limba == 1)
                    label20.Text = Class3.Titlu[160];
            }
            else if (results == 1)
            {
                idTextBox.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                nameTextBox.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                emailTextBox.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                passwordTextBox.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();

                DateTime dateTime = DateTime.Now;
                if (dataGridView1.Rows[0].Cells[4].Value.ToString() != "")
                {
                    birthdayDateTimePicker.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    birthdayDateTimePicker.Visible = true;
                }
                else
                {
                    birthdayDateTimePicker.Visible = false;
                }

                if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "")
                    birthdayDateTimePicker.Visible = true;

                genderTextBox.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
                connectionTextBox.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
                security_QuestionTextBox.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
                security_AnswerTextBox.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
                statusTextBox.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();

                label20.Visible = true;

                if (Clasa_Intrebari.Limba == 0)
                    label20.Text = "S-a găsit " + results.ToString() + " rezultat.";
                else if (Clasa_Intrebari.Limba == 1)
                    label20.Text = "We found " + results.ToString() + " result.";
            }
            else if (results > 1)
            {
                idTextBox.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                nameTextBox.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                emailTextBox.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                passwordTextBox.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();

                if (dataGridView1.Rows[0].Cells[4].Value.ToString() != "")
                {
                    birthdayDateTimePicker.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    birthdayDateTimePicker.Visible = true;
                }
                else
                {
                    birthdayDateTimePicker.Visible = false;
                }

                if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "")
                    birthdayDateTimePicker.Visible = true;

                genderTextBox.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
                connectionTextBox.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
                security_QuestionTextBox.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
                security_AnswerTextBox.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
                statusTextBox.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();

                label20.Visible = true;

                if (Clasa_Intrebari.Limba == 0)
                    label20.Text = "S-au găsit " + results.ToString() + " rezultate.";
                else if (Clasa_Intrebari.Limba == 1)
                    label20.Text = "We found " + results.ToString() + " results.";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
            con.Open();
            string querry2 = @"SELECT * FROM Accounts";
            SqlDataAdapter sda = new SqlDataAdapter(querry2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

            if (Clasa_Intrebari.Limba == 0)
            {
                dt.Columns[1].ColumnName = "Nume";
                dt.Columns[3].ColumnName = "Parolă";
                dt.Columns[4].ColumnName = "Data_nașterii";
                dt.Columns[5].ColumnName = "Gen";
                dt.Columns[6].ColumnName = "Conectivitate";
                dt.Columns[7].ColumnName = "Întrebare";
                dt.Columns[8].ColumnName = "Răspuns";
            }

            label20.Visible = false;
            if (Clasa_Intrebari.Limba == 0)
                textBox1.Text = "Nume/Prenume/Email";
            else if (Clasa_Intrebari. Limba == 1)
                textBox1.Text = Class3.Titlu[163];

            textBox1.ForeColor = System.Drawing.Color.Gray;
            textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, FontStyle.Italic);

            button7.Visible = false;

            idTextBox.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            nameTextBox.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            emailTextBox.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            passwordTextBox.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();

            if (dataGridView1.Rows[0].Cells[4].Value.ToString() != "")
            {
                birthdayDateTimePicker.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                birthdayDateTimePicker.Visible = true;
            }
            else
            {
                birthdayDateTimePicker.Visible = false;
            }

            if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "")
                birthdayDateTimePicker.Visible = true;

            genderTextBox.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            connectionTextBox.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            security_QuestionTextBox.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
            security_AnswerTextBox.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
            statusTextBox.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nume/Prenume/Email" || textBox1.Text == "Surname/Name/Email")
                textBox1.Text = "";

            textBox1.ForeColor = System.Drawing.Color.Black;
            textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, FontStyle.Regular);
        }

        private void upgradeButton_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                pictureBox12.Visible = false;
                pictureBox13.Visible = false;
                pictureBox14.Visible = false;
                pictureBox15.Visible = false;
                pictureBox16.Visible = false;

                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                string querry = "";
                if (Clasa_Intrebari.Limba == 0)
                    querry = @"UPDATE Questions SET Question = @question , Option1 = @option1 , Option2 = @option2 , Option3 = @option3 , Location = @location WHERE Id = '" + (listBox1.SelectedIndex + 1) + "'";
                else if (Clasa_Intrebari.Limba == 1)
                    querry = @"UPDATE Questions SET Question = @question , Option1 = @option1 , Option2 = @option2 , Option3 = @option3 , Location = @location WHERE Id = '" + (listBox1.SelectedIndex + 1) * 1000 + "'";

                SqlCommand com = new SqlCommand(querry, con);
                com.Parameters.AddWithValue("question", textBox2.Text);
                com.Parameters.AddWithValue("option1", textBox3.Text);
                com.Parameters.AddWithValue("option2", textBox4.Text);
                com.Parameters.AddWithValue("option3", textBox5.Text);
                com.Parameters.AddWithValue("location", textBox6.Text);

                com.ExecuteNonQuery();
                listBox1.Items.Clear();

                int c = 0;
                querry = @"SELECT * FROM Questions";

                SqlCommand com1 = new SqlCommand(querry, con);
                SqlDataReader reader = com1.ExecuteReader();

                if (Clasa_Intrebari.Limba == 0)
                {
                    while (reader.Read())
                        if (c < nr_rows)
                        {
                            c++;
                            listBox1.Items.Add(reader["Question"].ToString());
                        }
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    while (reader.Read())
                        if (c >= nr_rows)
                            listBox1.Items.Add(reader["Question"].ToString());
                        else c++;
                }

                reader.Close();
                con.Close();
            }
            else
            {
                if (textBox2.Text == "")
                    pictureBox12.Visible = true;
                else if (textBox2.Text != "")
                    pictureBox12.Visible = false;

                if (textBox3.Text == "")
                    pictureBox13.Visible = true;
                else if (textBox3.Text != "")
                    pictureBox13.Visible = false;

                if (textBox4.Text == "")
                    pictureBox14.Visible = true;
                else if (textBox4.Text != "")
                    pictureBox14.Visible = false;

                if (textBox5.Text == "")
                    pictureBox15.Visible = true;
                else if (textBox5.Text != "")
                    pictureBox15.Visible = false;

                if (textBox6.Text == "")
                    pictureBox16.Visible = true;
                else if (textBox6.Text != "")
                    pictureBox16.Visible = false;

                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Există spații necompletate.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Clasa_Intrebari.Limba == 1)
                    MessageBox.Show(Class3.Titlu[77], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                pictureBox20.Visible = false;
                pictureBox17.Visible = false;
                pictureBox18.Visible = false;
                pictureBox19.Visible = false;
                pictureBox23.Visible = false;
                pictureBox24.Visible = false;
                pictureBox25.Visible = false;
                pictureBox26.Visible = false;
                pictureBox27.Visible = false;

                string txt = "";
                if (comboBox1.Text == "Looking Glass")
                {
                    if (comboBox2.Text == "Scurtă descriere" || comboBox2.Text == "Short description")
                        txt = "file1.txt";
                    else if (comboBox2.Text == "Începuturi" || comboBox2.Text == "Beginning")
                        txt = "file2.txt";
                }
                else if (comboBox1.Text == "Ultima Underworld: The Stygian Abyss")
                {
                    if (comboBox2.Text == "Introducere și descriere" || comboBox2.Text == "Introduction and description")
                        txt = "uw1.txt";
                    else if (comboBox2.Text == "Mecanici de joc" || comboBox2.Text == "Gameplay")
                        txt = "uw2.txt";
                    else if (comboBox2.Text == "Poveste" || comboBox2.Text == "Story")
                        txt = "uw3.txt";
                    else if (comboBox2.Text == "Concluzie" || comboBox2.Text == "Conclusions")
                        txt = "uw4.txt";
                }
                else if (comboBox1.Text == "Ultima Underworld II: Labyrinth of Worlds")
                {
                    if (comboBox2.Text == "Introducere și descriere" || comboBox2.Text == "Introduction and description")
                        txt = "uw21.txt";
                    else if (comboBox2.Text == "Poveste" || comboBox2.Text == "Story")
                        txt = "uw22.txt";
                    else if (comboBox2.Text == "Detalii noi" || comboBox2.Text == "New details")
                        txt = "uw23.txt";
                    else if (comboBox2.Text == "Concluzie" || comboBox2.Text == "Conclusions")
                        txt = "uw24.txt";
                }
                else if (comboBox1.Text == "System Shock")
                {
                    if (comboBox2.Text == "Introducere și descriere" || comboBox2.Text == "Introduction and description")
                        txt = "ss1.txt";
                    else if (comboBox2.Text == "Mecanici de joc" || comboBox2.Text == "Gameplay")
                        txt = "ss2.txt";
                    else if (comboBox2.Text == "Antagoniști" || comboBox2.Text == "Enemies")
                        txt = "ss3.txt";
                    else if (comboBox2.Text == "Concluzie" || comboBox2.Text == "Conclusions")
                        txt = "ss4.txt";
                }
                else if (comboBox1.Text == "Flight Unlimited")
                {
                    if (comboBox2.Text == "Descriere" || comboBox2.Text == "Description")
                        txt = "fu.txt";
                }
                else if (comboBox1.Text == "Terra Nova: Strike Force Centauri")
                {
                    if (comboBox2.Text == "Introducere și descriere" || comboBox2.Text == "Introduction and description")
                        txt = "tn1.txt";
                    else if (comboBox2.Text == "Mecanici de joc" || comboBox2.Text == "Gameplay")
                        txt = "tn2.txt";
                    else if (comboBox2.Text == "Poveste" || comboBox2.Text == "Story")
                        txt = "tn3.txt";
                    else if (comboBox2.Text == "Concluzie" || comboBox2.Text == "Conclusions")
                        txt = "tn4.txt";
                }
                else if (comboBox1.Text == "British Open Championship Golf")
                {
                    if (comboBox2.Text == "Descriere" || comboBox2.Text == "Description")
                        txt = "bocg.txt";
                }
                else if (comboBox1.Text == "Flight Unlimited 2")
                {
                    if (comboBox2.Text == "Descriere" || comboBox2.Text == "Description")
                        txt = "fu2.txt";
                }
                else if (comboBox1.Text == "System Shock 2")
                {
                    if (comboBox2.Text == "Introducere și descriere" || comboBox2.Text == "Introduction and description")
                        txt = "ss21.txt";
                    else if (comboBox2.Text == "Categorii de personaje" || comboBox2.Text == "Categories of characters")
                        txt = "ss22.txt";
                    else if (comboBox2.Text == "Mecanici de joc" || comboBox2.Text == "Gameplay")
                        txt = "ss23.txt";
                    else if (comboBox2.Text == "Concluzie" || comboBox2.Text == "Conclusions")
                        txt = "ss24.txt";
                }
                else if (comboBox1.Text == "Flight Unlimited 3")
                {
                    if (comboBox2.Text == "Descriere" || comboBox2.Text == "Description")
                        txt = "fu3.txt";
                }
                else if (comboBox1.Text == "Thief II: The Metal Age")
                {
                    if (comboBox2.Text == "Introducere și descriere" || comboBox2.Text == "Introduction and description")
                        txt = "t21.txt";
                    else if (comboBox2.Text == "Mecanici de joc" || comboBox2.Text == "Gameplay")
                        txt = "t22.txt";
                    else if (comboBox2.Text == "Misiuni" || comboBox2.Text == "Missions")
                        txt = "t23.txt";
                    else if (comboBox2.Text == "Concluzie" || comboBox2.Text == "Conclusions")
                        txt = "t24.txt";
                }
                else if (comboBox1.Text == "Thief: The Dark Project")
                {
                    if (comboBox2.Text == "Introducere și descriere" || comboBox2.Text == "Introduction and description")
                        txt = "t1.txt";
                    else if (comboBox2.Text == "Design de nivel" || comboBox2.Text == "Level design")
                        txt = "t2.txt";
                    else if (comboBox2.Text == "Mecanici de joc" || comboBox2.Text == "Gameplay")
                        txt = "t3.txt";
                    else if (comboBox2.Text == "Concluzie" || comboBox2.Text == "Conclusions")
                        txt = "t4.txt";
                }
                else
                {
                    pictureBox21.Visible = true;
                    pictureBox22.Visible = true;

                    if (Clasa_Intrebari.Limba == 0)
                        MessageBox.Show("Locul menționat nu există.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (Clasa_Intrebari.Limba == 1)
                        MessageBox.Show(Class3.Titlu[218], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (txt != "")
                {
                    pictureBox21.Visible = false;
                    pictureBox22.Visible = false;

                    SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                    con.Open();

                    string querry = @"INSERT INTO Questions (Id, Question, Option1, Option2, Option3, Answer, Location, Status) VALUES ('" + (nr_rows + 1) + "' , '" + textBox7.Text + "' , '" + textBox10.Text + "' , '" + textBox9.Text + "' , '" + textBox8.Text + "' , '" + textBox15.Text + "' , '" + "\\texte_RO\\" + txt + "' , '" + 0 + "')";
                    SqlCommand com = new SqlCommand(querry, con);
                    com.ExecuteNonQuery();

                    querry = @"INSERT INTO Questions (Id, Question, Option1, Option2, Option3, Answer, Location, Status) VALUES ('" + (nr_rows + 1) * 1000 + "' , '" + textBox11.Text + "' , '" + textBox14.Text + "' , '" + textBox13.Text + "' , '" + textBox12.Text + "' , '" + textBox15.Text + "' , '" + "\\texte_EN\\" + txt + "' , '" + 0 + "')";
                    SqlCommand com1 = new SqlCommand(querry, con);
                    com1.ExecuteNonQuery();

                    nr_rows++;

                    int c = 0;
                    querry = @"SELECT * FROM Questions";

                    SqlCommand com2 = new SqlCommand(querry, con);
                    SqlDataReader reader = com2.ExecuteReader();

                    if (Clasa_Intrebari.Limba == 0)
                    {
                        while (reader.Read())
                            if (c < nr_rows)
                            {
                                c++;
                                listBox1.Items.Add(reader["Question"].ToString());
                            }
                    }
                    else if (Clasa_Intrebari.Limba == 1)
                    {
                        while (reader.Read())
                            if (c >= nr_rows)
                                listBox1.Items.Add(reader["Question"].ToString());
                            else c++;
                    }

                    reader.Close();
                    con.Close();
                }
            }
            else
            {
                if (textBox7.Text == "")
                    pictureBox20.Visible = true;
                else if (textBox7.Text != "")
                    pictureBox20.Visible = false;

                if (textBox8.Text == "")
                    pictureBox17.Visible = true;
                else if (textBox8.Text != "")
                    pictureBox17.Visible = false;

                if (textBox9.Text == "")
                    pictureBox18.Visible = true;
                else if (textBox9.Text != "")
                    pictureBox18.Visible = false;

                if (textBox10.Text == "")
                    pictureBox19.Visible = true;
                else if (textBox10.Text != "")
                    pictureBox19.Visible = false;

                if (textBox11.Text == "")
                    pictureBox23.Visible = true;
                else if (textBox11.Text != "")
                    pictureBox23.Visible = false;

                if (textBox12.Text == "")
                    pictureBox24.Visible = true;
                else if (textBox12.Text != "")
                    pictureBox24.Visible = false;

                if (textBox13.Text == "")
                    pictureBox25.Visible = true;
                else if (textBox13.Text != "")
                    pictureBox25.Visible = false;

                if (textBox14.Text == "")
                    pictureBox26.Visible = true;
                else if (textBox14.Text != "")
                    pictureBox26.Visible = false;

                if (textBox15.Text == "")
                    pictureBox27.Visible = true;
                else if (textBox15.Text != "")
                    pictureBox27.Visible = false;

                if (comboBox1.Text == "")
                    pictureBox21.Visible = true;
                else if (comboBox1.Text != "")
                    pictureBox21.Visible = false;

                if (comboBox2.Text == "")
                    pictureBox22.Visible = true;
                else if (comboBox2.Text != "")
                    pictureBox22.Visible = false;


                if (Clasa_Intrebari.Limba == 0)
                    MessageBox.Show("Există spații necompletate.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Clasa_Intrebari.Limba == 1)
                    MessageBox.Show(Class3.Titlu[77], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int id1 = 0, id2 = 0;

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id1 = Int32.Parse(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.No;
            if (Clasa_Intrebari.Limba == 0)
            {
                dialogResult = MessageBox.Show("Urmează să ștergi permanent o informație din baza de date. Continui?", "Atențioare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                dialogResult = MessageBox.Show(Class3.Titlu[230], Class3.Titlu[86], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }

            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                string querry = @"DELETE FROM Results_Quiz WHERE Id = '" + id1 + "' ";

                SqlCommand com = new SqlCommand(querry, con);

                com.ExecuteNonQuery();

                querry = @"SELECT * FROM Results_Quiz";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;

                if (Clasa_Intrebari.Limba == 0)
                {
                    dt.Columns[2].ColumnName = "Număr";
                    dt.Columns[3].ColumnName = "Corecte";
                    dt.Columns[4].ColumnName = "Greșite";
                    dt.Columns[5].ColumnName = "Timp";
                    dt.Columns[6].ColumnName = "Dată";
                    dt.Columns[7].ColumnName = "Primul";
                }

                con.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.No;
            if (Clasa_Intrebari.Limba == 0)
            {
                dialogResult = MessageBox.Show("Urmează să ștergi permanent o informație din baza de date. Continui?", "Atențioare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                dialogResult = MessageBox.Show(Class3.Titlu[230], Class3.Titlu[86], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }

            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();
                string querry = @"DELETE FROM Xand0 WHERE Id = '" + id2 + "' ";

                SqlCommand com = new SqlCommand(querry, con);

                com.ExecuteNonQuery();

                querry = @"SELECT * FROM Xand0";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView3.DataSource = dt;

                if (Clasa_Intrebari.Limba == 0)
                {
                    dt.Columns[3].ColumnName = "Câștig_X";
                    dt.Columns[4].ColumnName = "Câștig_0";
                    dt.Columns[5].ColumnName = "Total";
                    dt.Columns[6].ColumnName = "Dată";
                }

                con.Close();
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             id2 = Int32.Parse(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[0].Value.ToString());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;

            SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
            con.Open();

            string querry = "";
            if (Clasa_Intrebari.Limba == 0)
                querry = @"SELECT * FROM Questions WHERE Id = '" + (listBox1.SelectedIndex + 1) + "' ";
            else if (Clasa_Intrebari.Limba == 1)
                querry = @"SELECT * FROM Questions WHERE Id = '" + (listBox1.SelectedIndex + 1) * 1000 + "' ";

            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();

            pictureBox9.Image = imageList1.Images[1];
            pictureBox10.Image = imageList1.Images[1];
            pictureBox11.Image = imageList1.Images[1];

            string[] where = new string[50];

            while (reader.Read())
                if (reader.HasRows == true)
                {
                    textBox2.Text = reader["Question"].ToString();
                    textBox3.Text = reader["Option1"].ToString();
                    textBox4.Text = reader["Option2"].ToString();
                    textBox5.Text = reader["Option3"].ToString();
                    textBox6.Text = reader["Location"].ToString();

                    int aux = Int32.Parse(reader["Answer"].ToString());
                    while (aux != 0)
                    {
                        if (aux % 10 == 1)
                            pictureBox9.Image = imageList1.Images[0];
                        else if (aux % 10 == 2)
                            pictureBox10.Image = imageList1.Images[0];
                        else if (aux % 10 == 3)
                            pictureBox11.Image = imageList1.Images[0];

                        aux = aux / 10;
                    }
                }

            reader.Close();
            con.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 1)
            {
                question1Label.Text = Class3.Titlu[219];
                answers1Label.Text = Class3.Titlu[220];
                where1Label.Text = Class3.Titlu[221];
                where2Label.Text = Class3.Titlu[221];
                question2Label.Text = Class3.Titlu[222];
                question3Label.Text = Class3.Titlu[223];
                answers2Label.Text = Class3.Titlu[224];
                answers3Label.Text = Class3.Titlu[225];
                correctLabel.Text = Class3.Titlu[226];
                correct1Label.Text = Class3.Titlu[227] + Environment.NewLine + Class3.Titlu[228] + Environment.NewLine + Class3.Titlu[229];

                upgradeButton.Text = Class3.Titlu[146];
                addButton.Text = Class3.Titlu[60];

                comboBox2.Items.Clear();
                comboBox2.Items.Add("Short description");
                comboBox2.Items.Add("Beginning");
                comboBox2.Items.Add("Introduction and description");
                comboBox2.Items.Add("Description");
                comboBox2.Items.Add("Gameplay");
                comboBox2.Items.Add("Level design");
                comboBox2.Items.Add("Categories of characters");
                comboBox2.Items.Add("Enemies");
                comboBox2.Items.Add("Missions");
                comboBox2.Items.Add("Story");
                comboBox2.Items.Add("New details");
                comboBox2.Items.Add("Conclusions");
            }

            if (tabControl1.SelectedIndex == 1 && first == false)
            {
                first = true;

                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();

                string querry = @"SELECT COUNT(*) FROM Questions";
                SqlCommand com = new SqlCommand(querry, con);
                int rows = Int32.Parse(com.ExecuteScalar().ToString()), c = 0;
                nr_rows = rows / 2;

                querry = @"SELECT * FROM Questions";

                SqlCommand com1 = new SqlCommand(querry, con);
                SqlDataReader reader = com1.ExecuteReader();

                if (Clasa_Intrebari.Limba == 0)
                {
                    while (reader.Read())
                        if (c < rows / 2)
                        {
                            c++;
                            listBox1.Items.Add(reader["Question"].ToString());
                        }
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    while (reader.Read())
                        if (c >= rows / 2)
                            listBox1.Items.Add(reader["Question"].ToString());
                        else c++;
                }

                reader.Close();
                con.Close();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                SqlConnection con = new SqlConnection(Clasa_Conectare.variabila);
                con.Open();

                string querry = @"SELECT * FROM Results_Quiz";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;

                if (Clasa_Intrebari.Limba == 0)
                {
                    dt.Columns[2].ColumnName = "Număr";
                    dt.Columns[3].ColumnName = "Corecte";
                    dt.Columns[4].ColumnName = "Greșite";
                    dt.Columns[5].ColumnName = "Timp";
                    dt.Columns[6].ColumnName = "Dată";
                    dt.Columns[7].ColumnName = "Primul";
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    button8.Text = Class3.Titlu[232];
                    button9.Text = Class3.Titlu[232];

                    label21.Text = Class3.Titlu[233];
                    label22.Text = Class3.Titlu[234];
                }

                querry = @"SELECT * FROM Xand0";
                SqlDataAdapter sda1 = new SqlDataAdapter(querry, con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                dataGridView3.DataSource = dt1;

                if (Clasa_Intrebari.Limba == 0)
                {
                    dt1.Columns[3].ColumnName = "Câștig_X";
                    dt1.Columns[4].ColumnName = "Câștig_0";
                    dt1.Columns[5].ColumnName = "Total";
                    dt1.Columns[6].ColumnName = "Dată";
                }

                con.Close();
            }
        }
    }
}
