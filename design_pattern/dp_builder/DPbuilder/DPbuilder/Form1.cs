using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPbuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Red);
            PersonThinBuilder ptb = new PersonThinBuilder(e.Graphics, p);
            PersonDirector pdThin = new PersonDirector(ptb);
            pdThin.CreatePerson();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Red);
            PersonFatBuilder pfb = new PersonFatBuilder(e.Graphics, p);
            PersonDirector pdFat = new PersonDirector(pfb);
            pdFat.CreatePerson();
        }
    }
}
