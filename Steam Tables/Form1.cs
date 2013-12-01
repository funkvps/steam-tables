using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using TablasAgua1967;
using Drag_AND_Drop_between_Forms;


using Tablas_Vapor_ASME1;
using Tablas_Vapor_ASME2;
using Tablas_Vapor_ASME3;
using Tablas_Vapor_ASME4;
using Tablas_Vapor_ASME5;
using Tablas_Vapor_ASMEBorder;
using Tablas_Vapor_ASME;



namespace Steam_Tables
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ASME1967 steamtableasme1967= new ASME1967();
            steamtableasme1967.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Diagrama_Mollier diagrama1 = new Diagrama_Mollier();
            diagrama1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegionSelection steamtables1997 = new RegionSelection();
            steamtables1997.Show();
        }
    }
}
