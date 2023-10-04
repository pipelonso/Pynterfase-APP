using Pynterfase_App.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pynterfase_App.Logica
{
    internal class ClConection
    {

        public void mtdSetPath(string texto)
        {

            ClurlPath objURL = new ClurlPath();
            objURL.mtdSetPath(texto);

        }

        public string mtdGetSavedPath()
        {

            ClurlPath objURL = new ClurlPath();
            return objURL.mtdGetSavedPath();

        }




    }
}
