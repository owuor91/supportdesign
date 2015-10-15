
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
using Android.Support.Design.Widget;
using Android.Support.Design.Internal;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.View;


namespace Slidingtabs
{
	[Activity (Label = "Dash", MainLauncher = true, Theme = "@style/Base.AppTheme")]			
	public class Dash : AppCompatActivity
	{
		DrawerLayout drawerlayout;
		NavigationView navigationView;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.dash_layout);
			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.toolbar);
			SetSupportActionBar (toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetHomeAsUpIndicator (Resource.Drawable.ic_menu);

			drawerlayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);
			navigationView = FindViewById<NavigationView> (Resource.Id.nav_view);

			navigationView.NavigationItemSelected += (sender, e) => {
				e.MenuItem.SetChecked (true);
				drawerlayout.CloseDrawers ();
			};
		}
	}
}

