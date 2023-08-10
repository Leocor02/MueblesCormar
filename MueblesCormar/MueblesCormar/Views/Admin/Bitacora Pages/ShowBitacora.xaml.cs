using MueblesCormar.Models;
using MueblesCormar.Models.DTOs;
using MueblesCormar.ViewModels;
using MueblesCormar.Views.Admin.Porvider_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.Bitacora_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowBitacora : ContentPage
    {
        BitacoraViewModel vm;
        public ShowBitacora()
        {
            InitializeComponent();
            BindingContext = vm = new BitacoraViewModel();
            CargaListaBitacora();
        }

        private async void CargaListaBitacora()
        {
            LstBitacora.ItemsSource = await vm.GetFullListaBitacora();
        }

       

        
    }
}