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
  [Activity(Label = "Map with fietstrommels as markers")]
  public class gmaps : Activity, IOnMapReadyCallback
  {
    private GoogleMap mMap;
    private Location loc;
    private FietsTrommel closest;
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
      float lowest = 99999;
      for (Iterator iter = mFactory.getIterator(); iter.hasNext();)
      {
        FietsTrommel ft = iter.next();
        if (ft.xcoord.Length > 0 && ft.ycoord.Length > 0)
        {
          double lat = Convert.ToDouble(ft.xcoord.Replace('.', ','));
          double lon = Convert.ToDouble(ft.ycoord.Replace('.', ','));
          Location fietsT = new Location("");
          fietsT.Latitude = lat;
          fietsT.Longitude = lon;

          if (fietsT.DistanceTo(loc) < 500)
          {
            LatLng coords = new LatLng(lat, lon);
            MarkerOptions newMarker = new MarkerOptions()
             .SetPosition(coords)
             .SetTitle(ft.Straat)
             .SetSnippet("Sinds: " + ft.Mutdatum)
             .Draggable(true);

            mMap.AddMarker(newMarker);
          }
          if (fietsT.DistanceTo(loc) < lowest)
          {
            lowest = fietsT.DistanceTo(loc);
            closest = ft;
          }
        }
      }
      Location closestF = new Location("");
      double closLat = Convert.ToDouble(closest.xcoord.Replace('.', ','));
      double closLon = Convert.ToDouble(closest.ycoord.Replace('.', ','));
      closestF.Latitude = closLat;
      closestF.Longitude = closLon;
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
  }
}