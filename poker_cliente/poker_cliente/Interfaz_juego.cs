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
    public partial class Interfaz_juego : Form
    {
        User user;
        Socket server;
        int ID_partida;
        public Panel[] ManoCartas = new Panel[5];
        public Interfaz_juego(User user, Socket server, int ID_partida)
        {
            InitializeComponent();
            this.user = user;
            this.server = server;
            this.ID_partida = ID_partida;
        }
        internal void RecibirChat(string mensaje)
        {
            string[] trozos = mensaje.Split('/');
            if (Convert.ToInt32(trozos[0]) == ID_partida)
            {
                ChatOutput.AppendText(String.Format("-> {0}: {1}", trozos[1], trozos[2]) + Environment.NewLine);
            }
        }
        private void ChatEnviar_Click(object sender, EventArgs e)
        {
            string mensaje = "6/" + this.ID_partida + "/" + this.user.Name + "/" + ChatInput.Text;
            if (ChatInput.Text != "")
            {
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            ChatInput.Text = "";
        }

        private void Interfaz_juego_Load(object sender, EventArgs e)
        {
            string mensaje = "7/" + this.ID_partida + "/" + this.user.Name;
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        internal void RecibirMano(string mensaje)
        {
            ManoCartas[0] = Mano1;
            ManoCartas[1] = Mano2;
            ManoCartas[2] = Mano3;
            ManoCartas[3] = Mano4;
            ManoCartas[4] = Mano5;

            string[] trozos = mensaje.Split('/');
            Carta[] mano = new Carta[Convert.ToInt32(trozos[0])];
            for (int i = 1; i < Convert.ToInt32(trozos[0]); i++)
            {
                mano[i - 1].id = Convert.ToInt32(trozos[i]);
                string resourceName = $"poker.Properties.Resources." + mano[i - 1].numero + "_" + Convert.ToInt32(mano[i - 2].palo) + ".png";
                ManoCartas[i - 1].BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(resourceName);

            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
