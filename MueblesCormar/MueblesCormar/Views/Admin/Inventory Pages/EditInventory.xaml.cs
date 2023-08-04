using MueblesCormar.Models.DTOs;
using MueblesCormar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.Inventory_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditInventory : ContentPage
    {
        InventoryViewModel viewModel;

        public int idProductoVM { get; set; }
        public EditInventory(int idProducto)
        {
            InitializeComponent();
            BindingContext = viewModel = new InventoryViewModel();
            idProductoVM = idProducto;
            CargarDataProducto(idProducto);
        }

        private async void CargarDataProducto(int idProducto)
        {
            InventarioDTO inventariodto = await viewModel.GetDataProducto(idProducto);
            TxtNombre.Text = inventariodto.Nombre;
            TxtCantidad.Text = Convert.ToString(inventariodto.Cantidad);
            TxtDescripcion.Text = inventariodto.Descripcion;
            TxtImagenProducto.Text = inventariodto.ImagenProducto;
            TxtPrecio.Text = Convert.ToString(inventariodto.PrecioUnidad);
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
               TxtCantidad.Text == null || string.IsNullOrEmpty(TxtCantidad.Text.Trim()) ||
               TxtDescripcion.Text == null || string.IsNullOrEmpty(TxtDescripcion.Text.Trim()) ||
               TxtImagenProducto.Text == null || string.IsNullOrEmpty(TxtImagenProducto.Text.Trim()) || 
               TxtPrecio.Text == null || string.IsNullOrEmpty(TxtPrecio.Text.Trim()))
            {
                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "ok");
                return;
            }

            //confirmación de la acción a realizar
            var answer = await DisplayAlert("Confirmación requerida", "Seguro que quiere editar a este producto?", "Si", "No");

            if (answer)
            {

                bool R = await viewModel.UpdateProducto(
                idProductoVM,
                TxtNombre.Text.Trim(),
                Int32.Parse(TxtCantidad.Text.Trim()),
                TxtDescripcion.Text.Trim(),
                TxtImagenProducto.Text.Trim(),
                Int32.Parse(TxtPrecio.Text.Trim()));

                if (R)
                {
                    await DisplayAlert("Exito!", "Producto modificado correctamente", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Hubo un error al intentar agregar el producto", "OK");
                }
            }
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}