using System;
using Android.Webkit;
using ExampleWebView;
using ExampleWebView.Droid;
using Java.Interop;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ControlWebView), typeof(RendererControlWebView))]
namespace ExampleWebView.Droid
{
	//Android.notifySSO(notificationString);

	public class RendererControlWebView : WebViewRenderer
	{ 
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
		{
			base.OnElementChanged(e);

			if (Element != null)
			{
				ControlWebView controlWebView = (ControlWebView)Element;

				Control.Settings.JavaScriptEnabled = true;
				Control.AddJavascriptInterface(new JSInterface(), "Android");

				Control.PostUrl("url", null);
			}
		}

		public class JSInterface : Java.Lang.Object
		{
			public JSInterface()
			{
			}

			[Export]
			[JavascriptInterface]
			public void notifySSO(string name)
			{
				//name contiene el valor que se envía
			}
		}

	}
}
