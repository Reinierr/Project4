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
using System.IO;

namespace App1.Droid
{
  [Application]
  public class preLoad : Application
  {
    public preLoad(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
    {
    }
    //Fietsdiefstal usage preLoad.csvFD
    public static CSVConnection csvFD;
    //Fietstrommels usage preLoad.csvFT
    public static CSVConnection csvFT;
    public override void OnCreate()
    {
      base.OnCreate();
      csvFD = new CSVConnection("fietsdiefstal", new StreamReader(Assets.Open("fietsdiefstal.csv")));
      csvFT = new CSVConnection("fietstrommel", new StreamReader(Assets.Open("fietstrommels.csv")));
    }
  }
}