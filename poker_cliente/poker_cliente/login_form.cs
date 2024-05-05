using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poker_cliente
{
    public partial class login_form : Form
    {
        User user = new User();
        Socket server;
        public login_form(Socket server)
        {
            InitializeComponent();
            this.server = server;
            if (server == null)
            {
                MessageBox.Show("No estas conectado al servidor, conectate antes de continuar");
            }
        }
        public User GetUser()
        {
            return this.user;
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            user.Name = user_box.Text;
            user.Password = pass_box.Text;
            user.register = false;
            if (server != null)
            {
                string mensaje = "2/" + user.Name + "/" + user.Password;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("Aun no te has conectado");
            }
        }
        public int Respuesta(String mensaje)
        {
            string[] trozos = mensaje.Split('/');
            mensaje = trozos[0].Split('\0')[0];
            if (trozos[0] == "Se ha iniciado sesion")
            {
                user.Name = trozos[1];
                user.Email = trozos[2];
            }
            MessageBox.Show(mensaje.Split('/')[0]);
            if (trozos[0] == "Se ha iniciado sesion")
                return 0;
            else
                return 1;
        }
    }
}
