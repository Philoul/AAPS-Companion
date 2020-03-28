using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tizen.Applications.Messages;
using Tizen;

namespace AndroidAPS_CompanionXAML.Tizen.Watchface
{
    class BroadcastReceiver
    {
        private static MessagePort _msgPort;
        private string TAG = "MessagePort";

        public BroadcastReceiver()
        {
            Log.Debug(TAG, "Create");
            _msgPort = new MessagePort("bg_reading_port", false);
            Log.Debug(TAG, "MessagePort Create: " + _msgPort.PortName + "Trusted: " + _msgPort.Trusted);
            _msgPort.MessageReceived += OnBgReceived;
            _msgPort.Listen();
        }

        private void OnBgReceived(object sender, MessageReceivedEventArgs e)
        {
            var vm = new ClockViewModel();
            vm.BgReading = e.Message.GetItem<string>("value");

            Log.Debug(TAG, "BG received");
            Log.Debug(TAG, e.Message.GetItem<string>("value"));
            Log.Debug(TAG, e.Message.GetItem<string>("time"));
            Log.Debug(TAG, e.Message.GetItem<string>("direction"));
        }
    }
}
