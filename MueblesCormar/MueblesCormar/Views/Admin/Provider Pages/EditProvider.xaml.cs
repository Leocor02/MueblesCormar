using MueblesCormar.Models.DTOs;
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
    public partial class EditProvider : ContentPage
    {
        ProviderViewModel viewModel;
        BitacoraViewModel bitacoraViewModel;

        public int idProveedorVM { get; set; }
        public EditProvider(int idProveedor)
        {
            InitializeComponent();
            BindingContext = viewModel = new ProviderViewModel();
            bitacoraViewModel = new BitacoraViewModel();
            CargarDataProveedor(idProveedor);
            idProveedorVM = idProveedor;
        }

        private async void CargarDataProveedor(int idProveedor)
        {
            ProveedorDTO proveedordto = await viewModel.GetDataProveedor(idProveedor);
            TxtNombre.Text = proveedordto.Nombre;
            TxtDireccion.Text = proveedordto.Direccion;
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
                TxtDireccion.Text == null || string.IsNullOrEmpty(TxtDireccion.Text.Trim()))
            {
                await DisplayAlert("Error!", "Todos los espacios son requeridos", "ok");
                return;
            }

            var answer = await DisplayAlert("Confirmación requerida", "Está seguro que quiere modificar el proveedor?", "Si", "No");

            if (answer)
            {

                bool R = await viewModel.UpdateProveedor(
                idProveedorVM,
                TxtNombre.Text.Trim(),
                TxtDireccion.Text.Trim());

                if (R)
                {
                    await DisplayAlert("Éxito", "Proveedor modificado correctamente", "Ok");
                    R = await bitacoraViewModel.AddBitacora(2, "Proveedor", GlobalObjects.GlobalUser.Idusuario);
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