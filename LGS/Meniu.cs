using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGS
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aici se stabilește către ce descriere de joc este trimis utilizatorul, conform selectării din comboBox
            int op;
            op = comboBox1.SelectedIndex;
            if(op == 0)
            {
                //Ultima Underworld
                this.Hide();
                Form13 f13 = new Form13();
                f13.Show();
            }
            if (op == 1)
            {
                //Ultima Underworld II
                this.Hide();
                UltimaUnderworld2_1 f15 = new UltimaUnderworld2_1();
                f15.Show();
            }
            if (op == 2)
            {
                //System Shock
                this.Hide();
                Form17 f17 = new Form17();
                f17.Show();
            }
            if (op == 3)
            {
                //Flight Unlimited
                this.Hide();
                FlightUnlimited f19 = new FlightUnlimited();
                f19.Show();
            }
            if (op == 4)
            {
                //Terra Nova: Strike Force Centauri
                this.Hide();
                TerraNova_1 f20 = new TerraNova_1();
                f20.Show();
            }
            if (op == 5)
            {
                //British Open Championship Golf
                //Flight Unlimited 2
                this.Hide();
                BritishOpenChampGolf f22 = new BritishOpenChampGolf();
                f22.Show();
            }
            if (op == 6)
            {
                //Thief: The Dark Project
                this.Hide();
                Form5 f5 = new Form5();
                f5.Show();
            }
            if (op == 7)
            {
                //System Shock 2
                //Flight Unlimited 3
                this.Hide();
                Form7 f7 = new Form7();
                f7.Show();
            }
            if (op == 8)
            {
                //Thief II: The Metal Age
                this.Hide();
                Form10 f10 = new Form10();
                f10.Show();
            }
            //
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //alegerea Form-ului cu descrierea jocului la apăsarea pictureBox-ului
            if (i == 0) //Ultima Underworld
            {
                this.Hide();
                Form13 f13 = new Form13();
                f13.Show();
            }
            else if (i == 1) //Ultima Underworld II
            {
                this.Hide();
                UltimaUnderworld2_1 f15 = new UltimaUnderworld2_1();
                f15.Show();
            }
            else if (i == 2) //System Shock
            {
                this.Hide();
                Form17 f17 = new Form17();
                f17.Show();
            }
            else if (i == 3) //Flight Unlimited
            {
                this.Hide();
                FlightUnlimited f19 = new FlightUnlimited();
                f19.Show();
            }
            else if (i == 4) //Terra Nova: Strike Force Centauri
            {
                this.Hide();
                TerraNova_1 f20 = new TerraNova_1();
                f20.Show();
            }
            else if (i == 5) //British Open Championship Golf
            {
                this.Hide();
                BritishOpenChampGolf f22 = new BritishOpenChampGolf();
                f22.Show();
            }
            else if (i == 6) //Flight Unlimited 2
            {
                this.Hide();
                FlightUnlimited2 f23 = new FlightUnlimited2();
                f23.Show();
            }
            else if (i == 7) //Thief: The Dark Project
            {
                this.Hide();
                Form5 f5 = new Form5();
                f5.Show();
            }
            else if (i == 8) //System Shock 2
            {
                this.Hide();
                Form7 f7 = new Form7();
                f7.Show();
            }
            else if (i == 9) //Flight Unlimited 3
            {
                this.Hide();
                Form9 f9 = new Form9();
                f9.Show();
            }
            else if (i == 10) //Thief II: The Metal Age
            {
                this.Hide();
                Form10 f10 = new Form10();
                f10.Show();
            }
            //
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //traducerea, din română în engleză, a textului din cuprins, respectiv repoziționarea unui obiect
            if (Clasa_Intrebari.Limba == 1)
            {
                label1.Text = Class3.Titlu[3];
                label11.Text = Class3.Titlu[4];
                button2.Text = Class3.Titlu[5];
                label4.Text = Class3.Titlu[6];
                label2.Text = Class3.Titlu[7];
                label5.Text = Class3.Titlu[8];
                label17.Text = Class3.Titlu[9];
                label19.Text = Class3.Titlu[10];
                comboBox2.Items.Clear();
                comboBox2.Items.Add(Class3.Titlu[68]);
                comboBox2.Items.Add(Class3.Titlu[69]);
            }
            else if (Clasa_Intrebari.Limba == 0)
            {
                comboBox1.Left = +230;
            }
            //

            //stabilirea textului din comboBox-ul corespunzător selectării modului sonor (cu sonor, respectiv fără)
            if (Clasa_Intrebari.Limba == 0)
            {
                if (Class2.Muzica == 0)
                    comboBox2.Text = "Da";
                else if (Class2.Muzica == 1)
                    comboBox2.Text = "Nu";
            }
            else if(Clasa_Intrebari.Limba == 1)
            {
                if (Class2.Muzica == 0)
                    comboBox2.Text = "Yes";
                else if (Class2.Muzica == 1)
                    comboBox2.Text = "No";
            }
            //
        }

        //trecerea la Form-ul dinainte, cu descrierea companiei
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LookingGlass f3 = new LookingGlass();
            f3.Show();
        }
        //

        //închiderea aplicației
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //

        //trecerea la Form-ul în care se schimbă limba
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SchimbLimba f25 = new SchimbLimba();
            f25.Show();
        }
        //

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aici se stabilește modul sonorului (cu sonor, respectiv fără) pentru pictureBox-ul din Slide-Show
            if (comboBox2.SelectedIndex == 0)
            {
                Class2.Muzica = 0;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                Class2.Muzica = 1;
            }
            //
        }

        //trecerea la Form-ul în care este prezentat jocul selectat de către utilizator
        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13();
            f13.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UltimaUnderworld2_1 f15 = new UltimaUnderworld2_1();
            f15.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form17 f17 = new Form17();
            f17.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            FlightUnlimited f19 = new FlightUnlimited();
            f19.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            TerraNova_1 f20 = new TerraNova_1();
            f20.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            BritishOpenChampGolf f22 = new BritishOpenChampGolf();
            f22.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Hide();
            FlightUnlimited2 f23 = new FlightUnlimited2();
            f23.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f10 = new Form10();
            f10.Show();
        }
        //

        int i = 0;

        //poziționarea titlurilor jocurilor din Slide-Show pentru săgeata din stânga
        private void button4_Click(object sender, EventArgs e)
        {
            i--;
            if (i < 0)
                i = 10;
            pictureBox13.Image = imageList1.Images[i];
            if (i == 0)
            {
                label14.Text = "        Ultima Underworld I        ";
                label18.Text = "(1992)";
            }
            else if (i == 1)
            {
                label14.Text = "        Ultima Underworld II       ";
                label18.Text = "(1993)";
            }
            else if (i == 2)
            {
                label14.Text = "             System Shock             ";
                label18.Text = "(1994)";
            }
            else if (i == 3)
            {
                label14.Text = "            Flight Unlimited             ";
                label18.Text = "(1995)";
            }
            else if (i == 4)
            {
                label14.Text = "   Terra Nova: Strike Force   ";
                label18.Text = "Centauri (1996)";
            }
            else if (i == 5)
            {
                label14.Text = "British Open Championship ";
                label18.Text = "Golf (1997)";
            }
            else if (i == 6)
            {
                label14.Text = "           Flight Unlimited 2          ";
                label18.Text = "(1997)";
            }
            else if (i == 7)
            {
                label14.Text = "     Thief: The Dark Project    ";
                label18.Text = "(1998)";
            }
            else if (i == 8)
            {
                label14.Text = "           System Shock 2            ";
                label18.Text = "(1999)";
            }
            else if (i == 9)
            {
                label14.Text = "         Flight Unlimited 3            ";
                label18.Text = "(1999)";
            }
            else if (i == 10)
            {
                label14.Text = "     Thief II: The Metal Age      ";
                label18.Text = "(2000)";
            }
        }
        //

        //stabilirea logării
        private void button6_Click(object sender, EventArgs e)
        {
            if (Clasa_Conectare.conectat == "")
            {
                this.Hide();
                Login f32 = new Login();
                f32.Show();
            }
            else if(Clasa_Conectare.conectat != "")
            {
                this.Hide();
                Profil f35 = new Profil();
                f35.Show();
            }
        }
        //

        //poziționarea titlurilor jocurilor din Slide-Show pentru săgeata din dreapta
        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            if (i > 10)
                i = 0;
            pictureBox13.Image = imageList1.Images[i];
            if (i == 0)
            {
                label14.Text = "        Ultima Underworld I        ";
                label18.Text = "(1992)";
            }
            else if (i == 1)
            {
                label14.Text = "        Ultima Underworld II       ";
                label18.Text = "(1993)";
            }
            else if (i == 2)
            {
                label14.Text = "             System Shock             ";
                label18.Text = "(1994)";
            }
            else if (i == 3)
            {
                label14.Text = "            Flight Unlimited             ";
                label18.Text = "(1995)";
            }
            else if (i == 4)
            {
                label14.Text = "   Terra Nova: Strike Force   ";
                label18.Text = "Centauri (1996)";
            }
            else if (i == 5)
            {
                label14.Text = "British Open Championship ";
                label18.Text = "Golf (1997)";
            }
            else if (i == 6)
            {
                label14.Text = "           Flight Unlimited 2          ";
                label18.Text = "(1997)";
            }
            else if (i == 7)
            {
                label14.Text = "     Thief: The Dark Project    ";
                label18.Text = "(1998)";
            }
            else if (i == 8)
            {
                label14.Text = "           System Shock 2            ";
                label18.Text = "(1999)";
            }
            else if (i == 9)
            {
                label14.Text = "         Flight Unlimited 3            ";
                label18.Text = "(1999)";
            }
            else if (i == 10)
            {
                label14.Text = "     Thief II: The Metal Age      ";
                label18.Text = "(2000)";
            }
        }
        //

        //informații suplimentare legate de butoane
        ToolTip tip = new ToolTip();
        private void button3_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce înapoi.", button3);
            }
            else if(Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[124], button3);
            }
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            if(Clasa_Conectare.conectat == "")
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    tip.Show("Apasă pentru a te duce la pagina de conectare.", button6);
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    tip.Show(Class3.Titlu[128], button6);
                }
            }
            else if(Clasa_Conectare.conectat != "")
            {
                if (Clasa_Intrebari.Limba == 0)
                {
                    tip.Show("Apasă pentru a te duce la pagina profilului tău.", button6);
                }
                else if (Clasa_Intrebari.Limba == 1)
                {
                    tip.Show(Class3.Titlu[129], button6);
                }
            }
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce la pagina de schimbare a limbii.", button2);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[130], button2);
            }
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            if (Clasa_Intrebari.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce la pagina cu videoclipuri.", button5);
            }
            else if (Clasa_Intrebari.Limba == 1)
            {
                tip.Show(Class3.Titlu[168], button5);
            }
        }
        //

        //trecerea la Form-ul unde sunt videoclipurile
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Video f40 = new Video();
            f40.Show();
        }
        //
    }
}
