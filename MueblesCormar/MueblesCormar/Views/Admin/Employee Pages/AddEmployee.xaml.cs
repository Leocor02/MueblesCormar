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
            BindingContext = viewmodel = new UserViewModel();
        }

        private bool ValidacionDatosUsuario()
        {
            bool R = false;

            if (TxtNombre.Text != null && !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                TxtContrasennia.Text != null && !string.IsNullOrEmpty(TxtContrasennia.Text.Trim()) &&
                TxtTelefono.Text != null && !string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
            {
                R = true;
            }
            else
            {
                //Si alguna validación falla se le indica al usuario lo que hace falta
                if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()))
                {
                    DisplayAlert("Validación de error", "El nombre es requerido", "Ok");
                    TxtNombre.Focus();
                    return false;
                }

                if (TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()))
                {
                    DisplayAlert("Validación de error", "El email es requerido", "Ok");
                    TxtEmail.Focus();
                    return false;
                }

                if (TxtContrasennia.Text == null || string.IsNullOrEmpty(TxtContrasennia.Text.Trim()))
                {
                    DisplayAlert("Validación de error", "La contraseña es requerida", "Ok");
                    TxtContrasennia.Focus();
                    return false;
                }

                if (TxtTelefono.Text == null || string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
                {
                    DisplayAlert("Validación de error", "El telefono es requerido", "Ok");
                    TxtTelefono.Focus();
                    return false;
                }
            }

            return R;
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidacionDatosUsuario())
            {

                int rolID = 2;//id rol empleado

                var answer = await DisplayAlert("Confirmación requerida", "Estas seguro de añadir este usuario?", "Si", "No");

                if (answer)
                {

                    bool R = await viewmodel.AddUsuario(TxtNombre.Text.Trim(),
                                                     TxtEmail.Text.Trim(),
                                                     TxtContrasennia.Text.Trim(),
                                                     TxtTelefono.Text.Trim(),
                                                     rolID);

                    if (R)
                    {
                        await DisplayAlert("Exito!", "Empleado agregado correctamente", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Hubo Un error al intentar Agregar el empleado", "OK");
                    }
                }
            }
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}