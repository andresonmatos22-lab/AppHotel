using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppHotel.Models
{
    public class Hospedagem : INotifyPropertyChanged
    {
        private Suite? _suiteSelecionada;
        private int _qntAdultos = 1;
        private int _qntCriancas = 0;
        private DateTime _dataCheckIn = DateTime.Today;
        private DateTime _dataCheckOut = DateTime.Today.AddDays(1);

        public Suite? SuiteSelecionada
        {
            get => _suiteSelecionada;
            set { _suiteSelecionada = value; OnPropertyChanged(); OnPropertyChanged(nameof(ValorTotal)); }
        }

        public int QntAdultos
        {
            get => _qntAdultos;
            set { _qntAdultos = value; OnPropertyChanged(); OnPropertyChanged(nameof(ValorTotal)); }
        }

        public int QntCriancas
        {
            get => _qntCriancas;
            set { _qntCriancas = value; OnPropertyChanged(); OnPropertyChanged(nameof(ValorTotal)); }
        }

        public DateTime DataCheckIn
        {
            get => _dataCheckIn;
            set
            {
                _dataCheckIn = value;
                if (_dataCheckOut <= _dataCheckIn)
                    DataCheckOut = _dataCheckIn.AddDays(1);
                OnPropertyChanged();
                OnPropertyChanged(nameof(Estadia));
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public DateTime DataCheckOut
        {
            get => _dataCheckOut;
            set
            {
                _dataCheckOut = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Estadia));
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public int Estadia => (DataCheckOut.Date - DataCheckIn.Date).Days;

        public double ValorTotal
        {
            get
            {
                if (SuiteSelecionada == null) return 0;
                double totalAdultos = QntAdultos * SuiteSelecionada.ValorDiariaAdulto;
                double totalCriancas = QntCriancas * SuiteSelecionada.ValorDiariaCrianca;
                return (totalAdultos + totalCriancas) * Estadia;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
