﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;


namespace VideoBuyApp
{
	[BroadcastReceiver()]
	[IntentFilter(new[] { "android.intent.action.PHONE_STATE" })]
	[Activity (Label = "VideoBuyApp", Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar")]
	public class MainActivity : Activity
	{
		protected Activity _Context;
		protected ListView _UiVideosList;
		protected VideosListAdapter _VideosListAdapter;
		public static VideoBuyDB _VideoDB;
		//public static List <VideoItem> _BDitems;
		protected TelephonyManager _telephonyManager;
		protected BroadcastReceiver _broadcastReceiver;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			//Window.AddFlags (WindowManagerFlags.NotTouchable);
			//Window.AddFlags (WindowManagerFlags.NotTouchModal);
			//GetSystemService (WindowManager.UpdateViewLayout);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			_UiVideosList = FindViewById<ListView> (Resource.Id.UiVideosList);

			FakeData data = new FakeData ();
			_VideoDB = new VideoBuyDB ();
			_VideoDB.ConnectToDB ("VideoBuyDB.db3");
			_VideoDB.CreateDB ();
			//_VideoDB.Insert (data.allVideos.ToArray ());
			//_VideoDB.SelectBDItems ();

			_VideosListAdapter = new VideosListAdapter (this, _VideoDB.SelectBDItems ().ToArray ());
			_UiVideosList.Adapter = _VideosListAdapter;
			//Intent i = new Intent (this, typeof(IncomingCallReceiver));
			//StartService (i);

			_telephonyManager = (TelephonyManager)GetSystemService (Context.TelephonyService)  as TelephonyManager;
			PhoneStateListener callListener = new PhoneStateListener ();
			PhoneStateListenerFlags callStateListenerFlags = new PhoneStateListenerFlags();
			_telephonyManager.Listen (callListener, PhoneStateListenerFlags.CallState);
		



		}


			/*if (state == TelephonyManager.ExtraStateIdle) {
			
			}

			if (state == TelephonyManager.ExtraStateOffhook) {

			}

			if (state == TelephonyManager.ExtraStateRinging) {
				StartService (new Intent (this, typeof(IncomingCallReceiver)));
				//Toast.MakeText(this,"Phone Is Riging", ToastLength.Long).Show();
			}


			/*switch (state) {
			case TelephonyManager.ExtraStateIdle:
				{
					break;
				}

			case TelephonyManager.ExtraStateOffhook:
				{
					break;
				}
			case TelephonyManager.ExtraStateRinging:
				{
					StartService (new Intent (this, typeof(BroadcastReceiver)));
					break;
				}

			}*/
	/*	}

	}
	[BroadcastReceiver]
	[IntentFilter(new string[] { "android.provider.Telephony.Video_Reciver" })]
	public class VideoReceiver : BroadcastReceiver
	{
		public override void OnReceive (Context context, Intent intent)
		{
			Toast.MakeText (context, "Incoming call", ToastLength.Long).Show ();
			//get the sharedpreference and then do stuff
		}*/	
	}
}



