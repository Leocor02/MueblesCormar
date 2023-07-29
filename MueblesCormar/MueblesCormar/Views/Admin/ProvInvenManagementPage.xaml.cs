using MueblesCormar.Views.Admin.ProvInven_Pages;
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
    public partial class ProvInvenManagementPage : ContentPage
    {
        public ProvInvenManagementPage()
        {
            InitializeComponent();
        }

        private async void BtnVerProveedorInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowProvInven(false, false));
        }

        private async void BtnAgregarProveedorInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProvInven());
        }

        private async void BtnModificaProveedorInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowProvInven(true, false));
        }

        private async void BtnEliminarProveedorInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowProvInven(false, true));
        }
    }
}