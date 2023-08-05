using MueblesCormar.Views.Admin.Register_Pages;
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
    public partial class RegisterManagementPage : ContentPage
    {
        public RegisterManagementPage()
        {
            InitializeComponent();
        }

        private async void BtnVerRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowRegister(false));
        }

        private async void BtnAgregarRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRegister());
        }

        private async void BtnEliminarRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowRegister(true));
        }
    }
}