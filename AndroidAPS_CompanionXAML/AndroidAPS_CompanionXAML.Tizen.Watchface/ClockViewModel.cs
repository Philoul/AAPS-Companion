using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndroidAPS_CompanionXAML.Tizen.Watchface
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        DateTime _time;
        string bgReading;

        public DateTime Time
        {
            get => _time;
            set
            {
                if (_time == value) return;
                _time = value;
                OnPropertyChanged();
            }
        }

        public string BgReading
        {
            get => bgReading;
            set
            {
                if (bgReading == value) return;
                bgReading = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
