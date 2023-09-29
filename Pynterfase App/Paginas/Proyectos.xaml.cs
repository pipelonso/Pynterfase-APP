using Newtonsoft.Json;
using Pynterfase_App.Entidades;
using Pynterfase_App.Logica;
using RestSharp;

namespace Pynterfase_App.Paginas;

public partial class Proyectos : ContentPage
{
	public Proyectos()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        ClProyectoL objPROL = new ClProyectoL();

        List<Proyecto> ListaProyectos = objPROL.mtdGetProjectByMail(GlobalApp.Correo);
       
        for (int i = 0; i < ListaProyectos.Count; i++)
        {

            Grid genGrid = new Grid();
            VerticalStackLayout VSTACK = new VerticalStackLayout();
            HorizontalStackLayout HSTACK = new HorizontalStackLayout();
            HSTACK.Spacing = 10;
            Frame frState  = new Frame();
            frState.HeightRequest = 60;
            frState.WidthRequest = 60;
            if (ListaProyectos[i].visibilidad == "Publico")
            {
                frState.BackgroundColor = Colors.GreenYellow;
            }
            else
            {
                frState.BackgroundColor= Colors.Red;
            }

            HSTACK.Add(frState);

            Frame frBox = new Frame();
            frBox.Content = genGrid;
            frBox.BackgroundColor = Color.FromArgb("#BF1D0732");
            frBox.Padding = 5;
            
            Label lblName = new Label();
            lblName.Text = ListaProyectos[i].nombreProyecto;
            lblName.TextColor = Colors.White;
            lblName.VerticalOptions = LayoutOptions.Center;
            HSTACK.Add(lblName);

            Grid gridBTNGO = new Grid();
            Image imgGO = new Image();
            imgGO.Source = "go_next.png";
            imgGO.HeightRequest = 60;
            gridBTNGO.Add(imgGO);

            //gridBTNGO.TranslationX = 100;

            Button btnGo = new Button();
            btnGo.StyleId = ListaProyectos[i].idProyecto.ToString(); ;
            btnGo.BackgroundColor = Colors.Transparent;
            btnGo.Clicked += btnGo_Clicked; 


            gridBTNGO.Add(btnGo);
            gridBTNGO.HorizontalOptions = LayoutOptions.End;
            genGrid.Children.Add(gridBTNGO);    
            //HSTACK.Add(gridBTNGO);
            genGrid.Add(HSTACK);
            VSTACK.Add(frBox);
            Contenido.Add(VSTACK);

        }



    }


    private void btnGo_Clicked(object sender, EventArgs e) {

        Button btn = (Button)sender;
        int idProj = int.Parse(btn.StyleId.ToString());
        GlobalApp.CurrenIdProject = idProj;
        Navigation.PushAsync(new Paginas.PgInfoProject());


    
    
    
    }


}