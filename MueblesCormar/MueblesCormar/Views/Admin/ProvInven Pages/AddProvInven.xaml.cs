﻿using MueblesCormar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.ProvInven_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProvInven : ContentPage
    {
        ProvInvenViewModel viewModel;
        public AddProvInven()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProvInvenViewModel();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (TxtIdProveedor.Text == null || string.IsNullOrEmpty(TxtIdProveedor.Text.Trim()) ||
                TxtIdProducto.Text == null || string.IsNullOrEmpty(TxtIdProducto.Text.Trim()) 
                //||
                //TxtNombreProveedor.Text == null || string.IsNullOrEmpty(TxtNombreProveedor.Text.Trim()) ||
                //TxtNombreProducto.Text == null || string.IsNullOrEmpty(TxtNombreProducto.Text.Trim())
                )
            {

                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "Ok");
                return;
            }

            //confirmación de la acción a realizar
            var answer = await DisplayAlert("Confirmación requerida", "Estas seguro?", "Si", "No");

            if (answer)
            {
                bool R = await viewModel.AddProveedorInventario(Int32.Parse(TxtIdProveedor.Text.Trim()),
                                                                Int32.Parse(TxtIdProducto.Text.Trim())
                                                                //,
                                                                //TxtNombreProveedor.Text.Trim(),
                                                                //TxtNombreProducto.Text.Trim()
                                                                );


                if (R)
                {
                    await DisplayAlert("ÉXITO", "ProveedorInventario agregado", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("ERROR", "Algo salió mal", "OK");
                }
            }
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

//< Entry x: Name = "TxtNombreProveedor" Placeholder = "Nombre del proveedor" />
//            < Entry x: Name = "TxtNombreProducto" Placeholder = "Nombre del producto" />