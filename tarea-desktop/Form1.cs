using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tarea_desktop
{
    public partial class Form1 : Form
    {
        public string usuario;
        public string password;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.usuario = usuarioInput.Text;
            this.password = passwordInput.Text;

            if(this.usuario.Length > 0 && this.password.Length > 0)
            {
                //validate API
            }
            else
            {
               Form error = new Form2();
                error.Show();
            }
            
        }
    }
}
