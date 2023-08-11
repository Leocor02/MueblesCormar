using MueblesCormar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.Register_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRegister : ContentPage
    {
        RegisterViewModel viewModel;
        public AddRegister()
        {
            InitializeComponent();
            BindingContext = viewModel = new RegisterViewModel();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            if (datePicker.Date.ToString() == null || string.IsNullOrEmpty(datePicker.Date.ToString()) ||
                TxtNota.Text == null || string.IsNullOrEmpty(TxtNota.Text.Trim()) ||
                TxtIdUsuario.Text == null || string.IsNullOrEmpty(TxtIdUsuario.Text.Trim()))
            {

                await DisplayAlert("Validacion!", "Todos los espacios son requeridos", "Ok");
                return;
            }

            //confirmación de la acción a realizar
            var answer = await DisplayAlert("Confirmación requerida", "Estas seguro?", "Si", "No");

            if (answer)
            {
                bool R = await viewModel.AddRegistro(datePicker.Date, 
                                                     TxtNota.Text.Trim(), 
                                                     Int32.Parse(TxtIdUsuario.Text.Trim()));
                if (R)
                {
                    await DisplayAlert("ÉXITO", "Registro agregado", "OK");
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
//Pegar en el btnAgregar
//TxtIdDetalleRegistro.Text == null || string.IsNullOrEmpty(TxtIdDetalleRegistro.Text.Trim()) ||
//TxtCantidad.Text == null || string.IsNullOrEmpty(TxtCantidad.Text.Trim()) ||
//TxtPrecioUnidad.Text == null || string.IsNullOrEmpty(TxtPrecioUnidad.Text.Trim()) ||
//TxtSubtotal.Text == null || string.IsNullOrEmpty(TxtSubtotal.Text.Trim()) ||
//TxtImpuestos.Text == null || string.IsNullOrEmpty(TxtImpuestos.Text.Trim()) ||
//TxtTotal.Text == null || string.IsNullOrEmpty(TxtTotal.Text.Trim()) ||
//TxtIdRegistro.Text == null || string.IsNullOrEmpty(TxtIdRegistro.Text.Trim()) ||
//TxtIdProducto.Text == null || string.IsNullOrEmpty(TxtIdProducto.Text.Trim()))

//Pegarlo en el bool R = await viewModel.AddRegistro
//TxtIdDetalleRegistro.Text.Trim(), 
//    TxtCantidad.Text.Trim(), 
//    TxtPrecioUnidad.Text.Trim(), 
//    TxtSubtotal.Text.Trim(), 
//    TxtImpuestos.Text.Trim(), 
//    TxtTotal.Text.Trim(), 
//    TxtIdRegistro.Text.Trim(),
//    TxtIdProducto.Text.Trim();


//           Copiar y pegar al otro lado
//           < Entry x: Name = "TxtIdDetalleRegistro" Placeholder = "Id Detalle Registro" Keyboard = "Numeric" />
//           < Entry x: Name = "TxtCantidad" Placeholder = "Cantidad" Keyboard = "Numeric" />
//           < Entry x: Name = "TxtPrecioUnidad" Placeholder = "Precio unidad" Keyboard = "Numeric" />
//           < Entry x: Name = "TxtSubtotal" Placeholder = "Subtotal" Keyboard = "Numeric" />
//           < Entry x: Name = "TxtImpuestos" Placeholder = "Impuestos" Keyboard = "Numeric" />
//           < Entry x: Name = "TxtTotal" Placeholder = "Total" Keyboard = "Numeric" />
//           < Entry x: Name = "TxtIdRegistro" Placeholder = "Id Registro" Keyboard = "Numeric" />
//           < Entry x: Name = "TxtIdProducto" Placeholder = "ID producto" Keyboard = "Numeric" />