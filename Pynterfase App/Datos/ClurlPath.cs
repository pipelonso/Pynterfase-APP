using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pynterfase_App.Datos
{
    class ClurlPath
    {

        public string mtdGetUrlPath()
        {
            //Recordar poner /api al final
            string path = mtdGetSavedPath() + "api/";
            return path;

        }

        public void mtdSetPath(string texto)
        {

            string Ruta = FileSystem.AppDataDirectory;
            string filepath = Path.Combine(Ruta, "serverPath.txt");            
            File.WriteAllText(filepath, texto);  
                                             
        }

        public string mtdGetSavedPath() 
        {

            string Ruta = FileSystem.AppDataDirectory;
            string filepath = Path.Combine(Ruta, "serverPath.txt");
            if (File.Exists(filepath))
            {

                string texto = File.ReadAllText(filepath);
                return texto;

            }

            return "localhost:88/Help";

        }



    }
}
