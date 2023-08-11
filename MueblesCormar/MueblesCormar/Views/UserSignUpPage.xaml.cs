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

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
                TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()) ||
                TxtContraseña.Text == null || string.IsNullOrEmpty(TxtContraseña.Text.Trim()) ||
                TxtTelefono.Text == null || string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
            {
                await DisplayAlert("Error", "Todos los espacios son requeridos", "OK");
                return;
            }

                int rolID = 1;//id rol cliente

                //confirmación de la acción a realizar
                var answer = await DisplayAlert("Confirmación requerida", "Estas seguro de añadir este usuario?", "Si", "No");

                if (answer)
                {
                    bool R = await viewModel.AddUsuario(TxtNombre.Text.Trim(),
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