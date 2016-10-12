using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsBasicMVVM
{
    public class ClockViewModel : BaseViewModel
    {
        private DateTime _dateTime;
        private double _hue;
        private double _luminosity;
        private double _saturation;
        private Color _color;

        public DateTime DateTime
        {
            get { return _dateTime; }
            set
            {
                _dateTime = value;
                OnPropertyChanged();
            }
        }

        public double Hue
        {
            get { return _hue; }
            set
            {
                _hue = value;
                OnPropertyChanged();
                SetNewColor();
            }
        }

        public double Saturation
        {
            get { return _saturation; }
            set
            {
                _saturation = value;
                OnPropertyChanged();
                SetNewColor();
            }
        }

        public double Luminosity
        {
            get { return _luminosity; }
            set
            {
                _luminosity = value;
                OnPropertyChanged();
                SetNewColor();
            }
        }

        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }

        public ClockViewModel()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                DateTime = DateTime.Now;
                return true;
            });
            Saturation = 0.5;
            Hue = 0.5;
            Luminosity = 0.5;
        }

        private void SetNewColor()
        {
            Color = Color.FromHsla(Hue, Saturation, Luminosity);

            ResetCommand = new Command<string>((key) =>
            {
                Saturation = 0.5;
                Hue = 0.5;
                Luminosity = 0.5;
                SetNewColor();
            });
        }

        public ICommand ResetCommand { private set; get; }
    }
}
