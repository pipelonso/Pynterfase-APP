using Pynterfase_App.Logica;

namespace Pynterfase_App.Paginas;

public partial class PGConection : ContentPage
{
	public PGConection()
	{
		InitializeComponent();
	}

    private void btnConect_Clicked(object sender, EventArgs e)
    {

		if (txtDirection.Text != null) {
            ClConection con = new ClConection();
            con.mtdSetPath(txtDirection.Text);
        }
        else
        {
            DisplayAlert("Campos Faltantes", "Tienes Rellenar el campo de conexion", "Cerrar");

        }
		
    }
}