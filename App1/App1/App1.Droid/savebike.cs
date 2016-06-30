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
using Android.Provider;
using Java.Util;

namespace App1.Droid
{
  [Activity(Label = "savebike", Icon = "@drawable/icon")]
  public class savebike : Activity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.tablayout);
      ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            ActionBar.SetDisplayShowTitleEnabled(false);
      ActionBar.Tab tab = ActionBar.NewTab();
      tab.SetText("Calendar");
      tab.SetIcon(Resource.Drawable.Icon);
      tab.TabSelected += (sender, args) =>
      {
        SetContentView(Resource.Layout.savebike);
        
      };
      ActionBar.AddTab(tab);

      tab = ActionBar.NewTab();
      tab.SetText("Memo");
      tab.SetIcon(Resource.Drawable.Icon);
      tab.TabSelected += (sender, args) =>
      {
        SetContentView(Resource.Layout.savebike2);
      };
      ActionBar.AddTab(tab);

    }
  }
  public class AddEventCalendar
  {
    public void AddEvent(Activity ac, int _calid, string title, string description, DateTime start, DateTime end)
    {
      ContentValues eventValues = new ContentValues();
      eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId, _calid);
      eventValues.Put(CalendarContract.Events.InterfaceConsts.Title, title);
      eventValues.Put(CalendarContract.Events.InterfaceConsts.Description, description);
      eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart, GetDateTimeMS(start.Year, start.Month-1, start.Day, start.Hour, start.Minute));
      eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMS(end.Year, end.Month-1, end.Day, end.Hour, end.Minute));
      eventValues.Put(CalendarContract.Events.InterfaceConsts.AllDay, "0");
      eventValues.Put(CalendarContract.Events.InterfaceConsts.HasAlarm, "1");
      var eventUri = ac.ContentResolver.Insert(CalendarContract.Events.ContentUri, eventValues);
    }
    long GetDateTimeMS(int yr, int month, int day, int hr, int min)
    {
      Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

      c.Set(Calendar.DayOfMonth, day);
      c.Set(Calendar.HourOfDay, hr);
      c.Set(Calendar.Minute, min);
      c.Set(Calendar.Month, month);
      c.Set(Calendar.Year, yr);

      return c.TimeInMillis;
    }
  }
}