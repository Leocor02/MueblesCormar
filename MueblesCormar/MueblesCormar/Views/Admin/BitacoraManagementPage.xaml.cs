using MueblesCormar.Views.Admin.Bitacora_Pages;
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
    public partial class BitacoraManagementPage : ContentPage
    {
        public BitacoraManagementPage()
        {
            InitializeComponent();
        }

        private async void BtnVerBitacora_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowBitacora());
        }
    }
}