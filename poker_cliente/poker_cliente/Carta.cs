using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poker_cliente
{
    internal class Carta
    {
        //las cartas cogerán valores desde la base de datos
        public int id { get; set; }
        public string palo { get; set; }
        public int numero { get; set; }
    }
}
