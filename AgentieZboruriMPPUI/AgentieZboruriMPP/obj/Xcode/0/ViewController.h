// WARNING
// This file has been generated automatically by Rider IDE to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface ViewController : NSViewController {
	NSTextField *_ErrorMessageLabel;
	NSButton *_loginButton;
	NSTextField *_passwordLabel;
	NSSecureTextField *_passwordTextField;
	NSTextField *_titleLabel;
	NSTextField *_usernameLabel;
	NSTextField *_usernameTextField;
}

@property (nonatomic, retain) IBOutlet NSTextField *ErrorMessageLabel;

@property (nonatomic, retain) IBOutlet NSButton *loginButton;

@property (nonatomic, retain) IBOutlet NSTextField *passwordLabel;

@property (nonatomic, retain) IBOutlet NSSecureTextField *passwordTextField;

@property (nonatomic, retain) IBOutlet NSTextField *titleLabel;

@property (nonatomic, retain) IBOutlet NSTextField *usernameLabel;

@property (nonatomic, retain) IBOutlet NSTextField *usernameTextField;

- (IBAction)handleLogin:(id)sender;

@end
