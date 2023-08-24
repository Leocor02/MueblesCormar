using MueblesCormar.Models.DTOs;
using MueblesCormar.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.ProvInven_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProvInven : ContentPage
    {
        ProvInvenViewModel viewModel;
        BitacoraViewModel bitacoraViewModel;
        public int idProveedorInventarioVM { get; set; }
        public EditProvInven(int idProveedorInventario)
        {
            InitializeComponent();
            BindingContext = viewModel = new ProvInvenViewModel();
            bitacoraViewModel = new BitacoraViewModel();
            CargarDataProveedorInventario(idProveedorInventario);
            idProveedorInventarioVM = idProveedorInventario;
        }

        private async void CargarDataProveedorInventario(int idProveedorInventario)
        {
            ProveedorInventarioDTO proveedorinventariodto = await viewModel.GetDataProveedorInventario(idProveedorInventario);
            TxtIdProveedor.Text = Convert.ToString(proveedorinventariodto.Idproveedor);
            TxtIdProducto.Text = Convert.ToString(proveedorinventariodto.Idproducto);
            TxtNombreProveedor.Text = proveedorinventariodto.NombreProveedor;
            TxtNombreProducto.Text = proveedorinventariodto.NombreProducto;
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            if (TxtIdProveedor.Text == null || string.IsNullOrEmpty(TxtIdProveedor.Text.Trim()) ||
                TxtIdProducto.Text == null || string.IsNullOrEmpty(TxtIdProducto.Text.Trim()) ||
                TxtNombreProveedor.Text == null || string.IsNullOrEmpty(TxtNombreProveedor.Text.Trim()) ||
                TxtNombreProducto.Text == null || string.IsNullOrEmpty(TxtNombreProducto.Text.Trim()))
            {
                await DisplayAlert("Error!", "Todos los espacios son requeridos", "ok");
                return;
            }

            var answer = await DisplayAlert("Confirmación requerida", "Está seguro que quiere modificar el proveedor?", "Si", "No");

            if (answer)
            {

                bool R = await viewModel.UpdateProveedorInventario(
                idProveedorInventarioVM,
                Int32.Parse(TxtIdProveedor.Text.Trim()),
                Int32.Parse(TxtIdProducto.Text.Trim()),
                TxtNombreProveedor.Text.Trim(),
                TxtNombreProducto.Text.Trim()
                );

                if (R)
                {
                    await DisplayAlert("Éxito", "Proveedor modificado correctamente", "Ok");
                    R = await bitacoraViewModel.AddBitacora(2, "Proveedor de inventario", GlobalObjects.GlobalUser.Idusuario);
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
                    await DisplayAlert("ERROR", "Hubo un error al intentar modificar el Proveedor", "Ok");
                }
            }
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}