using Clases.ApiRest;
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

namespace Clases
{
    public partial class Form1 : Form
    {
        DBApi dBApi = new DBApi();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            dynamic respuesta = dBApi.Get("https://api.sigfox.com/v2/devices");

            
          
            //txtNombreGET.Text = respuesta.data[1].first_name.ToString();
            txtNombreGET.Text = respuesta.data[0].id.ToString();
            txtEmail.Text = respuesta.data[0].name.ToString();
            txtApellidoGET.Text = respuesta.data[0].state.ToString();
            MessageBox.Show(respuesta.data[0].lqi.ToString());
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona
            {
                job = txtTrabajador.Text,
                name = txtNombresPost.Text
            };

            string json = JsonConvert.SerializeObject(persona);

            dynamic respuesta = dBApi.Post("https://reqres.in/api/users",json);

            MessageBox.Show(respuesta.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class Persona
    {
        public string name { get; set; }
        public string job { get; set; }
    }
}

