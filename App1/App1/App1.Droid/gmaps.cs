using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace App1.Droid
{
    [Activity(Label = "gmaps")]
    public class gmaps : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.gmaps);

            SetUpMap();
        }

        private void SetUpMap()
        {
            if (mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
            LatLng latlng = new LatLng(51.917789, 4.487388); //Wijnhaven
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 10);
            mMap.MoveCamera(camera);

            MarkerOptions options = new MarkerOptions()
                .SetPosition(latlng)
                .SetTitle("Wijhaven")
                .SetSnippet("Hogeschool Rotterdam")
                .Draggable(true);

            mMap.AddMarker(options);

            mMap.MarkerDragEnd += mMap_MarkerDragEnd;

        }

        void mMap_MarkerDragEnd(object sender, GoogleMap.MarkerDragEndEventArgs e)
        {
            LatLng pos = e.Marker.Position;
            Console.WriteLine(pos.ToString());
        }
    }
}