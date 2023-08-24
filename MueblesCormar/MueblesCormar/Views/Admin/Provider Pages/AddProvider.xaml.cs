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
        BitacoraViewModel bitacoraViewModel;
        public AddProvider()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProviderViewModel();
            bitacoraViewModel = new BitacoraViewModel();
        }


        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
                TxtDireccion.Text == null || string.IsNullOrEmpty(TxtDireccion.Text.Trim()))
            {

                await DisplayAlert("Error", "Todos los espacios son requeridos", "Ok");
                return;
            }

            //confirmación de la acción a realizar
            var answer = await DisplayAlert("Confirmación requerida", "Estas seguro de añadir este proveedor?", "Si", "No");

            if (answer)
            {
                bool R = await viewModel.AddProvedor(TxtNombre.Text.Trim(), TxtDireccion.Text.Trim());
                                                             

                if (R)
                {
                    await DisplayAlert("Éxito", "Proveedor agregado", "OK");
                    R = await bitacoraViewModel.AddBitacora(1, "Proveedor", GlobalObjects.GlobalUser.Idusuario);
                    if (R)
                    {
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Hubo un error al insertar en la bitácora", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Hubo un error al intentar agregar el proveedor", "OK");
                }
            }
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}