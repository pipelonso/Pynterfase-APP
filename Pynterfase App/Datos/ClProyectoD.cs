
using Newtonsoft.Json;
using Pynterfase_App.Entidades;
using RestSharp;
using System;


namespace Pynterfase_App.Datos
{
    class ClProyectoD
    {

        public List<Proyecto> mtdGetAllProjects()
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto";
            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Get(request);
            string respuesta = response.Content;

            List<Proyecto> ListaProyectos = JsonConvert.DeserializeObject<List<Proyecto>>(respuesta);
            return ListaProyectos;
            
        }

        public List<Proyecto> mtdGetProjectByMail(string Email)
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto?email="+Email;
            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Get(request);
            string respuesta = response.Content;

            List<Proyecto> ListaProyectos = JsonConvert.DeserializeObject<List<Proyecto>>(respuesta);
            return ListaProyectos;

        }

        public string mtdAddProject(Proyecto proj)
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto";

            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            request.AddJsonBody(proj);
            var response = client.Post(request);
            string res = response.Content;
            return res;

        } 

        public List<CompartirUserInfo> mtdGetAllusersInProject(string idProyectoUsers)
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto?idProyectoUsers="+idProyectoUsers;

            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            string res = response.Content;

            List<CompartirUserInfo> ListaCompartirUser = JsonConvert.DeserializeObject<List<CompartirUserInfo>>(res);
            return ListaCompartirUser;

        }

        public List<Compartir> mtdGetCompartirInfoByProjectID(string ProjectIdInfo)
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto?ProjectIdInfo=" + ProjectIdInfo;

            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            string res = response.Content;

            List<Compartir> ListaCompartir = JsonConvert.DeserializeObject< List<Compartir>>(res);

            return ListaCompartir;


        }

        public Usuario mtdGetProjectOwner(string idProyecto)
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto?idProyecto=" + idProyecto;

            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            string res = response.Content;

            Usuario objUSE = JsonConvert.DeserializeObject<Usuario>(res);
            return objUSE;

        }

        public int mtdUserExistOnProjectById(string correo, string ProjectID)
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto?correo="+correo+"&ProjectID="+ProjectID;

            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            int res = int.Parse(response.Content);
            return res;
            
        }

        public int mtdAddUserToProject(string idProyectoAddUser, string correoAddUser)
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto?idProyectoAddUser="+idProyectoAddUser+"&correoAddUser="+correoAddUser;

            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            int res = int.Parse(response.Content);
            return res;

        }

        public int mtdUpdateEditableUserByMail(string correoEditable, string editable)
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto?correoEditable="+correoEditable+"&editable="+editable;

            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            int res = int.Parse(response.Content);
            return res;

        }

        public Proyecto GetProjectById(int idSelectedProj)
        {
            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto?idSelectedProj="+idSelectedProj;
            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Get(request);

            Proyecto proj = JsonConvert.DeserializeObject<Proyecto>(response.Content);
            return proj;

        }



        public int mtdDeleteUserOnProjectByMail(string correoDeleteUser, string idProyectoDeleteUser)
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto?correoDeleteUser="+correoDeleteUser+"&idProyectoDeleteUser="+idProyectoDeleteUser;

            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            int res = int.Parse(response.Content);
            return res;


        }

        public int mtdUpdateProjectVisibilityById(string idProjUpdateVisibility, string visibility)
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto?idProjUpdateVisibility="+idProjUpdateVisibility+"&visibility="+visibility;

            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            int res = int.Parse(response.Content);
            return res;


        }

        public int mtdDeleteProjectByid(string id)
        {

            ClurlPath objURl = new ClurlPath();
            string ruta = objURl.mtdGetUrlPath() + "Proyecto/"+id;

            RestClient client = new RestClient(ruta);
            RestRequest request = new RestRequest();
            var response = client.Post(request);
            int res = int.Parse(response.Content);
            return res;

        }



    }
}
