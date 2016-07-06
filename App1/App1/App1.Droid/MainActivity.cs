using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace App1.Droid
{
  [Activity(Label = "Bike Crime 'n Storage", MainLauncher = true, Icon = "@drawable/icon")]
  public class MainActivity : Activity
  {
    //int count = 1;
    // ? ?
    protected override void OnRestart()
    {
      base.OnRestart();

      Intent intent = Intent;
      Finish();
      StartActivity(intent);
    }
    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);
      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.Main);

      // Get our button from the layout resource,
      // and attach an event to it
      ImageButton button = FindViewById<ImageButton>(Resource.Id.myButton);
      button.Click += (sender, e) =>
      {
        var intent = new Intent(this, typeof(savebike));
        StartActivity(intent);
      };
      ImageButton barscreen = FindViewById<ImageButton>(Resource.Id.barchart);
      barscreen.Click += (sender, e) =>
      {
        var intent = new Intent(this, typeof(barchart));
        StartActivity(intent);
      };
      ImageButton piescreen = FindViewById<ImageButton>(Resource.Id.pieChart);
      piescreen.Click += (sender, e) =>
      {
        var intent = new Intent(this, typeof(piechart));
        StartActivity(intent);
      };
      ImageButton linescreen = FindViewById<ImageButton>(Resource.Id.lineChart);
      linescreen.Click += (sender, e) =>
      {
        var intent = new Intent(this, typeof(linechart));
        StartActivity(intent);
      };
      var path = global::Android.OS.Environment.ExternalStorageDirectory + "/" + Android.OS.Environment.DirectoryDownloads;
      var filePath = System.IO.Path.Combine(path, "bikelocation.txt");
      TextView fileText = FindViewById<TextView>(Resource.Id.textfile);
      ImageButton fileBtn = FindViewById<ImageButton>(Resource.Id.cancelbutton);
      if (File.Exists(filePath))
      {
        using (var streamReader = new StreamReader(filePath))
        {
          string content = streamReader.ReadToEnd();
          System.Diagnostics.Debug.WriteLine(content);
          fileText.Text = content;
        }
      }
      else
      {
        fileText.Text = "No note found.";
        fileBtn.Visibility = ViewStates.Invisible;
      }
      fileBtn.Click += (sender, e) =>
      {
        File.Delete(filePath);
        fileText.Text = "No note found.";
        fileBtn.Visibility = ViewStates.Invisible;
      };
    }
  }
}


