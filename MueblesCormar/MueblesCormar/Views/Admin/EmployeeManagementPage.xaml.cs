﻿using MueblesCormar.Views.Admin.Employee_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MueblesCormar.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeManagementPage : ContentPage
    {
        public EmployeeManagementPage()
        {
            InitializeComponent();
        }

        private async void BtnModificarEmpleado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowEmployee(true, false));
        }

        private async void BtnVerEmpleado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowEmployee(false, false));
        }

        private async void BtnAgregarEmpleado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync (new AddEmployee());
        }

        private async void BtnEliminarEmpleado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowEmployee(false, true));
        }
    }
}