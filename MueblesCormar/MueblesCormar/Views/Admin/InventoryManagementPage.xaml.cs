using MueblesCormar.Views.Admin.Inventory_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryManagementPage : ContentPage
    {
        public InventoryManagementPage()
        {
            InitializeComponent();
        }

        private async void BtnVerInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowInventory(false, false));
        }

        private async void BtnAgregarInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddInventory());
        }

        private async void BtnModificarInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowInventory(true, false));
        }

        private async void BtnEliminarInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowInventory(false, true));
        }
    }
}