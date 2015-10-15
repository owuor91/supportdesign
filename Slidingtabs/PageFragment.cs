
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;

namespace Slidingtabs
{
	public class PageFragment : Android.Support.V4.App.Fragment
	{
		private int position;
		private View root;

		private EditText num1, num2;
		private TextView ans;
		private Button btnAdd;

		public static PageFragment NewInstance(int position)
		{
			var f = new PageFragment ();
			var b = new Bundle ();
			b.PutInt ("position", position);
			f.Arguments = b;
			return f;
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			position = Arguments.GetInt ("position");
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			
			switch (position) {
			case 0 :
				root =  inflater.Inflate (Resource.Layout.fragment_one, container, false);
				var text = root.FindViewById<TextView> (Resource.Id.textView);
				int realpos = position + 1;
				text.Text = "Page " + realpos;
				break;
			case 1 :
				root =  inflater.Inflate (Resource.Layout.FragmentOne, container, false);
				AddEx ();
				break;
			case 2 :
				root =  inflater.Inflate (Resource.Layout.FragmentTwo, container, false);
				break;
			case 3 :
				root =  inflater.Inflate (Resource.Layout.FragmentThree, container, false);
				break;
			default:
				break;
			}
			return root;
		}



		public void AddEx()
		{
			num1 = root.FindViewById<EditText> (Resource.Id.num1);
			num2 = root.FindViewById<EditText> (Resource.Id.num2);
			btnAdd = root.FindViewById<Button> (Resource.Id.btnAdd);
			ans = root.FindViewById<TextView> (Resource.Id.ans);

			btnAdd.Click += (sender, e) => {
				int number1 = Int32.Parse (num1.Text);
				int number2 = Int32.Parse (num2.Text);
				int sum = number1 + number2;
				ans.Text= sum.ToString ();
			};
				
		}


	}



}

