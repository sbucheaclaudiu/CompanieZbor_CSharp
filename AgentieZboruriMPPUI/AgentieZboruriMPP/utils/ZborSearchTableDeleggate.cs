#nullable enable
using System;
using AppKit;

namespace AgentieZboruriMPP.utils
{
    public class ZborSearchTableDelegate : NSTableViewDelegate
    {
        private const string CellIdentifier = "ZborCell";
        
        private readonly ZborSearchTableDataSource DataSource;
        
        public ZborSearchTableDelegate(ZborSearchTableDataSource datasource)
        {
            this.DataSource = datasource;
        }
        
        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            var view = (NSTextField?)tableView.MakeView (CellIdentifier, this);
            
            if (view == null) {
                view = new NSTextField ();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }

            // Setup view based on the column selected
            view.StringValue = tableColumn.Title switch
            {
                "destination" => DataSource.LstZbor[(int)row].Destination,
                "date" => DataSource.LstZbor[(int)row].Data.ToString(),
                "time" => DataSource.LstZbor[(int)row].Time,
                "airport" => DataSource.LstZbor[(int)row].Airport,
                "freeSeats" => DataSource.LstZbor[(int)row].NrLocuriLibere.ToString(),
                "ID" => DataSource.LstZbor[(int)row].ID.ToString(),
                _ => view.StringValue
            };
            return view;
        }
    }
}