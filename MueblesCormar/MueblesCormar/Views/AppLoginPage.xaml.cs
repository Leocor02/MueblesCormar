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
    public partial class AppLoginPage : ContentPage
    {
        public AppLoginPage()
        {
            InitializeComponent();
        }

        private void CmdMostrarContraseña(object sender, ToggledEventArgs e)
        {
            if (SwMostrarContraseña.IsToggled)
            {
                TxtContraseña.IsPassword = false;
            }
            else
            {
                TxtContraseña.IsPassword = true;
            }
        }
    }
}