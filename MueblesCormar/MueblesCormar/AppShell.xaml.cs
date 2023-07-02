using MueblesCormar.ViewModels;
using MueblesCormar.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MueblesCormar
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
