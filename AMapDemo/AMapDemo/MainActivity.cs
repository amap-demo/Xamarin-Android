using Android.App;
using Android.Widget;
using Android.OS;

namespace AMapDemo
{
    [Activity(Label = "AMapDemo", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Com.Amap.Api.Maps.MapView mapView = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            mapView = new Com.Amap.Api.Maps.MapView(this);
            mapView.OnCreate(savedInstanceState);
            SetContentView(mapView);

        }

        protected override void OnResume()
        {
            base.OnResume(); 
            if (mapView != null)
            {
                mapView.OnResume();
            }

        }


        protected override void OnPause()
        {
            base.OnPause();
            if (mapView != null)
            {
                mapView.OnPause();
            }
        }


        protected override void OnDestroy()
        {
            base.OnDestroy();
            if(mapView != null) {
                mapView.OnDestroy();
            }

        }
    }
}

