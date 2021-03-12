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
    public partial class LaMultiAni : Form
    {
        public LaMultiAni()
        {
            InitializeComponent();
        }

        private void Form36_Load(object sender, EventArgs e)
        {
            //scrie mesajul de "La mulți ani!", însoțit de prenumele sărbătoritului
            if (Clasa_Intrebari.Limba == 1)
                label1.Text = Class3.Titlu[83] + ", " + Clasa_Conectare.nume_utilizator;
            else if (Clasa_Intrebari.Limba == 0)
                label1.Text = label1.Text + ", " + Clasa_Conectare.nume_utilizator;
            label1.Text = label1.Text + "!";
            //
        }

        private void Form36_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
