using System;
using Android.Views;

namespace Slidingtabs
{
	public interface ICustomTabProvider
	{
		View GetCustomTabView(ViewGroup parent, int position);
	}
}

