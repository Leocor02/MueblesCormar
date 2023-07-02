using MueblesCormar.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MueblesCormar.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}