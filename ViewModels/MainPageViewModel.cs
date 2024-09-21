using System.ComponentModel;
using System.Windows.Input;

namespace AreaCirculoAppMvvm.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public const double PI = 3.1415926535897931;

        private double _radio;
        private double _area;

        public double Radio
        {
            get => _radio;
            set
            {
                if (_radio != value)
                {
                    _radio = value;
                    OnPropertyChanged(nameof(Radio));
                }
            }
        }

        public double Area
        {
            get => _area;
            set
            {
                if (_area != value)
                {
                    _area = value;
                    OnPropertyChanged(nameof(Area));
                }
            }
        }

        public ICommand CalcularAreaCommand { get; }
        public ICommand LimpiarCommand { get; }

        public MainPageViewModel()
        {
            CalcularAreaCommand = new Command(CalcularArea);
            LimpiarCommand = new Command(Limpiar);
        }

        private void CalcularArea()
        {
            Area = PI * Radio * Radio;
        }

        private void Limpiar()
        {
            Radio = 0;
            Area = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
