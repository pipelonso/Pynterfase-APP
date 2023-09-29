using Pynterfase_App.Datos;
using Pynterfase_App.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pynterfase_App.Logica
{
    class ClUsuarioL
    {

        public List<Usuario> mtdGetAllUsers()
        {

            ClUsuarioD objUSD = new ClUsuarioD();
            return objUSD.mtdGetAllUsers();

        }

        public Usuario mtdLogin(string email, string password)
        {

            ClUsuarioD objUSD = new ClUsuarioD();
            return objUSD.mtdLogin(email, password);

        }

        public string mtdAddUser(Usuario USE)
        {

            ClUsuarioD objUSD = new ClUsuarioD();
            return objUSD.mtdAddUser(USE);

        }

        public Usuario mtdGetUserByMail(string mail)
        {

            ClUsuarioD objUSD = new ClUsuarioD();
            return objUSD.mtdGetUserByMail(mail);

        }

        public List<Usuario> mtdSearchUserByCriterioAndType(string criterio, int tipo)
        {

            ClUsuarioD objUSD = new ClUsuarioD();
            return objUSD.mtdSearchUserByCriterioAndType(criterio, tipo);

        }

    }
}
