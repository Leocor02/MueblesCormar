using MueblesCormar.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeHomePage : ContentPage
    {
        public EmployeeHomePage()
        {
            InitializeComponent();
        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Confirmación requerida", "Seguro que quiere cerrar sesión?", "Si", "No");

            if (answer)
            {
                await Navigation.PopAsync();
            }
        }

        private async void BtnInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventoryManagementPage());
        }

        private async void BtnProveedores_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProviderManagementPage());
        }

        private async void BtnProveedorInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProvInvenManagementPage());
        }

        private async void BtnRegistros_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterManagementPage());
        }
    }
}