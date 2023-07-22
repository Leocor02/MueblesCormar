using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MueblesCormar.ViewModels;

namespace MueblesCormar.Views.Admin.Inventory_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowInventory : ContentPage
    {
        InventoryViewModel vm;
        public ShowInventory()
        {
            InitializeComponent();

            BindingContext = vm = new InventoryViewModel();

            CargaListaInventario();
        }

        private async void CargaListaInventario()
        {
            LstInventario.ItemsSource = await vm.GetFullListaInventario();
        }

    }
}