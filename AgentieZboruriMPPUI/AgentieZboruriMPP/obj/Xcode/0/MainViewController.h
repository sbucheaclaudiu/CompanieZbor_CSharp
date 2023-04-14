// WARNING
// This file has been generated automatically by Rider IDE to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface MainViewController : NSViewController {
	NSTableColumn *_airportColumn;
	NSButton *_buyButton;
	NSTableColumn *_dateColumn;
	NSTableColumn *_destinationColumn;
	NSTableColumn *_freeSeatsColumn;
	NSTableColumn *_IDColumn;
	NSButton *_logoutButton;
	NSButton *_searchButton;
	NSTableColumn *_timeColumn;
	NSTableView *_ZborTableView;
}

@property (nonatomic, retain) IBOutlet NSTableColumn *airportColumn;

@property (nonatomic, retain) IBOutlet NSButton *buyButton;

@property (nonatomic, retain) IBOutlet NSTableColumn *dateColumn;

@property (nonatomic, retain) IBOutlet NSTableColumn *destinationColumn;

@property (nonatomic, retain) IBOutlet NSTableColumn *freeSeatsColumn;

@property (nonatomic, retain) IBOutlet NSTableColumn *IDColumn;

@property (nonatomic, retain) IBOutlet NSButton *logoutButton;

@property (nonatomic, retain) IBOutlet NSButton *searchButton;

@property (nonatomic, retain) IBOutlet NSTableColumn *timeColumn;

@property (nonatomic, retain) IBOutlet NSTableView *ZborTableView;

- (IBAction)handleBuyButton:(id)sender;

- (IBAction)handleLogoutButton:(id)sender;

- (IBAction)handleSearchButton:(id)sender;

@end
