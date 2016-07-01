using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin;
using Android.App;
using Android.Net;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Java.Util;
using Android.Locations;

namespace App1.Droid
{
  [Activity(Label = "savebike", Icon = "@drawable/icon")]
  public class savebike : Activity
  {
		public savebike(){
			
		}
		private DateTime dateTimeAdapter(DateTime originalDateTime, Java.Lang.Integer hour, Java.Lang.Integer minute, int offset=0) {
			string dateTimeString = originalDateTime.ToString().Remove(originalDateTime.ToString().Length - 8);
			minute = new Java.Lang.Integer(minute.IntValue() + offset);
			string timeString = hour.ToString() + ":" + minute.ToString() + ":00";
			return Convert.ToDateTime(dateTimeString + timeString);
		}

		private void switchState(int state, Button button1, Button button2, Button button3, DatePicker datePicker, TimePicker timePicker, TextView label1,TextView label2, EditText textbox1, EditText textbox2, bool gpsConnected, LocationManager locationManager) {
			
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
			}else if (state == 3) {
				ConnectivityManager a = (ConnectivityManager)GetSystemService(ConnectivityService);
				NetworkInfo b = a.ActiveNetworkInfo;
				bool isOnline = (b != null) && b.IsConnected;
				if (isOnline) {
					if (gpsConnected) {
						button1.Enabled = true;
					}else {
						button1.Enabled = false;
					}
				}else {
					button1.Enabled = false;
				}
				button2.Enabled = true;
				button3.Enabled = false;
				button1.Text = "Add Current Location";
				button2.Text = "Save in Calendar";

				button1.Visibility = ViewStates.Visible;
				button2.Visibility = ViewStates.Visible;
				button3.Visibility = ViewStates.Invisible;
				datePicker.Visibility = ViewStates.Invisible;
				timePicker.Visibility = ViewStates.Invisible;
				label1.Visibility = ViewStates.Visible;
				textbox1.Visibility = ViewStates.Visible;
				label2.Visibility = ViewStates.Visible;
				textbox2.Visibility = ViewStates.Visible;
			}
			
		}

    public int _calId;

		private bool checkGps (LocationManager loc) {
			Criteria criteria = new Criteria { Accuracy = Accuracy.Fine };
			if (loc.IsProviderEnabled(LocationManager.GpsProvider)) {
				IList<string> acceptableLocationProviders = loc.GetProviders(criteria, true);
				if (acceptableLocationProviders.Any()) {
					return true;
				}
				else {
					return false;
				}

			}else {
				return false;
			}
		}
    protected override void OnCreate(Bundle savedInstanceState)
    {
			Location curlocation;
			string LocProv;
			LocationManager locationManager = (LocationManager)GetSystemService(LocationService);
			Criteria criteria = new Criteria { Accuracy = Accuracy.Fine };
			if (locationManager.IsProviderEnabled(LocationManager.GpsProvider)) {
				IList<string> acceptableLocationProviders = locationManager.GetProviders(criteria, true);
				if (acceptableLocationProviders.Any()) {
					LocProv = acceptableLocationProviders.First();
					
				}
				else {
					LocProv = string.Empty;
				}
				
			}
			
			//var a = locationManager.RequestLocationUpdates()




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
				var a = new AddEventCalendar();
				DateTime dateTime1 = new DateTime();
				DateTime dateTime2 = new DateTime();


				var button1 = FindViewById<Button>(Resource.Id.button1);
				var button2 = FindViewById<Button>(Resource.Id.button2);
				var button3 = FindViewById<Button>(Resource.Id.button3);
				var timePicker = FindViewById<TimePicker>(Resource.Id.timePicker1);
				var datePicker = FindViewById<DatePicker>(Resource.Id.datePicker1);
				var label1 = FindViewById<TextView>(Resource.Id.textView1);
				var label2 = FindViewById<TextView>(Resource.Id.textView2);
				var textbox1 = FindViewById<EditText>(Resource.Id.editText1);
				var textbox2 = FindViewById<EditText>(Resource.Id.editText2);
				timePicker.SetIs24HourView(Java.Lang.Boolean.True);
				int status = 0;
				button1.Click += delegate {
					if (status == 0) {
						status = 1;
					}
					else if (status == 1 || status == 2){
						status = 0;
					}else {
						// GPS button functionality here
						//locationManager.)
					}
					this.switchState(status, button1, button2, button3, datePicker, timePicker, label1, label2, textbox1, textbox2, checkGps(locationManager), locationManager);
				};
				button2.Click += delegate {
					if (status == 1) {
						status = 2;
					}
					else if(status == 2){
						status = 1;
					}
					else if (status == 3) {
						try {
							a.AddEvent(this, _calId, textbox1.Text, textbox2.Text, dateTime1, dateTime2);
							button2.Text = "Succes! Tap here to go back";
							status = 4;
						}
						catch {
							button2.Text = "Failed, tap here to try again";
						}

					}
					else {
						//System.Diagnostics.Debug.WriteLine("AAAAAmemes");
						this.Finish();
					}
					this.switchState(status, button1, button2, button3, datePicker, timePicker, label1, label2, textbox1, textbox2, checkGps(locationManager), locationManager);
				};
				button3.Click += delegate {
					if (status == 2) {
						dateTime1 = dateTimeAdapter(datePicker.DateTime, timePicker.CurrentHour, timePicker.CurrentMinute);
						dateTime2 = dateTimeAdapter(datePicker.DateTime, timePicker.CurrentHour, timePicker.CurrentMinute, 1);
						System.Diagnostics.Debug.WriteLine(dateTime1.ToString() + "----" + dateTime2.ToString());
						status = 3;
					}
					this.switchState(status, button1, button2, button3, datePicker, timePicker, label1, label2, textbox1, textbox2, checkGps(locationManager), locationManager);
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
			eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone, "EST");
			eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "EST");
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