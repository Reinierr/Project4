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

		private void switchState(int state, Button button1, Button button2, Button button3, DatePicker datePicker, TimePicker timePicker) {
			if (state == 0) {
				button1.Text = "Apply Date";
				button2.Text = "Apply Time";
				button3.Text = "Continue";
				button2.Enabled = false;
				button3.Enabled = false;
				datePicker.Visibility = ViewStates.Visible;
				timePicker.Visibility = ViewStates.Invisible;
			}else if(state == 1) {
				button1.Text = "Change Date";
				button2.Text = "Apply Time";
				button3.Text = "Continue";
				button2.Enabled = true;
				button3.Enabled = false;
				datePicker.Visibility = ViewStates.Invisible;
				timePicker.Visibility = ViewStates.Visible;
			}else if (state == 2) {
				button1.Text = "Change Date";
				button2.Text = "Change Time";
				button3.Text = "Continue";
				button2.Enabled = true;
				button3.Enabled = true;
				datePicker.Visibility = ViewStates.Invisible;
				timePicker.Visibility = ViewStates.Visible;
			}
		}

    public int _calId;
    protected override void OnCreate(Bundle savedInstanceState)
    {
      //Calendar ID on phone
      _calId = Intent.GetIntExtra("calId", 1);

      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.tablayout);
      ActionBar.SetDisplayShowTitleEnabled(false);
      ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			ActionBar.SetDisplayShowTitleEnabled(false);
      ActionBar.Tab tab = ActionBar.NewTab();
      tab.SetText("Calendar");
      tab.SetIcon(Resource.Drawable.Icon);
      tab.TabSelected += (sender, args) =>
      {
        SetContentView(Resource.Layout.savebike);
				var button1 = FindViewById<Button>(Resource.Id.button1);
				var button2 = FindViewById<Button>(Resource.Id.button2);
				var button3 = FindViewById<Button>(Resource.Id.button3);
				var timePicker = FindViewById<TimePicker>(Resource.Id.timePicker1);
				var datePicker = FindViewById<DatePicker>(Resource.Id.datePicker1);
				int status = 0;
				button1.Click += delegate {
					if (status == 0) {
						status = 1;
					}
					else {
						status = 0;
					}
					this.switchState(status, button1, button2, button3, datePicker, timePicker);
				};
				button2.Click += delegate {
					if (status == 1) {
						status = 2;
					}
					else if(status == 2){
						status = 1;
					}
					this.switchState(status, button1, button2, button3, datePicker, timePicker);
				};
				button3.Click += delegate {
					status = 4;
					this.switchState(status, button1, button2, button3, datePicker, timePicker);
				};


				//AddEventCalendar.AddEvent(this, _calId, "This is a Test", "Lorem Ipsum perpetuum mobile", ))
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