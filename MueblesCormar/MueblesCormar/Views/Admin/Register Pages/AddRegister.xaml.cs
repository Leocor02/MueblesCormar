using MueblesCormar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.Register_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRegister : ContentPage
    {
        RegisterViewModel viewModel;
        public AddRegister()
        {
            InitializeComponent();
            BindingContext = viewModel = new RegisterViewModel();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (datePicker.Date.ToString() == null || string.IsNullOrEmpty(datePicker.Date.ToString()) ||
                TxtNota.Text == null || string.IsNullOrEmpty(TxtNota.Text.Trim()) ||
                TxtIdUsuario == null || string.IsNullOrEmpty(TxtIdUsuario.Text.Trim()))
            {

                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "Ok");
                return;
            }

            //confirmación de la acción a realizar
            var answer = await DisplayAlert("Confirmación requerida", "Estas seguro?", "Si", "No");

            if (answer)
            {
                bool R = await viewModel.AddRegistro(datePicker.Date, 
                                                     TxtNota.Text.Trim(), 
                                                     Int32.Parse(TxtIdUsuario.Text.Trim()));
                if (R)
                {
                    await DisplayAlert("ÉXITO", "Registro agregado", "OK");
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