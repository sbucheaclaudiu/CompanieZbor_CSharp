// WARNING
// This file has been generated automatically by Rider IDE to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface buyViewController : NSViewController {
	NSTextField *_adresaField;
	NSButton *_buyButton;
	NSTextField *_messageLabel;
	NSTextField *_nrLocuriField;
	NSTextField *_numeClientField;
	NSTextField *_numeTuristiField;
	NSTextField *_zborIDField;
}

@property (nonatomic, retain) IBOutlet NSTextField *adresaField;

@property (nonatomic, retain) IBOutlet NSButton *buyButton;

@property (nonatomic, retain) IBOutlet NSTextField *messageLabel;

@property (nonatomic, retain) IBOutlet NSTextField *nrLocuriField;

@property (nonatomic, retain) IBOutlet NSTextField *numeClientField;

@property (nonatomic, retain) IBOutlet NSTextField *numeTuristiField;

@property (nonatomic, retain) IBOutlet NSTextField *zborIDField;

- (IBAction)handleBuyButton:(id)sender;

@end
