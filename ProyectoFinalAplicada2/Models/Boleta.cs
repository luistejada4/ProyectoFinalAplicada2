using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAplicada2.Models
{
    public class Boleta
    {
        public int Id { get; set; }
        public Evento Evento{ get; set; }
        public DateTime Fecha { get; set; }

        public Boleta()
        {

        }
    }
}
