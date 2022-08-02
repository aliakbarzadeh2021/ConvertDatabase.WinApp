using ConvertDatabase.WinApp.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConvertDatabase.WinApp.Forms
{
    public partial class Start : Form
    {
        IConvertEngine Engine { get; set; }

        public Start(IConvertEngine engine)
        {
            Engine = engine;
            InitializeComponent();
        }

        public Start()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Engine.Start();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Analyse form = new Analyse(Engine);
            form.Show();
            this.Hide();
        }
    }
}
