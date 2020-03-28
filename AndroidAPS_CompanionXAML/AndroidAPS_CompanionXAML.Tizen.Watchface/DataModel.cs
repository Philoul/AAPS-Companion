using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tizen.Applications.Messages;
using Tizen;

namespace AndroidAPS_CompanionXAML.Tizen.Watchface
{
    class DataModel : INotifyPropertyChanged
    {
        private readonly string TAG = "DataModel";
        private readonly string localPort = "receiverPort";
        private static MessagePort _msgPort;
        public ObservableCollection<Data.BgData> bgDataList;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DataModel()
        {
            Log.Debug(TAG, "new datamodel created");
            bgDataList = new ObservableCollection<Data.BgData>();
            InitMessageReceiver();
        }

        private void InitMessageReceiver()
        {
            _msgPort = new MessagePort(localPort, false);
            Log.Debug(TAG, "MessagePort Create: " + _msgPort.PortName + "Trusted: " + _msgPort.Trusted);
            _msgPort.MessageReceived += OnBgReceived;
            _msgPort.Listen();
        }

        private void OnBgReceived(object sender, MessageReceivedEventArgs e)
        {
            Log.Debug(TAG, "Message received");
            if(e.Message.GetItem<string>("value") != null
                && e.Message.GetItem<string>("time") != null)
            {
                int value = Int32.Parse(e.Message.GetItem<string>("value"));
                long time = Int64.Parse(e.Message.GetItem<string>("time"));
                Data.BgData bgReading = new Data.BgData(value, time);
                bgDataList.Add(bgReading);
            }
            
        }
    }
}
