using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MueblesCormar.ViewModels;
using MueblesCormar.Models.DTOs;
using MueblesCormar.Views.Admin.Porvider_Pages;

namespace MueblesCormar.Views.Admin.Inventory_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowInventory : ContentPage
    {
        InventoryViewModel vm;

        bool isEditPage { get; set; }
        bool isDeletePage { get; set; }
        public ShowInventory(bool EditPage, bool DeletePage)
        {
            InitializeComponent();
            BindingContext = vm = new InventoryViewModel();
            CargaListaInventario();
            isEditPage = EditPage;
            isDeletePage = DeletePage;
        }

        private async void CargaListaInventario()
        {
            LstInventario.ItemsSource = await vm.GetFullListaInventario();
        }

        private async void DeleteProducto(int idProducto)
        {

            bool response = await vm.DeleteProducto(idProducto);

            if (response)
            {
                await DisplayAlert("Exito", "Producto eliminado correctamente", "OK");

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Hubo un error al intentar eliminar el producto", "OK");
            }

        }

        private async void LstInventario_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (isEditPage || isDeletePage)
            {
                var selectedItem = e.Item as InventarioDTO;

                if (selectedItem != null)
                {
                    if (isDeletePage)
                    {
                        var answer = await DisplayAlert("Confirmacion requerida!", "seguro que deseas eliminar este producto?", "Yes", "Nop");

                        if (answer)
                        {
                            DeleteProducto(selectedItem.Idproducto);
                        }
                    }

                    if (isEditPage)
                    {
                        await Navigation.PushAsync(new EditInventory(selectedItem.Idproducto));
                    }
                }
            }
        }
    }
}