using System.Globalization;
using AppHotel.Views;

namespace AppHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var cultura = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultura;
            CultureInfo.DefaultThreadCurrentUICulture = cultura;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var navPage = new NavigationPage(new ContratacaoHospedagem())
            {
                BarBackgroundColor = Color.FromArgb("#0F172A"),
                BarTextColor = Color.FromArgb("#F59E0B")
            };

            return new Window(navPage);
        }
    }
}
