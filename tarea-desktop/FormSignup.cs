using Newtonsoft.Json;
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
    public partial class FormSignup : Form
    {
        public string usuario;
        public string password;

        public FormSignup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new FormLogin();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void usuarioInput_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            this.usuario = userInput.Text;
            this.password = passwordInput.Text;

            if (this.usuario.Length > 0 && this.password.Length > 0)
            {

                RESTClient httpClient = new RESTClient("http://localhost:8080/signup", httpVerb.POST);

                string response = string.Empty;

                string body = "{\"username\":\"" + usuario + "\"," +
                                "\"password\":\"" + password + "\"}";

                response = httpClient.makeBodyRequest(body);
                Console.WriteLine(response);
                if (httpClient.errorRequest)
                {
                    Form errorResponseForm = new FormErrorResponse(response);
                    errorResponseForm.Show();
                }
                else
                {
                    this.Hide();
                    Usuario user = JsonConvert.DeserializeObject<Usuario>(response);
                    var tasksForm = new FormBuscadorTareas(user);
                    tasksForm.Closed += (s, args) => this.Close();
                    tasksForm.Show();
                }

            }
            else
            {
                Form errorInput = new FormErrorInput();
                errorInput.Show();
            }
        }

        private void FormSignup_Load(object sender, EventArgs e)
        {

        }
    }
}
