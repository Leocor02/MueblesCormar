using MueblesCormar.ViewModels;
using MueblesCormar.Models;
using MueblesCormar.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Xml.Linq;

namespace MueblesCormar.Views.Admin.Employee_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditEmployee : ContentPage
    {
        UserViewModel viewModel;
        BitacoraViewModel bitacoraViewModel;
        public int idUsuarioVM { get; set; }
        public EditEmployee(int idUsuario)
        {
            InitializeComponent();
            //se agrega el bindigcontext de la vista contra el viewModel
            BindingContext = viewModel = new UserViewModel();
            bitacoraViewModel = new BitacoraViewModel();
            CargarDataUsuario(idUsuario);
            idUsuarioVM = idUsuario;
        }

        private async void CargarDataUsuario(int idUsuario)
        {
            UsuarioDTO usuariodto = await viewModel.GetDataEmpleado(idUsuario);
            TxtNombre.Text = usuariodto.Nombre;
            TxtEmail.Text = usuariodto.Email;
            TxtContrasennia.Text = usuariodto.Contrasennia;
            TxtTelefono.Text = usuariodto.Telefono;
            TxtIdRol.Text = Convert.ToString(usuariodto.IdrolUsuario);
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
                TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()) ||
                TxtContrasennia.Text == null || string.IsNullOrEmpty(TxtContrasennia.Text.Trim()) ||
                TxtTelefono.Text == null || string.IsNullOrEmpty(TxtTelefono.Text.Trim()) ||
                TxtIdRol.Text == null || string.IsNullOrEmpty(TxtIdRol.Text.Trim()))
            {
                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "OK");
                return;
            }

            var answer = await DisplayAlert("Confirmación requerida", "Está seguro que quiere modificar el usuario?", "Si", "No");

            if (answer)
            {
                bool R = await viewModel.UpdateUsuario(
                idUsuarioVM,
                TxtNombre.Text.Trim(),
                TxtEmail.Text.Trim(),
                TxtContrasennia.Text.Trim(),
                TxtTelefono.Text.Trim(),
                Int32.Parse(TxtIdRol.Text.Trim()));

                if (R)
                {
                    await DisplayAlert("ÉXITO", "Usuario modificado correctamente", "Ok");
                    R = await bitacoraViewModel.AddBitacora(2, "Empleado", GlobalObjects.GlobalUser.Idusuario);
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
                    await DisplayAlert("Error", "Hubo un error al intentar modificar el usuario", "OK");
                }
            }
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

