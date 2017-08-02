using System;
using Xamarin.Forms;

namespace ExampleWebView
{
	public class ControlWebView : WebView
	{
		public ControlWebView()
		{
			Navigating += (object sender, WebNavigatingEventArgs e) =>
			 {
				 var url = e.Url;
				 //podemos comprobar si hemos llegado a una url en concreto para hacer una acción
			 };
		}
	}
}
