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
using Android.Locations;

namespace App1.Droid
{
    [Activity(Label = "gmaps")]
    public class gmaps : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;
        private Location loc;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.gmaps);
            curLoc test = new curLoc(this);
            Location loc = test.getLoc();
            this.loc = loc;
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
            LatLng latlng = new LatLng(loc.Latitude, loc.Longitude); //Wijnhaven
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            mMap.MoveCamera(camera);
            MarkerOptions start = new MarkerOptions()
             .SetPosition(latlng)
             .SetTitle("Uw huidige locatie")
             .SetSnippet("U bevind zich hier")
             .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue));


            mMap.AddMarker(start);
            MarkerFactory mFactory = new MarkerFactory(preLoad.csvFT.getMarkers());
            for (Iterator iter = mFactory.getIterator(); iter.hasNext();)
            {
                FietsTrommel ft = iter.next();
                if (ft.xcoord.Length > 0 && ft.ycoord.Length > 0)
                {
                    double lat = double.Parse(ft.xcoord.Replace('.', ','));
                    double lon = Convert.ToDouble(ft.ycoord.Replace('.', ','));
                    LatLng coords = new LatLng(lat, lon);
                    MarkerOptions newMarker = new MarkerOptions()
                     .SetPosition(coords)
                     .SetTitle(ft.Straat)
                     .SetSnippet("Sinds: " + ft.Mutdatum)
                     .Draggable(true);

                    mMap.AddMarker(newMarker);
                }
            }
        }

        void mMap_MarkerDragEnd(object sender, GoogleMap.MarkerDragEndEventArgs e)
        {
            LatLng pos = e.Marker.Position;
            Console.WriteLine(pos.ToString());
        }

        void mMap_Location()
        {

        }
    }
    class curLoc
    {
        private Context context;
        private LocationManager locMgr;
        public curLoc(Context context)
        {
            this.context = context;
        }

        public Location getLoc()
        {
            locMgr = context.GetSystemService(Context.LocationService) as LocationManager;
            Criteria criteria = new Criteria();
            LocationProvider provider = locMgr.GetProvider("network");
            Location location = locMgr.GetLastKnownLocation(provider.Name);
            return location;
        }

        //public double CalculationByDistance(LatLng StartP, LatLng EndP)
        //{

        //}
    }
}