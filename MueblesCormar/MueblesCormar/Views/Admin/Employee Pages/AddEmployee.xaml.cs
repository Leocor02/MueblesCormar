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
        BitacoraViewModel bitacoraViewModel;
        public AddEmployee()
        {
            InitializeComponent();
            BindingContext = viewmodel = new UserViewModel();
            bitacoraViewModel = new BitacoraViewModel();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
                TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()) ||
                TxtContrasennia.Text == null || string.IsNullOrEmpty(TxtContrasennia.Text.Trim()) ||
                TxtTelefono.Text == null || string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
            {
                await DisplayAlert("Error", "Todos los espacios son requeridos", "OK");
                return;
            }

                var answer = await DisplayAlert("Confirmación requerida", "Estas seguro de añadir este usuario?", "Si", "No");

                if (answer)
                {

                    int rolID = 2;//id rol empleado

                    bool R = await viewmodel.AddUsuario(TxtNombre.Text.Trim(),
                                                     TxtEmail.Text.Trim(),
                                                     TxtContrasennia.Text.Trim(),
                                                     TxtTelefono.Text.Trim(),
                                                     rolID);

                    if (R)
                    {
                        await DisplayAlert("Exito!", "Empleado agregado correctamente", "OK");
                        R = await bitacoraViewModel.AddBitacora(1,"Empleado",GlobalObjects.GlobalUser.Idusuario);
                      if (R)
                      {
                        await Navigation.PopAsync();
                      }
                      else
                      {
                        await DisplayAlert("Error", "Hubo un error al insertar en la bitácora", "OK");
                      }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Hubo un error al intentar agregar el empleado", "OK");
                    }
                }
            
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}