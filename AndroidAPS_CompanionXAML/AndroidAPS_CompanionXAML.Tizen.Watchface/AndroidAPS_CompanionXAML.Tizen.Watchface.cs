using System;
using Tizen.Applications;
using Tizen.Wearable.CircularUI.Forms.Renderer.Watchface;
using Xamarin.Forms;

namespace AndroidAPS_CompanionXAML.Tizen.Watchface
{
    class Program : FormsWatchface
    {
        ClockViewModel _viewModel;
        BroadcastReceiver broadcastReceiver;

        protected override void OnCreate()
        {
            base.OnCreate();
            var watchfaceApp = new TextWatchApplication();
            _viewModel = new ClockViewModel();
            broadcastReceiver = new BroadcastReceiver();
            watchfaceApp.BindingContext = _viewModel;
            LoadWatchface(watchfaceApp);
        }

        protected override void OnTick(TimeEventArgs time)
        {
            base.OnTick(time);
            if (_viewModel != null)
            {
                _viewModel.Time = time.Time.UtcTimestamp;
            }
        }

        protected override void OnAmbientChanged(AmbientEventArgs mode)
        {
            base.OnAmbientChanged(mode);
        }

        protected override void OnAmbientTick(TimeEventArgs time)
        {
            base.OnAmbientTick(time);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            Forms.Init(app);
            global::Tizen.Wearable.CircularUI.Forms.Renderer.FormsCircularUI.Init();
            app.Run(args);
        }
    }
}
