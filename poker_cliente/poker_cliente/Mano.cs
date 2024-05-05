using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poker_cliente
{
    internal class Mano : Carta //la baraja coje las cartas
    {
        public Carta[] cartas;

        // 1) generar una lista entera con todas las cartas para cada jugador,
        //esas son todas las posibilidades dentro de la base de datos
        // 2) De esa lista generamos la mano del jugador aleatoriamente teniendo en cuenta que algunas se pueden repetir

        //1
        public void inicializar_Cartas(string mensaje)

        //el mensaje es id/palo/numero
        {
            string[] trozos = mensaje.Split('/');
            int l = trozos.Length;
            Carta[] Todas = new Carta[l]; 
            for (int i = 0; i < l; i = i++)
            {
                Todas[i] = new Carta();
                Todas[i].id = Convert.ToInt32(trozos[i]);
                Todas[i].palo = trozos[i + 1];
                Todas[i].numero = Convert.ToInt32(trozos[i + 2]);
            }

        }

        //2

        public void Generar_Mano()
        {

            Random random = new Random();
            HashSet<int> ID = new HashSet<int>();

        }
    }
}
