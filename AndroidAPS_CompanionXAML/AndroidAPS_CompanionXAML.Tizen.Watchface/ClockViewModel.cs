using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace AndroidAPS_CompanionXAML.Tizen.Watchface
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        DateTime _time;
        string bgReading;

        public ClockViewModel()
        {
            DataModel dataModel = new DataModel();
            dataModel.bgDataList.CollectionChanged += OnBgDataChanged;
            BgReading = "placeholder";
        }

        private void OnBgDataChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var list = e.NewItems;
            Data.BgData newReading = (Data.BgData) list[list.Count - 1];
            BgReading = newReading.bg.ToString();
        }

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
