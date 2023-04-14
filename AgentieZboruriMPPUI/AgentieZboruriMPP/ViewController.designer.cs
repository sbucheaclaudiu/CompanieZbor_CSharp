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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField ErrorMessageLabel { get; set; }

		[Outlet]
		AppKit.NSButton loginButton { get; set; }

		[Outlet]
		AppKit.NSTextField passwordLabel { get; set; }

		[Outlet]
		AppKit.NSSecureTextField passwordTextField { get; set; }

		[Outlet]
		AppKit.NSTextField titleLabel { get; set; }

		[Outlet]
		AppKit.NSTextField usernameLabel { get; set; }

		[Outlet]
		AppKit.NSTextField usernameTextField { get; set; }

		[Action ("handleLogin:")]
		partial void handleLogin (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (ErrorMessageLabel != null) {
				ErrorMessageLabel.Dispose ();
				ErrorMessageLabel = null;
			}

			if (loginButton != null) {
				loginButton.Dispose ();
				loginButton = null;
			}

			if (passwordLabel != null) {
				passwordLabel.Dispose ();
				passwordLabel = null;
			}

			if (passwordTextField != null) {
				passwordTextField.Dispose ();
				passwordTextField = null;
			}

			if (titleLabel != null) {
				titleLabel.Dispose ();
				titleLabel = null;
			}

			if (usernameLabel != null) {
				usernameLabel.Dispose ();
				usernameLabel = null;
			}

			if (usernameTextField != null) {
				usernameTextField.Dispose ();
				usernameTextField = null;
			}

		}
	}
}
