using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MueblesCormar.ViewModels;

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
            bool R = await viewModel.AgregarNuevoUsuario(TxtNombre.Text.Trim(),
                                                         TxtEmail.Text.Trim(),
                                                         TxtContraseña.Text.Trim(),
                                                         TxtTelefono.Text.Trim());
            if (R)
            {
                await DisplayAlert(":)", "Todo salió bien", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Algo salió mal", "OK");
            }
        }
    }
}