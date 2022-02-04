﻿using Microsoft.UI.Xaml.Controls;

namespace Microsoft.Maui.Handlers
{
	public partial class ToolbarHandler : ElementHandler<IToolbar, WindowHeader>
	{
		NavigationRootManager? NavigationRootManager =>
			MauiContext?.GetNavigationRootManager();

		protected override WindowHeader CreatePlatformElement()
		{
			return new WindowHeader();
		}
	}
}
