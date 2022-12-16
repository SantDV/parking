using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class ingresosretiros
    {
        private int id;
        private string patente;
        private string horaingreso;
        private string horaretiro;
        private int cliente;

        public int Id { get => id; set => id = value; }
        public string Patente { get => patente; set => patente = value; }
        public string Horaingreso { get => horaingreso; set => horaingreso = value; }
        public string Horaretiro { get => horaretiro; set => horaretiro = value; }
        public int Cliente { get => cliente; set => cliente = value; }
    }
}
