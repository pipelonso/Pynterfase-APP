using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pynterfase_App.Entidades
{
    class CompartirUserInfo
    {

        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public string imagenUsuario { get; set; }
        public bool editable { get; set; }

    }
}
