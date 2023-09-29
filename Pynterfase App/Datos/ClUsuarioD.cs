using Microsoft.Maui.ApplicationModel.Communication;
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
    class ClUsuarioD
    {

        public List<Usuario> mtdGetAllUsers()
        {

            ClurlPath urlPath = new ClurlPath();
            string ruta = urlPath.mtdGetUrlPath() + "Usuario";
            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Get(request);
            string respuesta = response.Content;

            List<Usuario> ListaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(respuesta);

            return ListaUsuarios;

        }

        public Usuario mtdLogin(string email , string password)
        {

            ClurlPath urlPath = new ClurlPath();
            string ruta = urlPath.mtdGetUrlPath() + "Usuario?correo="+email+"&pass="+password;
            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            string respuesta = response.Content;

            Usuario USE = JsonConvert.DeserializeObject<Usuario>(respuesta);
            return USE;

        }

        public string mtdAddUser(Usuario USE)
        {

            ClurlPath urlPath = new ClurlPath();
            string ruta = urlPath.mtdGetUrlPath() + "Usuario";
            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();            

            request.AddJsonBody(USE);
            var response = client.Post(request);
            string respuesta = response.Content;

            return respuesta;

        }

        public Usuario mtdGetUserByMail(string mail)
        {

            ClurlPath urlPath = new ClurlPath();
            string ruta = urlPath.mtdGetUrlPath() + "Usuario?mail="+mail;
            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            string respuesta = response.Content;

            Usuario USE = JsonConvert.DeserializeObject<Usuario>(respuesta);
            return USE;

        }

        public List<Usuario> mtdSearchUserByCriterioAndType(string criterio, int tipo)
        {

            ClurlPath urlPath = new ClurlPath();
            string ruta = urlPath.mtdGetUrlPath() + "Usuario?criterio="+criterio+"&tipo="+tipo;
            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            string respuesta = response.Content;

            List<Usuario> ListaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(respuesta);

            return ListaUsuarios;

        }



    }
}
