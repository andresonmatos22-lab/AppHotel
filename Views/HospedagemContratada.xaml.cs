using AppHotel.Models;

namespace AppHotel.Views
{
    public partial class HospedagemContratada : ContentPage
    {
        public HospedagemContratada(Hospedagem hospedagem)
        {
            InitializeComponent();
            BindingContext = hospedagem;
        }

        private async void OnVoltarClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
