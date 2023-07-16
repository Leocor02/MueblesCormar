using MueblesCormar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
    {
        UserViewModel vm;
        public AppLoginPage()
        {
            InitializeComponent();

            this.BindingContext = vm = new UserViewModel();
        }

        private void CmdMostrarContraseña(object sender, ToggledEventArgs e)
        {
            if (SwMostrarContraseña.IsToggled)
            {
                TxtContraseña.IsPassword = false;
            }
            else
            {
                TxtContraseña.IsPassword = true;
            }
        }

        private async void BtnRegistrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserSignUpPage());
        }

        private async void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
           
            bool R = false; 

            if (TxtNombreUsuario != null &&!string.IsNullOrEmpty(TxtNombreUsuario.Text.Trim()) &&
                TxtContraseña != null && !string.IsNullOrEmpty(TxtContraseña.Text.Trim()))
            {
                string usuario = TxtNombreUsuario.Text.Trim();
                string contraseña = TxtContraseña.Text.Trim();

                R = await vm.AccesoValidacionUsuario(usuario, contraseña);
            }
            else
            {
                await DisplayAlert("Validación de error", "El usuario o contraseña son requeridas", "OK");
                return;
            }

            if (R)
            {
                //await DisplayAlert(":)", "Usuario correcto", "OK");

                await Navigation.PushAsync(new AdminHomePage());
                //Mostrar la página de selección de acciones en el sistema
            }
            else
            {
                await DisplayAlert(":(", "Usuario o contraseña incorrecto", "OK");

            }
        }
    }
}