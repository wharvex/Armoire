﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;



namespace Armoire.ViewModels;

public partial class NotificationAreaViewModel : DrawerAsContentsViewModel
{
    public NotificationAreaViewModel(string? parentID,
                                     int drawerHeirarchy) : base(parentID, drawerHeirarchy) {
        ParentId = parentID;
        DrawerHierarchy = drawerHeirarchy;
        GeneratedDrawer = new DrawerViewModel(this);
        GeneratedDrawer.InnerContents.Add(new BatteryPercentageViewModel());
        Name = "Notification Area";
        SetMoveDirections(this);
    }



}