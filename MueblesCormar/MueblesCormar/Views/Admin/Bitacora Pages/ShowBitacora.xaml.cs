using MueblesCormar.Models;
using MueblesCormar.Models.DTOs;
using MueblesCormar.ViewModels;
using MueblesCormar.Views.Admin.Porvider_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin.Bitacora_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowBitacora : ContentPage
    {
        BitacoraViewModel vm;
        bool isEditPage { get; set; }
        bool isDeletePage { get; set; }
        public ShowBitacora(bool isEdit, bool isDelete)
        {
            InitializeComponent();
            BindingContext = vm = new BitacoraViewModel();
            CargaListaBitacora();
            isEditPage = isEdit;
            isDeletePage = isDelete;
        }

        private async void CargaListaBitacora()
        {
            LstBitacora.ItemsSource = await vm.GetFullListaBitacora();
        }

        private async void DeleteBitacora(int idBitacora)
        {

            bool response = await vm.DeleteBitacora(idBitacora);

            if (response)
            {
                await DisplayAlert("Exito", "Bitácora Eliminada correctamente", "OK");

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Hubo un error al intentar eliminar la bitácora", "OK");
            }

        }

        private async void LstBitacora_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (isEditPage || isDeletePage)
            {
                var selectedItem = e.Item as Bitacora;

                if (selectedItem != null)
                {
                    if (isDeletePage)
                    {
                        var answer = await DisplayAlert("Confirmacion requerida!", "seguro que deseas eliminar esta bitácora?", "Si", "No");

                        if (answer)
                        {
                            DeleteBitacora(selectedItem.Idbitacora);
                        }
                    }

                    if (isEditPage)
                    {
                        await Navigation.PushAsync(new EditBitacora(selectedItem.Idbitacora));
                    }
                }
            }
        }
    }
}