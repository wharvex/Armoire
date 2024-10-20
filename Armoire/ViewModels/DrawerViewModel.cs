﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Armoire.Interfaces;
using Armoire.Models;
using Avalonia.Controls;
using Avalonia.Layout;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Styles.Controls;
using Microsoft.VisualBasic;

namespace Armoire.ViewModels;

public partial class DrawerViewModel : ViewModelBase, IHasId
{
    [ObservableProperty]
    private Orientation _wrapPanelOrientation = Orientation.Horizontal;
    public ObservableCollection<ContentsUnitViewModel> Contents { get; set; } = [];
    public int Id { get; set; }

    [ObservableProperty]
    private int _ParentdrawerhierarchyPosition;

  
    public DrawerAsContentsViewModel drawerAsContentsViewModel { get; set; }









    public DrawerViewModel()
    {
    }

    public DrawerViewModel(int id)
    {
        Id = id;
    }
    public DrawerViewModel(int id, DrawerAsContentsViewModel drawerascontentsviewmodel)
    {
        drawerAsContentsViewModel = drawerascontentsviewmodel;
        Id = id;
    }


    [RelayCommand]
    public async Task addDrawerClick()
    {
        var drawerHierarchy = drawerAsContentsViewModel.DrawerHierarchy;
        var drawerid = drawerAsContentsViewModel.Id;

        var newDrawer = new DrawerAsContentsViewModel();
        newDrawer.DrawerAsContainer = new DrawerViewModel(drawerid++, newDrawer);
        newDrawer.DrawerHierarchy = ++drawerHierarchy;
        await Task.Delay(TimeSpan.FromSeconds(1));
        Contents.Add(newDrawer);
    }

    [RelayCommand]
    public async Task addItemClick()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        Contents.Add(new ItemViewModel());

    }
}
