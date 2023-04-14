using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;
using AgentieZboruriMPP.domain;
using AgentieZboruriMPP.service;

public class ZborTableDataSource : NSTableViewDataSource
{
    private ServiceMain Service { get; set; }
    public List<Zbor> LstZbor { get; set; }
    
    public ZborTableDataSource(ServiceMain service)
        {
            Service = service;
        }

    public void Update()
        {
            LstZbor = Service.getAllZbor();
        }

    public override nint GetRowCount(NSTableView tableView)
        {
            Console.WriteLine(Service.getAllZbor()[0]);
            return Service.getAllZbor().Count;
        }
}