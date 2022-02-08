﻿using System;
using Microsoft.UI.Xaml.Controls;

namespace Microsoft.Maui.Platform
{
	public static class WebViewExtensions
	{
		public static void UpdateSource(this WebView2 platformWebView, IWebView webView)
		{
			platformWebView.UpdateSource(webView, null);
		}

		public static void UpdateSource(this WebView2 platformWebView, IWebView webView, IWebViewDelegate? webViewDelegate)
		{
			if (webViewDelegate != null)
			{
				webView.Source?.Load(webViewDelegate);

				platformWebView.UpdateCanGoBackForward(webView);
			}
		}

		public static void UpdateGoBack(this WebView2 platformWebView, IWebView webView)
		{
			if (platformWebView == null)
				return;

			if (platformWebView.CanGoBack)
				platformWebView.GoBack();

			platformWebView.UpdateCanGoBackForward(webView);
		}
		
		public static void UpdateGoForward(this WebView2 platformWebView, IWebView webView)
		{
			if (platformWebView == null)
				return;

			if (platformWebView.CanGoForward)
				platformWebView.GoForward();

			platformWebView.UpdateCanGoBackForward(webView);
		}

		public static void UpdateReload(this WebView2 platformWebView, IWebView webView)
		{
			// TODO: Sync Cookies

			platformWebView?.Reload();
		}
				
		internal static void UpdateCanGoBackForward(this WebView2 platformWebView, IWebView webView)
		{
			webView.CanGoBack = platformWebView.CanGoBack;
			webView.CanGoForward = platformWebView.CanGoForward;
		}

		public static void Eval(this WebView2 platformWebView, IWebView webView, string script)
		{ 
			if (platformWebView == null)
				return;

			platformWebView.DispatcherQueue.TryEnqueue(async () =>
			{
				await platformWebView.ExecuteScriptAsync(script);
			});
		}
	}
}