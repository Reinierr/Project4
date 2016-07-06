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
      MarkerOptions start = new MarkerOptions()
       .SetPosition(latlng)
       .SetTitle("Wijnhaven")
       .SetSnippet("Hogeschool Rotterdam")
       .Draggable(true);

      mMap.AddMarker(start);
      MarkerFactory mFactory = new MarkerFactory(preLoad.csvFT.getMarkers());
      for (Iterator iter = mFactory.getIterator(); iter.hasNext();)
      {
        FietsTrommel ft = iter.next();
        if (ft.xcoord.Length > 0 && ft.ycoord.Length > 0)
        {
          double lat = double.Parse(ft.xcoord.Replace('.', ','));
          double lon = Convert.ToDouble(ft.ycoord.Replace('.', ','));
          System.Diagnostics.Debug.WriteLine(lat+"   "+lon);
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
  }
}