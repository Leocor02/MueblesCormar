using MueblesCormar.Views.Admin.Porvider_Pages;
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
    public partial class ProviderManagementPage : ContentPage
    {
        public ProviderManagementPage()
        {
            InitializeComponent();
        }

        private async void BtnVerProveedor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowProvider());
        }

        private async void BtnAgregarProveedor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProvider());
        }

        private void BtnModificarProveedor_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnEliminarProveedor_Clicked(object sender, EventArgs e)
        {

        }
    }
}