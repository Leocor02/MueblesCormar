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

        private void BtnProveedores_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnInventario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventoryManagementPage());
        }
    }
}