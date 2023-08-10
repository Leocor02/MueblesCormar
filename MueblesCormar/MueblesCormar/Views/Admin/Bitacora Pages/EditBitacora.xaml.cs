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
          
        }
    }
}