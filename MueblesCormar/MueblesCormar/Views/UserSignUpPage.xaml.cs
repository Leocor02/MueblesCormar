using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MueblesCormar.ViewModels;
using MueblesCormar.Models;
using System.Xml.Linq;

namespace MueblesCormar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSignUpPage : ContentPage
    {
        UserViewModel viewModel;
        public UserSignUpPage()
        {
            InitializeComponent();

            //se agrega el bindigcontext de la vista contra el viewModel
            BindingContext = viewModel = new UserViewModel();
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private bool ValidacionDatosUsuario()
        {
            bool R = false;

            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                TxtContraseña.Text != null && !string.IsNullOrEmpty(TxtContraseña.Text.Trim()) &&
                TxtTelefono.Text != null && !string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
            {
                R = true;
            }
            else
            {
                //Si alguna validación falla se le indica al usuario lo que hace falta
                if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    DisplayAlert("Validación de error", "El nombre es requerido", "Ok");
                    TxtNombre.Focus();
                    return false;
                }

                if (TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()))
                {
                    DisplayAlert("Validación de error", "El email es requerido", "Ok");
                    TxtEmail.Focus();
                    return false;
                }

                if (TxtContraseña.Text == null || string.IsNullOrEmpty(TxtContraseña.Text.Trim()))
                {
                    DisplayAlert("Validación de error", "La contraseña es requerida", "Ok");
                    TxtContraseña.Focus();
                    return false;
                }

                if (TxtTelefono.Text == null || string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
                {
                    DisplayAlert("Validación de error", "El telefono es requerido", "Ok");
                    TxtTelefono.Focus();
                    return false;
                }
            }

            return R;
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (ValidacionDatosUsuario())
            {

                int rolID = 2;//id rol cliente

                //confirmación de la acción a realizar
                var answer = await DisplayAlert("Confirmación requerida", "Estas seguro de añadir este usuario?", "Si", "No");

                if (answer)
                {
                    bool R = await viewModel.AgregarNuevoUsuario(TxtNombre.Text.Trim(),
                                                                 TxtEmail.Text.Trim(),
                                                                 TxtContraseña.Text.Trim(),
                                                                 TxtTelefono.Text.Trim(),
                                                                 rolID);
                    if (R)
                    {
                        await DisplayAlert("ÉXITO", "Usuario agregado", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("ERROR", "Algo salió mal", "OK");
                    }
                }
            }

           
        }
    }
}