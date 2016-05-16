using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;
using Android.Content;
using MsNorgeApp.MapHelpers;

namespace MsNorgeApp.Droid
{
    [Activity(Label = "MsNorge", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        public LocationManager locMgr;
        public bool isGPSEnabled { get; set; }
        public bool isNetworkEnabled { get; set; }
        public bool CanGetLocation { get; set; }
        public GeoLocation GeoLoc { get; set; }
        Location location { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            locMgr = GetSystemService(Context.LocationService) as LocationManager;
            
            String Provider  = LocationManager.GpsProvider;
            if(locMgr.IsProviderEnabled(Provider))
                {
                  locMgr.GetLastKnownLocation(LocationManager.GpsProvider); //.RequestLocationUpdates(Provider, 2000, 1, this);
                }
            else
            {

            }
        }
    }
}

