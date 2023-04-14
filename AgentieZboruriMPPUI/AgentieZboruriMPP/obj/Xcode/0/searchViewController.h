// WARNING
// This file has been generated automatically by Rider IDE to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface searchViewController : NSViewController {
	NSButton *_buyButton;
	NSButton *_closeButton;
	NSDatePicker *_dataPicker;
	NSTextField *_destinatieField;
	NSButton *_searchButton;
	NSTableView *_zborTableView;
}

@property (nonatomic, retain) IBOutlet NSButton *buyButton;

@property (nonatomic, retain) IBOutlet NSButton *closeButton;

@property (nonatomic, retain) IBOutlet NSDatePicker *dataPicker;

@property (nonatomic, retain) IBOutlet NSTextField *destinatieField;

@property (nonatomic, retain) IBOutlet NSButton *searchButton;

@property (nonatomic, retain) IBOutlet NSTableView *zborTableView;

- (IBAction)handdleSearchButton:(id)sender;

- (IBAction)handleBuyButton:(id)sender;

- (IBAction)handleCloseButton:(id)sender;

@end
