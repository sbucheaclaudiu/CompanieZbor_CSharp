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
	[Register ("buyViewController")]
	partial class BuyViewController
	{
		[Outlet]
		AppKit.NSTextField adresaField { get; set; }

		[Outlet]
		AppKit.NSButton buyButton { get; set; }

		[Outlet]
		AppKit.NSTextField messageLabel { get; set; }

		[Outlet]
		AppKit.NSTextField nrLocuriField { get; set; }

		[Outlet]
		AppKit.NSTextField numeClientField { get; set; }

		[Outlet]
		AppKit.NSTextField numeTuristiField { get; set; }

		[Outlet]
		AppKit.NSTextField zborIDField { get; set; }

		[Action ("handleBuyButton:")]
		partial void handleBuyButton (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (zborIDField != null) {
				zborIDField.Dispose ();
				zborIDField = null;
			}

			if (messageLabel != null) {
				messageLabel.Dispose ();
				messageLabel = null;
			}

			if (numeTuristiField != null) {
				numeTuristiField.Dispose ();
				numeTuristiField = null;
			}

			if (adresaField != null) {
				adresaField.Dispose ();
				adresaField = null;
			}

			if (buyButton != null) {
				buyButton.Dispose ();
				buyButton = null;
			}

			if (nrLocuriField != null) {
				nrLocuriField.Dispose ();
				nrLocuriField = null;
			}

			if (numeClientField != null) {
				numeClientField.Dispose ();
				numeClientField = null;
			}

		}
	}
}
