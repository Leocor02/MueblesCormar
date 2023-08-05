using MueblesCormar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MueblesCormar.Models.DTOs;
using MueblesCormar.Views.Admin.Porvider_Pages;

namespace MueblesCormar.Views.Admin.Register_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowRegister : ContentPage
    {
        RegisterViewModel viewModel;
        bool isDeletePage  { get; set; }
        public ShowRegister(bool isDelete)
        {
            InitializeComponent();
            CargaListaRegistro();
            isDeletePage = isDelete;
        }

        private async void CargaListaRegistro()
        {
            LstRegistro.ItemsSource = await viewModel.GetFullListaRegistro();
        }

        private async void DeleteRegistro(int idRegistro)
        {

            bool response = await viewModel.DeleteRegistro(idRegistro);

            if (response)
            {
                await DisplayAlert("Exito", "Registro Eliminado correctamente", "OK");

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Hubo un error al intentar eliminar el registro", "OK");
            }

        }

        private async void LstRegistro_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (isDeletePage)
            {
                var selectedItem = e.Item as RegistroDTO;

                if (selectedItem != null)
                {
                    if (isDeletePage)
                    {
                        var answer = await DisplayAlert("Confirmacion requerida!", "seguro que deseas eliminar este registro?", "Si", "No");

                        if (answer)
                        {
                            DeleteRegistro(selectedItem.Idregistro);
                        }
                    }
                }
            }
        }

    }
}