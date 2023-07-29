using MueblesCormar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.Porvider_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProvider : ContentPage
    {
        ProviderViewModel viewModel;
        public AddProvider()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProviderViewModel();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
                TxtDireccion.Text == null || string.IsNullOrEmpty(TxtDireccion.Text.Trim()))
            {

                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "Ok");
                return;
            }

            //confirmación de la acción a realizar
            var answer = await DisplayAlert("Confirmación requerida", "Estas seguro?", "Si", "No");

            if (answer)
            {
                bool R = await viewModel.AgregarNuevoProveedor(TxtNombre.Text.Trim(), TxtDireccion.Text.Trim());
                                                             

                if (R)
                {
                    await DisplayAlert("ÉXITO", "Proveedor agregado", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("ERROR", "Algo salió mal", "OK");
                }
            }
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}