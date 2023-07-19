using MueblesCormar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.Employee_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditEmployee : ContentPage
    {
        UserViewModel viewModel;
        public EditEmployee()
        {
            InitializeComponent();

            //se agrega el bindigcontext de la vista contra el viewModel
            BindingContext = viewModel = new UserViewModel();

            CargarDataUsuario();
        }

        private void CargarDataUsuario()
        {
            TxtNombre.Text = GlobalObjects.GlobalUser.Nombre;
            TxtEmail.Text = GlobalObjects.GlobalUser.Email;
            TxtTelefono.Text = GlobalObjects.GlobalUser.Telefono;
        }

        private void BtnEditar_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}