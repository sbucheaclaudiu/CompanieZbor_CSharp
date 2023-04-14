// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace AgentieZboruriMPP
{
	[Register ("searchViewController")]
	partial class SearchViewController
	{
		[Outlet]
		AppKit.NSButton buyButton { get; set; }

		[Outlet]
		AppKit.NSButton closeButton { get; set; }

		[Outlet]
		AppKit.NSDatePicker dataPicker { get; set; }

		[Outlet]
		AppKit.NSTextField destinatieField { get; set; }

		[Outlet]
		AppKit.NSButton searchButton { get; set; }

		[Outlet]
		AppKit.NSTableView zborTableView { get; set; }

		[Action ("handdleSearchButton:")]
		partial void handdleSearchButton (Foundation.NSObject sender);

		[Action ("handleBuyButton:")]
		partial void handleBuyButton (Foundation.NSObject sender);

		[Action ("handleCloseButton:")]
		partial void handleCloseButton (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (buyButton != null) {
				buyButton.Dispose ();
				buyButton = null;
			}

			if (closeButton != null) {
				closeButton.Dispose ();
				closeButton = null;
			}

			if (dataPicker != null) {
				dataPicker.Dispose ();
				dataPicker = null;
			}

			if (destinatieField != null) {
				destinatieField.Dispose ();
				destinatieField = null;
			}

			if (searchButton != null) {
				searchButton.Dispose ();
				searchButton = null;
			}

			if (zborTableView != null) {
				zborTableView.Dispose ();
				zborTableView = null;
			}

		}
	}
}
