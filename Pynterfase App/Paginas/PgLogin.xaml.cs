using Newtonsoft.Json;
using Pynterfase_App.Entidades;
using Pynterfase_App.Logica;
using RestSharp;

namespace Pynterfase_App.Paginas;

public partial class PgLogin : ContentPage
{
	public PgLogin()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {

        if (txtMail.Text != null && txtPassword.Text != null)
        {

            ClUsuarioL objUSL = new ClUsuarioL();
            Usuario USE = objUSL.mtdLogin(txtMail.Text, txtPassword.Text);

            if (USE == null)
            {

                DisplayAlert("ERROR", "Usuario o contraseņa Incorrecta", "Reintentar");

            }
            else
            {
                GlobalApp.UserId = USE.idUsuario;
                GlobalApp.Correo = USE.correo;
                Navigation.PushAsync(new Paginas.Proyectos());

            }

        }

        
        



    }
}