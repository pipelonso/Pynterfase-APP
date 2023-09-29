using Newtonsoft.Json;
using Pynterfase_App.Entidades;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pynterfase_App.Datos
{
    class ClRolD
    {

        public List<Rol> mtdGetAllRoles()
        {

            ClurlPath objURL = new ClurlPath();
            string ruta = objURL.mtdGetUrlPath() + "Rol";
            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Get(request);
            string respuesta = response.Content;

            List<Rol> ListaRoles = JsonConvert.DeserializeObject<List<Rol>>(respuesta);

            return ListaRoles;


        }





    }
}
