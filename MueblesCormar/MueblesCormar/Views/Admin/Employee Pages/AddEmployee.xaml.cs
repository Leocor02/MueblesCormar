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
    public partial class AddEmployee : ContentPage
    {
        UserViewModel viewmodel;
        public AddEmployee()
        {
            InitializeComponent();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
                TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()) ||
                TxtContrasennia.Text == null || string.IsNullOrEmpty(TxtContrasennia.Text.Trim()) ||
                TxtTelefono.Text == null || string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
            {

                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "Ok");
                return;

            }

            int rolID = 2;//id rol empleado

            bool R = await viewmodel.AgregarNuevoUsuario(TxtNombre.Text.Trim(),
                                                 TxtEmail.Text.Trim(),
                                                 TxtContrasennia.Text.Trim(),
                                                 TxtTelefono.Text.Trim(),
                                                 rolID);

            if (R)
            {
                await DisplayAlert("Exito!", "Empleado Agregado Correctamente", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Hubo Un Error Al Intentar Agregar El Empleado", "Ok");
            }
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}