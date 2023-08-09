using MueblesCormar.Models;
using MueblesCormar.Models.DTOs;
using MueblesCormar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.Bitacora_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBitacora : ContentPage
    {
        BitacoraViewModel viewModel;
        public int idBitacoraVM { get; set; }
        public EditBitacora(int idBitacora)
        {
            InitializeComponent();
            BindingContext = viewModel = new BitacoraViewModel();
            CargarDataBitacora(idBitacora);
            idBitacoraVM = idBitacora;
        }

        private async void CargarDataBitacora(int IdBitacora)
        {
            Bitacora bitacora = await viewModel.GetDataBitacora(IdBitacora);
            TxtAccion.Text = bitacora.Accion;
            datePicker.Date = DateTime.Now;
            TxtIdUsuario.Text = Convert.ToString(bitacora.Idusuario);
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            if (TxtAccion.Text == null || string.IsNullOrEmpty(TxtAccion.Text.Trim()) ||
              datePicker.Date.ToString() == null || string.IsNullOrEmpty(datePicker.Date.ToString()) ||
              TxtIdUsuario.Text == null || string.IsNullOrEmpty(TxtIdUsuario.Text.Trim()))
            {
                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "ok");
                return;
            }

            //confirmación de la acción a realizar
            var answer = await DisplayAlert("Confirmación requerida", "Seguro que quiere editar a esta bitácora?", "Si", "No");

            if (answer)
            {

                bool R = await viewModel.UpdateBitacora(
                idBitacoraVM,
                TxtAccion.Text.Trim(),
                DateTime.Parse(datePicker.Date.ToString()),
                Int32.Parse(TxtIdUsuario.Text.Trim()));

                if (R)
                {
                    await DisplayAlert("Exito!", "Bitácora modificada correctamente", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Hubo un error al intentar modificar la bitácora", "OK");
                }
            }
        }
    }
}