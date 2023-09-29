
using Pynterfase_App.Datos;
using Pynterfase_App.Entidades;
using System;
using System.Collections.Generic;

namespace Pynterfase_App.Logica
{
    class ClProyectoL
    {

        public List<Proyecto> mtdGetAllProjects()
        {

            ClProyectoD objPROJD = new ClProyectoD();
            return objPROJD.mtdGetAllProjects();

        }

        public List<Proyecto> mtdGetProjectByMail(string Email)
        {

            ClProyectoD objPROJ = new ClProyectoD();
            return objPROJ.mtdGetProjectByMail(Email);

        }

        public Proyecto GetProjectById(int idSelectedProj)
        {

            ClProyectoD objPROJD = new ClProyectoD();
            return objPROJD.GetProjectById(idSelectedProj);

        }

        public string mtdAddProject(Proyecto proj)
        {

            ClProyectoD objPROJ = new ClProyectoD();
            return objPROJ.mtdAddProject(proj);

        }

        public List<CompartirUserInfo> mtdGetAllusersInProject(string idProyectoUsers)
        {

            ClProyectoD objPROJ = new ClProyectoD();
            return objPROJ.mtdGetAllusersInProject(idProyectoUsers);

        }

        public List<Compartir> mtdGetCompartirInfoByProjectID(string ProjectIdInfo)
        {

            ClProyectoD objProjD = new ClProyectoD();
            return objProjD.mtdGetCompartirInfoByProjectID(ProjectIdInfo);

        }

        public Usuario mtdGetProjectOwner(string idProyecto)
        {

            ClProyectoD objPROJD = new ClProyectoD();
            return objPROJD.mtdGetProjectOwner(idProyecto);

        }

        public int mtdUserExistOnProjectById(string correo, string ProjectID)
        {

            ClProyectoD objPROJD = new ClProyectoD();
            return objPROJD.mtdUserExistOnProjectById(correo, ProjectID);

        }

        public int mtdAddUserToProject(string idProyectoAddUser, string correoAddUser)
        {

            ClProyectoD objPROJD = new ClProyectoD();
            return objPROJD.mtdAddUserToProject(idProyectoAddUser, correoAddUser);

        }

        public int mtdUpdateEditableUserByMail(string correoEditable, string editable)
        {

            ClProyectoD objPROJD = new ClProyectoD();
            return objPROJD.mtdUpdateEditableUserByMail(correoEditable, editable);

        }

        public int mtdDeleteUserOnProjectByMail(string correoDeleteUser, string idProyectoDeleteUser)
        {

            ClProyectoD objPROJD = new ClProyectoD();
            return objPROJD.mtdDeleteUserOnProjectByMail(correoDeleteUser, idProyectoDeleteUser);

        }

        public int mtdUpdateProjectVisibilityById(string idProjUpdateVisibility, string visibility)
        {

            ClProyectoD objPROJD = new ClProyectoD();
            return objPROJD.mtdUpdateProjectVisibilityById(idProjUpdateVisibility, visibility);

        }

        public int mtdDeleteProjectByid(string id)
        {

            ClProyectoD objPROJD = new ClProyectoD();
            return objPROJD.mtdDeleteProjectByid(id);

        }

    }
}
