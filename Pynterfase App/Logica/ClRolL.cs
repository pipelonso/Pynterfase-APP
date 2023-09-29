using Pynterfase_App.Datos;
using Pynterfase_App.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pynterfase_App.Logica
{
    class ClRolL
    {

        public List<Rol> mtdGetAllRoles()
        {

            ClRolD objRolD = new ClRolD();
            return objRolD.mtdGetAllRoles();

        }


    }
}
