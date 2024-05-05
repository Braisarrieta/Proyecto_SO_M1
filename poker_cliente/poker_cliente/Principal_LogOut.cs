using poker_cliente.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace poker_cliente
{
    public partial class Principal_LogOut : Form
    {
        Socket server;
        User user = new User();
        Thread atender; Thread ThreadLogged; Thread ThreadJuego;
        Principal_Logged logged_form;
        login_form lform;
        register_form rform;
        Interfaz_juego juego;
        int Entry = 1;

        public Principal_LogOut()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Principal_Logged_Load(object sender, EventArgs e)
        {

        }

        public void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[512];
                server.Receive(msg2);

                string[] trozos = Encoding.ASCII.GetString(msg2).Split(new[] {'/'}, 2);
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1];

                switch (codigo)
                {
                    case 1:
                        rform.Respuesta(mensaje);
                        break;
                    case 2:
                        int res = lform.Respuesta(mensaje);
                        if (res == 0)
                        {
                            logged_form = new Principal_Logged(lform.GetUser(), server);
                            lform.Close();

                            ThreadStart ts = delegate { logged_form.ShowDialog();};
                            ThreadLogged = new Thread(ts);
                            ThreadLogged.Start();
                        }
                        break;
                    case 3:
                        logged_form.Tabla(mensaje);
                        break;
                    case 4:
                        logged_form.ResponderInvitacion(mensaje);
                        break;
                    case 5:
                        logged_form.MostrarRespuesta(mensaje);
                        break;
                    case 6:
                        string[] trozosMsg = mensaje.Split('/');
                        int id_partida = Convert.ToInt32(trozosMsg[0]);

                        juego = new Interfaz_juego(user, server, id_partida);
                        ThreadStart tsJuego = delegate { juego.ShowDialog(); };
                        ThreadJuego = new Thread(tsJuego);
                        ThreadJuego.Start();

                        break;
                    case 7:
                        juego.RecibirChat(mensaje);
                        break;

                    case 8:
                        juego.RecibirMano(mensaje);
                        break;
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IP_Box.Text == "")
            {
                MessageBox.Show("Selecciona un servidor, por favor.");
            }
            if (this.BackColor != Color.Green && IP_Box.Text != "")
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos



                IPAddress direc = IPAddress.Parse(IP_Box.Text);
                IPEndPoint ipep = new IPEndPoint(direc, 50060);


                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.Green;
                    MessageBox.Show("Conectado");
                    ConsolaControl.AppendText(String.Format("Entry {0}: Conectado a {1}. ", Entry, IP_Box.Text) + Environment.NewLine);
                    Entry++;
                    IP_Box.Enabled = false;
                    ConexionStripMenuItem1.Visible = true;
                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    // Mucahs gracias a Asier Lopez^2 por ayudarnos con la consola de control
                    ConsolaControl.AppendText(String.Format("Entry {0}: No he podido conectar con el servidor {1}. ", Entry, IP_Box.Text) + Environment.NewLine);
                    Entry++;
                    server = null;
                    return;
                }

                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
            }
            else if (IP_Box.Text != "" && this.BackColor == Color.Green)
                MessageBox.Show("Ya estas conectado");
        }

        private void IP_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void consolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (consolaToolStripMenuItem.Checked == false)
                ConsolaControl.Visible = false;
            else if (consolaToolStripMenuItem.Checked == true)
                ConsolaControl.Visible = true;
        }

        private void inicioDeSesión_Click(object sender, EventArgs e)
        {
            lform = new login_form(server);
            lform.ShowDialog();
        }

        private void resgistro_Click(object sender, EventArgs e)
        {
            this.rform = new register_form(user, server);
            rform.ShowDialog();
        }

        private void Desconectar_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Green)
            {
                // Se terminó el servicio. 
                // Nos desconectamos
                string mensaje = "0/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                atender.Abort();
                ConsolaControl.AppendText(String.Format("Entry {0}: Se ha cerrado la conexion con {1}. ", Entry, IP_Box.Text) + Environment.NewLine);
                Entry++;
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                IP_Box.Enabled = true;
                ConexionStripMenuItem1.Visible = false;
            }
            else
                MessageBox.Show("No estas conectado a ningun servidor.");
        }

        private void IP_Box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
