using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;
using AgentieZboruriMPP.domain;
using AgentieZboruriMPP.service;

public class ZborSearchTableDataSource : NSTableViewDataSource
{
    private ServiceMain Service { get; set; }
    public List<Zbor> LstZbor { get; set; }
    
    public string Destination { get; set; }
    
    public DateTime Date { get; set; }
    
    public ZborSearchTableDataSource(ServiceMain service, string destination, DateTime date)
    {
        Service = service;
        Destination = destination;
        Date = date;
    }

    public void Update(string destination, DateTime date)
    {
        LstZbor = Service.getZborbySearch(destination, date);
    }

    public override nint GetRowCount(NSTableView tableView)
    {
        return Service.getZborbySearch(Destination, Date).Count;
    }
}