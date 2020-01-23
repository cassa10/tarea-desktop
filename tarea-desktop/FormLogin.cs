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
    public partial class FormLogin : Form
    {
        public string usuario;
        public string password;

        public FormLogin()
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
            Cursor.Current = Cursors.WaitCursor;
            this.usuario = usuarioInput.Text;
            this.password = passwordInput.Text;

            if(this.usuario.Length > 0 && this.password.Length > 0)
            {
                //TODO validate account with API
                RESTClient httpClient = new RESTClient("http://localhost:8080/tareas", httpVerb.GET);
                // -----
                string response = string.Empty;

                response = httpClient.makeRequest();
                Console.WriteLine(response);
                if (httpClient.errorRequest)
                {
                    Form errorResponseForm = new FormErrorResponse();
                    errorResponseForm.Show();
                }else
                {
                    this.Hide();
                    var tasksForm = new FormBuscadorTareas();
                    tasksForm.Closed += (s, args) => this.Close();
                    tasksForm.Show();
                }

            }
            else
            {
               Form errorInput = new FormErrorInputLogin();
                errorInput.Show();
            }
            
        }
    }
}
