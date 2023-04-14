using System;
using AgentieZboruriMPP.domain;
using AgentieZboruriMPP.service;
using AppKit;
using Foundation;

namespace AgentieZboruriMPP
{
	public partial class ViewController : NSViewController
	{
		public ServiceMain Service { get; set; }
		
		public User User { get; set; }
		
		public ViewController (IntPtr handle) : base (handle)
		{
			Service = new ServiceMain(Helper.UserService, Helper.ZborService, Helper.BiletService);
		}
		
		partial void handleLogin(NSObject sender)
		{
			var username = usernameTextField.StringValue;
			var password = passwordTextField.StringValue;

			var user = Service.findUser(username, password);

			if (user != null)
			{
				User = user;
				PerformSegue("LoginToMainSegue", this);
				ErrorMessageLabel.StringValue = "";
			}
			else
				ErrorMessageLabel.StringValue = "Invalid username or password";
		}
		
		public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if (segue.Identifier != "LoginToMainSegue") return;
			var mainViewController = (MainViewController)segue.DestinationController;
			mainViewController.Service = Service;
		}
	}
}
