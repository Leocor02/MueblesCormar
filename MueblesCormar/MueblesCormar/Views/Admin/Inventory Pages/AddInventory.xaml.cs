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
        BitacoraViewModel bitacoraViewModel;
        public AddInventory()
        {
            BindingContext = viewModel = new InventoryViewModel();
            bitacoraViewModel = new BitacoraViewModel();
            InitializeComponent();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
               TxtCantidad.Text == null || string.IsNullOrEmpty(TxtCantidad.Text.Trim()) ||
               TxtDescripcion.Text == null || string.IsNullOrEmpty(TxtDescripcion.Text.Trim()) ||
               TxtProductoImagen.Text == null || string.IsNullOrEmpty(TxtProductoImagen.Text.Trim()) ||
               TxtPrecio.Text == null || string.IsNullOrEmpty(TxtPrecio.Text.Trim()))
            {
                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "ok");
                return;
            }
            //confirmación de la acción a realizar
            var answer = await DisplayAlert("Confirmación requerida", "Estas seguro?", "Si", "No");

            if (answer)
            {
                bool R = await viewModel.AddProducto(TxtNombre.Text.Trim(),
                                                     Int32.Parse(TxtCantidad.Text.Trim()),
                                                     TxtDescripcion.Text.Trim(),
                                                     TxtProductoImagen.Text.Trim(),
                                                     Int32.Parse(TxtPrecio.Text.Trim()));

                if (R)
                {
                    await DisplayAlert("ÉXITO", "Producto agregado", "OK");
                    R = await bitacoraViewModel.AddBitacora(1, "Inventario", GlobalObjects.GlobalUser.Idusuario);
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