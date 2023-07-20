using MueblesCormar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MueblesCormar.ViewModels;

namespace MueblesCormar.Views.Admin.Employee_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowEmployee : ContentPage
    {
        UserViewModel vm;

        public ShowEmployee()
        {
            InitializeComponent();

            BindingContext = vm = new UserViewModel();

            CargaListaEmpleado();
        }

        private async void CargaListaEmpleado()
        {
            lstEmpleado.ItemsSource = await vm.GetFullListaEmpleado();
        }


    }
}