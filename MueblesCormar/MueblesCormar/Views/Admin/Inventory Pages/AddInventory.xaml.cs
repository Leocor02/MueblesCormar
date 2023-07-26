using MueblesCormar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.Inventory_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddInventory : ContentPage
    {
        InventoryViewModel viewModel;
        public AddInventory()
        {
            BindingContext = viewModel = new InventoryViewModel();
            InitializeComponent();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            //confirmación de la acción a realizar
            var answer = await DisplayAlert("Confirmación requerida", "Estas seguro?", "Si", "No");

            if (answer)
            {
                bool R = await viewModel.AgregarNuevoProducto(TxtNombre.Text.Trim(),
                                                              Int32.Parse(TxtCantidad.Text.Trim()),
                                                              TxtDescripcion.Text.Trim(),
                                                              TxtProductoImagen.Text.Trim(),
                                                              Int32.Parse(TxtPrecio.Text.Trim()));

                if (R)
                {
                    await DisplayAlert("ÉXITO", "Producto agregado", "OK");
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