using System;
using ExampleWebView;
using ExampleWebView.iOS;
using Foundation;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ControlWebView), typeof(RendererControlWebView))]
namespace ExampleWebView.iOS
{
	// window.webkit.messageHandlers.observe.postMessage(notificationString);

	public class RendererControlWebView : ViewRenderer<ControlWebView, WKWebView>, IWKScriptMessageHandler
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ControlWebView> e)
		{
			base.OnElementChanged(e);

			if (Element != null)
			{
				var contentController = new WKUserContentController();
				contentController.AddScriptMessageHandler(this, "observe");

				var config = new WKWebViewConfiguration();
				config.UserContentController = contentController;


				var webView = new WKWebView(this.NativeView.Frame, config);

				ControlWebView controlWebView = (ControlWebView)Element;


				var request = new NSMutableUrlRequest();

				request.Url = new NSUrl("url");
				string url = request.Url.ToString();

				webView.LoadRequest(request);

				SetNativeControl(webView);
			}
		}

		public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
		{
			var msg = message.Body; //valor que se envía

			var name = message.Name; // nombre de la notificación que se ha mandado
		}
	}
}
