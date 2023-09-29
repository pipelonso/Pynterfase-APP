using Microsoft.Maui.Controls.Shapes;

using Pynterfase_App.Entidades;
using Pynterfase_App.Logica;
using System.Data;

namespace Pynterfase_App.Paginas;

public partial class PgInfoProject : ContentPage
{
	public PgInfoProject()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

		ClProyectoL objPROJL = new ClProyectoL();
		Proyecto proj = objPROJL.GetProjectById(GlobalApp.CurrenIdProject);

		lblProjName.Text = proj.nombreProyecto;

		if (proj.visibilidad == "Publico")
		{
            bg_Vertical.BackgroundColor = Color.FromRgba("#7F44CD2A");
			swPrivacy.IsToggled = true;
			swPrivacy.BackgroundColor = Color.FromRgba("#36CD2A");
			frPrivacy.BackgroundColor = Color.FromRgba("#36CD2A");
        }
		else
		{
            bg_Vertical.BackgroundColor = Color.FromRgba("#7FCD2A30");
            swPrivacy.IsToggled = false;
            swPrivacy.BackgroundColor = Color.FromRgba("#CD242E");
			frPrivacy.BackgroundColor = Color.FromRgba("#CD242E");
            //#231213
        }

        lblVisibilidad.Text = proj.visibilidad;

