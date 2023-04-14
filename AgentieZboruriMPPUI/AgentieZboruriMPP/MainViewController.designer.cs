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
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		AppKit.NSTableColumn airportColumn { get; set; }

		[Outlet]
		AppKit.NSButton buyButton { get; set; }

		[Outlet]
		AppKit.NSTableColumn dateColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn destinationColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn freeSeatsColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn IDColumn { get; set; }

		[Outlet]
		AppKit.NSButton logoutButton { get; set; }

		[Outlet]
		AppKit.NSButton searchButton { get; set; }

		[Outlet]
		AppKit.NSTableColumn timeColumn { get; set; }

		[Outlet]
		AppKit.NSTableView ZborTableView { get; set; }

		[Action ("handleBuyButton:")]
		partial void handleBuyButton (Foundation.NSObject sender);

		[Action ("handleLogoutButton:")]
		partial void handleLogoutButton (Foundation.NSObject sender);

		[Action ("handleSearchButton:")]
		partial void handleSearchButton (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (airportColumn != null) {
				airportColumn.Dispose ();
				airportColumn = null;
			}

			if (IDColumn != null) {
				IDColumn.Dispose ();
				IDColumn = null;
			}

			if (buyButton != null) {
				buyButton.Dispose ();
				buyButton = null;
			}

			if (dateColumn != null) {
				dateColumn.Dispose ();
				dateColumn = null;
			}

			if (destinationColumn != null) {
				destinationColumn.Dispose ();
				destinationColumn = null;
			}

			if (freeSeatsColumn != null) {
				freeSeatsColumn.Dispose ();
				freeSeatsColumn = null;
			}

			if (logoutButton != null) {
				logoutButton.Dispose ();
				logoutButton = null;
			}

			if (searchButton != null) {
				searchButton.Dispose ();
				searchButton = null;
			}

			if (timeColumn != null) {
				timeColumn.Dispose ();
				timeColumn = null;
			}

			if (ZborTableView != null) {
				ZborTableView.Dispose ();
				ZborTableView = null;
			}

		}
	}
}
