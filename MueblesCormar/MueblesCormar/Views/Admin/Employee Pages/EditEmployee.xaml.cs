﻿using MueblesCormar.ViewModels;
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
        public int idUsuarioVM { get; set; }
        public EditEmployee(int idUsuario)
        {
            InitializeComponent();
            //se agrega el bindigcontext de la vista contra el viewModel
            BindingContext = viewModel = new UserViewModel();
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
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            if (TxtNombre.Text == null || string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
                TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()) ||
                TxtContrasennia.Text == null || string.IsNullOrEmpty(TxtContrasennia.Text.Trim()) ||
                TxtTelefono.Text == null || string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
            {
                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "ok");
                return;
            }

            var answer = await DisplayAlert("Confirmación requerida", "Está seguro que quiere modificar el usuario?", "Si", "No");

            if (answer)
            {

                bool R = await viewModel.ActualizarUsuario(
                idUsuarioVM,
                TxtNombre.Text.Trim(),
                TxtEmail.Text.Trim(),
                TxtTelefono.Text.Trim());

                if (R)
                {
                    await DisplayAlert("ÉXITO", "Usuario modificado correctamente", "Ok");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("ERROR", "Hubo un error al intentar modificar el usuario", "Ok");
                }
            }
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}