        mtdDrawUI();
        

    }

    private void swPrivacy_Toggled(object sender, ToggledEventArgs e)
    {

		if (swPrivacy.IsToggled == true)
		{
                      
            ClProyectoL objPROJL = new ClProyectoL();
            int res = objPROJL.mtdUpdateProjectVisibilityById(GlobalApp.CurrenIdProject.ToString(), "Publico");
            if (res >= 1) 
            {

                lblVisibilidad.Text = "Publico";
                bg_Vertical.BackgroundColor = Color.FromRgba("#121911");
                swPrivacy.BackgroundColor = Color.FromRgba("#36CD2A");
                frPrivacy.BackgroundColor = Color.FromRgba("#36CD2A");

            }

        }
		else{

            ClProyectoL objPROJL = new ClProyectoL();
            int res = objPROJL.mtdUpdateProjectVisibilityById(GlobalApp.CurrenIdProject.ToString(), "Publico");
            if (res >= 1) {

                bg_Vertical.BackgroundColor = Color.FromRgba("#231213");
                swPrivacy.BackgroundColor = Color.FromRgba("#CD242E");
                frPrivacy.BackgroundColor = Color.FromRgba("#CD242E");
                lblVisibilidad.Text = "Privado";

            }
            

        }


    }

    private void swPrivacy_User_Toggled (object sender, ToggledEventArgs e)
    {

        Switch sw = (Switch)sender;
        string userMail = sw.StyleId;
        
        ClProyectoL objProjL = new ClProyectoL();
        int res = objProjL.mtdUpdateEditableUserByMail(userMail, sw.IsToggled.ToString());

        if (res >= 1)
        {

            mtdDrawUI();

        }
        else
        {

            DisplayAlert("Error", "No se ha podido actualizar el acceso" , "Cerrar");

        }


    }

    public void mtdDrawUI()
    {
        Contenido.Clear();
        ClProyectoL objPROJL = new ClProyectoL();
        List<CompartirUserInfo> listaUsuarios = objPROJL.mtdGetAllusersInProject(GlobalApp.CurrenIdProject.ToString());
        for (int i = 0; i < listaUsuarios.Count; i++)
        {

            VerticalStackLayout VSTACK = new VerticalStackLayout();
            VSTACK.Spacing = 10;


            Frame frGen = new Frame();
            if (listaUsuarios[i].editable == false)
            {
                frGen.BackgroundColor = Color.FromRgba("#7F36CD2A");
            }
            else
            {                
                frGen.BackgroundColor = Color.FromRgba("#7FCD2A30");
            }


            Grid grGen = new Grid();
            VerticalStackLayout VSNombreCorreo = new VerticalStackLayout();
            Label lblUserName = new Label();
            lblUserName.Text = listaUsuarios[i].nombre;
            lblUserName.TextColor = Colors.White;
            VSNombreCorreo.Add(lblUserName);
            Line lineVSNC = new Line();
            lineVSNC.BackgroundColor = Colors.White;
            Label lblUserMail = new Label();
            lblUserMail.Text = listaUsuarios[i].correo;
            lblUserMail.TextColor = Colors.White;
            VSNombreCorreo.Add(lineVSNC);
            VSNombreCorreo.Add(lblUserMail);
            VSNombreCorreo.HorizontalOptions = LayoutOptions.Start;

            HorizontalStackLayout HStackOptions = new HorizontalStackLayout();

            //----------- GRID BOTON DE ELIMINAR
            Grid grDelete = new Grid();

            Image imgDeleteB = new Image();
            imgDeleteB.Source = "trash.png";
            imgDeleteB.WidthRequest = 50;
            imgDeleteB.HeightRequest = 50;

            grDelete.Children.Add(imgDeleteB);

            Button btnDelete = new Button();
            btnDelete.Background = Colors.Transparent;
            btnDelete.StyleId = listaUsuarios[i].correo;
            btnDelete.BorderColor = Colors.Transparent;
            btnDelete.Clicked += btnDelete_Clicked;
            grDelete.Children.Add(btnDelete);
            grDelete.HorizontalOptions = LayoutOptions.End;

            //-------FIN GRID ELIMINAR

            //-------AGREGAR SWITCH

            Frame frEditable = new Frame();
            frEditable.Background = Colors.White;
            Grid grCanEdit = new Grid();
            Label lblTituloEditable = new Label();
            lblTituloEditable.Text = "Puede editar";
            lblTituloEditable.TextColor = Colors.White;
            lblTituloEditable.HorizontalTextAlignment = TextAlignment.Start;
            lblTituloEditable.HorizontalOptions = LayoutOptions.Start;
            lblTituloEditable.VerticalOptions = LayoutOptions.Center;
            lblTituloEditable.VerticalTextAlignment = TextAlignment.Center;
            grCanEdit.Children.Add(lblTituloEditable);

            Switch swCanEdit = new Switch();
            swCanEdit.HorizontalOptions = LayoutOptions.End;
            swCanEdit.IsToggled = listaUsuarios[i].editable;
            swCanEdit.StyleId = listaUsuarios[i].correo;
            swCanEdit.Toggled += swPrivacy_User_Toggled;
            grCanEdit.Children.Add(swCanEdit);


            //-------AGREGAR ELEMENTOS 


            Grid Grinfo = new Grid();
            Grinfo.Children.Add(VSNombreCorreo);
            Grinfo.Children.Add(grDelete);

            VSTACK.Add(Grinfo);

            Line lineaLoca = new Line();
            lineaLoca.BackgroundColor = Colors.White;
            VSTACK.Add(lineaLoca);
            VSTACK.Add(grCanEdit);
            //Agregar switch

            grGen.Children.Add(VSTACK);

            //grGen.Children.Add(VSNombreCorreo);
            //grGen.Children.Add(grDelete);



            frGen.Content = grGen;
            Contenido.Add(frGen);

        }

    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {

        Button btnDelete = (Button)sender;
        string correo = btnDelete.StyleId;

        ClProyectoL objPROJL = new ClProyectoL();
        int res = objPROJL.mtdDeleteUserOnProjectByMail(correo, GlobalApp.CurrenIdProject.ToString()); ;

        if (res >= 1)
        {

            mtdDrawUI();

        }
        else
        {

            DisplayAlert("Error", "No se puedo eliminar el usuario del proyecto", "Cerrar");

        }

    }

    

    

    private void btnSearchUser_Clicked(object sender, EventArgs e)
    {
        ClUsuarioL objUSL = new ClUsuarioL();

        if (txtSearchUser.Text != null)
        {

            List<Usuario> ListaUsuarios = new List<Usuario>();

            if (swSearcByName.IsToggled == true)
            {

                ListaUsuarios = objUSL.mtdSearchUserByCriterioAndType(txtSearchUser.Text, 1);

            }
            else
            {

                ListaUsuarios = objUSL.mtdSearchUserByCriterioAndType(txtSearchUser.Text, 2);

            }

            //Hacer generación de interfaz

            SearchContenido.Clear();

            for (int i = 0; i < ListaUsuarios.Count; i++)
            {

                Frame frBox = new Frame();
                frBox.BackgroundColor = Colors.Black;
                VerticalStackLayout VSTACK = new VerticalStackLayout();
                VSTACK.Spacing = 10;
                Label lblNombre  = new Label();
                lblNombre.Text = ListaUsuarios[i].nombre;
                lblNombre.TextColor = Colors.White;

                VSTACK.Add(lblNombre);  

                Line Linea = new Line();
                Linea.BackgroundColor = Colors.White;
                VSTACK.Add(Linea);

                Label lblCorreo = new Label();
                lblCorreo.Text = ListaUsuarios[i].correo;
                lblCorreo.TextColor = Colors.White;
                VSTACK.Add(lblCorreo);

                Button btnAdd = new Button();
                btnAdd.BackgroundColor = Colors.White;
                btnAdd.TextColor = Colors.Black;
                btnAdd.StyleId = ListaUsuarios[i].correo;
                btnAdd.Clicked += btnAddUser_Clicked;
                btnAdd.Text = "Agregar usuario al proyecto";
                VSTACK.Add(btnAdd);

                frBox.Content = VSTACK;

                SearchContenido.Add(frBox);

            }


        }

        

        
    }

    private void btnAddUser_Clicked(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        string userMail = btn.StyleId;

        ClProyectoL objPROJL = new ClProyectoL();
        int res = objPROJL.mtdAddUserToProject(GlobalApp.CurrenIdProject.ToString(), userMail);

        if (res >= 1)
        {

            PAddUser.IsVisible = false;
            mtdDrawUI();
            SearchContenido.Clear();

        }
        else
        {

            DisplayAlert("Error", "El usuario ya existe en el proyecto o no se ha podido arreglar", "Cerrar");

        }


    }

    private void btnCloseAddUser_Clicked(object sender, EventArgs e)
    {

        PAddUser.IsVisible = false;        
        SearchContenido.Clear();

    }
}