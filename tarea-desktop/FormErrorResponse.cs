using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tarea_desktop
{
    public partial class FormErrorResponse : Form
    {
        public string errorMessage { get; set; }
        public FormErrorResponse(string errorMessage)
        {
            InitializeComponent();
            this.errorMessage = errorMessage;

            string showMessage = errorMessage.Substring(48);
            showMessage = showMessage.Substring(0,showMessage.LastIndexOf('.'));

            if (! errorMessage[49].Equals('5'))
                errorLabel.Text = showMessage;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) => this.Close();

        private void FormErrorResponse_Load(object sender, EventArgs e)
        {

        }
    }
}
