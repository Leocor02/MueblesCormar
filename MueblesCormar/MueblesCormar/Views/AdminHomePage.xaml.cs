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
    public partial class AdminHomePage : ContentPage
    {
        public AdminHomePage()
        {
            InitializeComponent();
        }

        private async void BtnEmpleados_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeeManagementPage());
        }

        private async void BtnProveedores_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProviderManagementPage());
        }

        private async void BtnInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventoryManagementPage());
        }

        private async void BtnProveedorInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProvInvenManagementPage());
        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Confirmación requerida", "Seguro que quiere cerrar sesión?", "Si", "No");

            if (answer)
            {
                await Navigation.PopAsync();
            }
        }

        private async void BtnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterManagementPage());
        }

        private async void BtnBitacoras_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BitacoraManagementPage());
        }
    }
}