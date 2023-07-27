using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MueblesCormar.ViewModels;
using MueblesCormar.Models.DTOs;

namespace MueblesCormar.Views.Admin.Porvider_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowProvider : ContentPage
    {
        ProviderViewModel vm;
        bool isEditPage { get; set; }
        bool isDeletePage { get; set; }
        public ShowProvider(bool isEdit, bool isDelete)
        {
            InitializeComponent();
            BindingContext = vm = new ProviderViewModel();
            isEditPage = isEdit;
            isDeletePage = isDelete;
            CargaListaProveedor();
        }

        private async void CargaListaProveedor()
        {
            LstProveedor.ItemsSource = await vm.GetFullListaProveedor();
        }

        private async void DeleteProveedor(int idProveedor)
        {

            bool response = await vm.DeleteProveedor(idProveedor);

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

        private async void LstProveedor_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (isEditPage || isDeletePage)
            {
                var selectedItem = e.Item as ProveedorDTO;

                if (selectedItem != null)
                {
                    if (isDeletePage)
                    {
                        var answer = await DisplayAlert("Confirmacion requerida!", "seguro que deseas eliminar este proveedor?", "Si", "No");

                        if (answer)
                        {
                            DeleteProveedor(selectedItem.Idproveedor);
                        }
                    }

                    if (isEditPage)
                    {
                        await Navigation.PushAsync(new EditProvider(selectedItem.Idproveedor));
                    }
                }
            }
        }
    }
}