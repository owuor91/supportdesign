using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using com.refractored;
using Java.Interop;
using Java.Lang;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using String = Java.Lang.String;
namespace Slidingtabs
{
	[Activity (Label = "Add Transaction", Icon = "@drawable/icon", Theme = "@style/Base.AppTheme")]
	public class MainActivity : BaseActivity, IOnTabReselectedListener, ViewPager.IOnPageChangeListener
	{
		private MyPagerAdapter adapter;
		private int count = 1;
		private int currentColor;
		private ViewPager pager;
		private PagerSlidingTabStrip tabs;

		protected override int LayoutResource {
			get {
				return Resource.Layout.Main;
			}
		}

		public void OnPageScrollStateChanged(int state)
		{
			Console.WriteLine ("page scroll state changed " + state);
		}

		public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
		{
			Console.WriteLine("Page Scrolled");
		}

		public void OnPageSelected(int position)
		{
			Console.WriteLine("Page selected: " + position);
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			adapter = new MyPagerAdapter (SupportFragmentManager);
			pager = FindViewById<ViewPager> (Resource.Id.pager);
			tabs = FindViewById<PagerSlidingTabStrip> (Resource.Id.tabs);
			pager.Adapter = adapter;
			tabs.SetViewPager (pager);

			pager.CurrentItem = 0;
			//tabs.OnTabReselectedListener = this;
			tabs.OnPageChangeListener = this;

			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetHomeButtonEnabled (true);

		}

		public void OnTabReselected(int position)
		{
			Toast.MakeText (this, "Tab reselected: "+ position, ToastLength.Short).Show ();
		}

	}


	public class MyPagerAdapter : FragmentPagerAdapter
	{
		private readonly string[] Titles ={"Income", "Expenditure", "Asset Purchase", "Stock Purchase"};

		public MyPagerAdapter(FragmentManager fm) :base(fm)
		{
			
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted (int position)
		{
			return new String (Titles [position]);
		}

		public override int Count {
			get {
				return Titles.Length;
			}
		}

		public override Fragment GetItem (int position)
		{
			return PageFragment.NewInstance (position);
		}
	}
}


