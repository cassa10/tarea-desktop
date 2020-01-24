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
using System.Collections;

namespace tarea_desktop
{
    public partial class FormBuscadorTareas : Form
    {
        public List<Tarea> tareas;
        public Usuario user;
        
        public FormBuscadorTareas(Usuario user)
        {
            InitializeComponent();
            this.searchTareas();
            this.user = user;
            usernameLabel.Text = user.username;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void priorityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (searchText.Text.Length > 0)
                tableTarea.DataSource = tareas.Where(t => t.nombre.ToLower().Contains(searchText.Text.ToLower()) && this.comparePriority(t)).ToList();
            else
                tableTarea.DataSource = tareas.Where(t => this.comparePriority(t)).ToList();

        }

        private bool comparePriority(Tarea tarea)
        {
            if (! allPriority())
                return tarea.prioridad.ToString().Equals(priorityBox.SelectedItem);
            else
                return true;
        }

        private bool allPriority()
        {
            return priorityBox.Text.Equals("Prioridad") || priorityBox.Text.Equals("Todas");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.searchTareas();
        }

        private void searchTareas()
        {
            Cursor.Current = Cursors.WaitCursor;
            RESTClient httpClient = new RESTClient("http://localhost:8080/tareas", httpVerb.GET);
            string response = httpClient.makeRequest();
            if (httpClient.errorRequest)
            {
                new FormErrorResponse(httpClient.errorMessage).Show();
            }
            else
            {
                Cursor.Current = Cursors.Default;
                tareas = JsonConvert.DeserializeObject<List<Tarea>>(response);

                tableTarea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                tableTarea.DataSource = tareas;
                searchText.Text = "";
                priorityBox.Text = "Prioridad";

            }
        }

        private void tableTarea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tarea pe = (Tarea)tableTarea.CurrentRow.DataBoundItem;


        }

        private void tableTarea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var tasksForm = new FormLogin();
            tasksForm.Closed += (s, args) => this.Close();
            tasksForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
