﻿using System;
using System.Collections.Generic;
using System.Text;
using Tizen;
using Tizen.Applications;
using Tizen.Applications.Messages;

namespace AndroidAPS_CompanionXAML
{
    class Broadcaster
    {
        private string TAG = "Broadcaster";

        public Broadcaster()
        {
            
        }

        public void SendMessage(string value, string time, string direction)
        {
            //string remoteAppId = "AndroidAPS.Tizen.Companion";
            //string remotePort = "bg_reading_port";

            //Log.Debug(TAG, "Create");
            //MessagePort _msgPort = new MessagePort("bg_reading_port", false);
            //Log.Debug(TAG, "MessagePort Create: " + _msgPort.PortName + "Trusted: " + _msgPort.Trusted);

            //Log.Debug(TAG, "sending message");
            //_msgPort.Listen();
            //var bundle = new Bundle();
            //bundle.AddItem("message", "144");
            //bundle.AddItem("value", value);
            //bundle.AddItem("time", time);
            //bundle.AddItem("direction", direction);
            try
            {
                MessagePort messagePort = new MessagePort("SenderPort", true);
                using (var message = new Bundle())
                {
                    message.AddItem("value", "144");
                    message.AddItem("time", "1585393739");
                    messagePort.Listen();
                    messagePort.Send(message, "org.tizen.example.AndroidAPS_CompanionXAML.Tizen.Watchface", "receiverPort");
                }
            }
            catch(Exception e)
            {
                Log.Debug(TAG, e.ToString());
            }
        }

        private void MessageReceivedCallback(object sender, MessageReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
