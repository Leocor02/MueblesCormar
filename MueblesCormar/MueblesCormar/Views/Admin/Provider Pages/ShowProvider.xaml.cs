using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MueblesCormar.ViewModels;

namespace MueblesCormar.Views.Admin.Porvider_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowProvider : ContentPage
    {
        ProviderViewModel vm;
        public ShowProvider()
        {
            InitializeComponent();

            BindingContext = vm = new ProviderViewModel();

            CargaListaProveedor();
        }

        private async void CargaListaProveedor()
        {
            LstProveedor.ItemsSource = await vm.GetFullListaProveedor();
        }
    }
}