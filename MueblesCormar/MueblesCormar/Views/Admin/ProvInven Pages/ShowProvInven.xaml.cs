using MueblesCormar.Models.DTOs;
using MueblesCormar.ViewModels;
using MueblesCormar.Views.Admin.Porvider_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.ProvInven_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowProvInven : ContentPage
    {
        ProvInvenViewModel viewModel;

        bool isEditPage { get; set; }
        bool isDeletePage { get; set; }
        public ShowProvInven(bool isEdit, bool isDelete)
        {
            InitializeComponent();
            BindingContext = viewModel = new ProvInvenViewModel();
            CargaListaProveedorInventario();
            isEditPage = isEdit;
            isDeletePage = isDelete;
        }

        private async void CargaListaProveedorInventario()
        {
            LstProveedorInventario.ItemsSource = await viewModel.GetFullListaProveedorInventario();
        }

        private async void DeleteProveedorInventario(int idProveedorInventario)
        {

            bool response = await viewModel.DeleteProveedorInventario(idProveedorInventario);

            if (response)
            {
                await DisplayAlert("Exito", "Proveedor Eliminado correctamente", "OK");

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Hubo un error al intentar eliminar el proveedor", "OK");
            }
        }

        private async void LstProveedorInventario_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (isEditPage || isDeletePage)
            {
                var selectedItem = e.Item as ProveedorInventarioDTO;

                if (selectedItem != null)
                {
                    if (isDeletePage)
                    {
                        var answer = await DisplayAlert("Confirmacion requerida!", "seguro que deseas eliminar este proveedor?", "Si", "No");

                        if (answer)
                        {
                            DeleteProveedorInventario(selectedItem.IdproveedorInventario);
                        }
                    }

                    if (isEditPage)
                    {
                        await Navigation.PushAsync(new EditProvInven(selectedItem.IdproveedorInventario));
                    }
                }
            }
        }
    }
}