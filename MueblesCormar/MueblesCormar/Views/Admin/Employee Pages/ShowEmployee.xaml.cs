using MueblesCormar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MueblesCormar.ViewModels;
using MueblesCormar.Models.DTOs;

namespace MueblesCormar.Views.Admin.Employee_Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowEmployee : ContentPage
    {
        UserViewModel vm;

        bool isEditPage { get; set; }
        bool isDeletePage { get; set; }

        public ShowEmployee(bool isEdit, bool isDelete)
        {
            InitializeComponent();
            isEditPage = isEdit;
            isDeletePage = isDelete;
            BindingContext = vm = new UserViewModel();

            CargaListaEmpleado();
        }

        private async void CargaListaEmpleado()
        {
            LstEmpleado.ItemsSource = await vm.GetFullListaEmpleado();
        }

        private async void DeleteEmpleado(int idUsuario)
        {
            bool response = await vm.DeleteEmpleado(idUsuario);

            if (response)
            {
                await DisplayAlert("ÉXITO", "Empleado eliminado correctamente", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR", "Hubo un error al intentar eliminar el empleado", "OK");
            }
        }

        private async void LstEmpleado_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (isEditPage || isDeletePage)
            {
                var selectedItem = e.Item as UsuarioDTO;

                if (selectedItem != null)
                {
                    if (isDeletePage)
                    {
                        var answer = await DisplayAlert("Confirmación requerida", "Seguro que desea eliminar este empleado", "Yes", "No");

                        if (answer)
                        {
                            DeleteEmpleado(selectedItem.Idusuario);
                        }
                    }
                    if (isEditPage)
                    {
                        await Navigation.PushAsync(new EditEmployee(selectedItem.Idusuario));
                    }
                }
            }
        }
    }
}