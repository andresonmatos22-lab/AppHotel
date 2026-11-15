using AppHotel.Models;

namespace AppHotel.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        private readonly Hospedagem _hospedagem;

        public ContratacaoHospedagem()
        {
            InitializeComponent();

            var suites = new List<Suite>
            {
                new Suite { Descricao = "Suíte Super Luxo", ValorDiariaAdulto = 180.0, ValorDiariaCrianca = 90.0 },
                new Suite { Descricao = "Suíte Luxo", ValorDiariaAdulto = 130.0, ValorDiariaCrianca = 65.0 },
                new Suite { Descricao = "Suíte Single", ValorDiariaAdulto = 90.0, ValorDiariaCrianca = 45.0 },
                new Suite { Descricao = "Suíte Crise", ValorDiariaAdulto = 55.0, ValorDiariaCrianca = 25.0 }
            };

            pckSuite.ItemsSource = suites;

            _hospedagem = new Hospedagem
            {
                SuiteSelecionada = suites[0]
            };

            BindingContext = _hospedagem;
        }

        private async void OnAvancarClicked(object sender, EventArgs e)
        {
            if (_hospedagem.SuiteSelecionada == null)
            {
                await DisplayAlert("Atenção", "Selecione uma suíte.", "OK");
                return;
            }

            if (_hospedagem.Estadia <= 0)
            {
                await DisplayAlert("Data Inválida", "O Check-out deve ser posterior ao Check-in.", "OK");
                return;
            }

            await Navigation.PushAsync(new HospedagemContratada(_hospedagem));
        }

        private async void OnSobreClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sobre());
        }
    }
}
