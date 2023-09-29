using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pynterfase_App.Entidades
{
    class Compartir
    {

        public int idCompartir { get; set; }
        public int idOwner { get; set; }
        public int idUsuarioCompartir { get; set; }
        public int idProyecto { get; set; }
        public string editable { get; set; }

    }
}
