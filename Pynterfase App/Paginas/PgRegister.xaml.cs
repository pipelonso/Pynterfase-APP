using Pynterfase_App.Entidades;
using Pynterfase_App.Logica;

namespace Pynterfase_App.Paginas;

public partial class PgRegister : ContentPage
{
	public PgRegister()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void btnRegister_Clicked(object sender, EventArgs e)
    {

        if (txtName.Text != null && txtEmail.Text != null && txtPassOne.Text != null && txtPassTwo.Text != null)
        {

            if (txtPassOne.Text == txtPassTwo.Text)
            {

                Usuario objUSE = new Usuario();
                objUSE.password = txtPassOne.Text;
                objUSE.nombre = txtName.Text;
                objUSE.correo = txtEmail.Text;
                objUSE.idRol = 1;
                objUSE.imagenUsuario = "a";
                ClUsuarioL objUSL = new ClUsuarioL();
                string res = objUSL.mtdAddUser(objUSE);

                if (res == "\"Usuario Registrado\"")
                {

                    DisplayAlert("Correcto", "Registrado con exito, ahora tiene que iniciar sesión", "Cerrar");
                    Navigation.PushAsync(new PgLogin());

                }
                else
                {

                    DisplayAlert("Error", "A ocurrido un error inesperado y no se ha podido registrar al usuario", "Cerrar");

                }


            }
            else
            {

                DisplayAlert("Error", "Las contraseñas no coinciden", "Cerrar");

            }

        }
        else
        {

            DisplayAlert("Campos Vacios", "Hay algunos campos vacios, completalos todos para continuar", "Cerrar");

        }


    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Paginas.PgLogin());
    }
}