﻿using Armoire.Models;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Armoire.ViewModels;

public partial class DrawerAsContentsViewModel : ContentsUnitViewModel
{
    private static int _count;
    public DrawerViewModel DrawerAsContainer { get; set; }

    [ObservableProperty]
    private PlacementMode _flyoutPlacement = PlacementMode.Right;



    public DrawerAsContentsViewModel()
    {
        Name = "drawer " + ++_count;
        IconPath = "/Assets/closedGradientDrawer.svg";
    }

    public DrawerAsContentsViewModel(int id,int drawerHierarchy)
    {

        DrawerHierarchy = drawerHierarchy;  
        Name = "drawer " + ++_count;
        IconPath = "/Assets/closedGradientDrawer.svg";
    }

    public DrawerAsContentsViewModel(int id, string name, string iconPath)
    {
        DrawerAsContainer = new DrawerViewModel(id);
        Name = name;
        IconPath = iconPath;
    }

    private DrawerAsContentsViewModel(DrawerAsContentsViewModel copyMe)
    {
        Name = copyMe.Name;
        IconPath = copyMe.IconPath;
        IconKind = copyMe.IconKind;
        DeleteMe = copyMe.DeleteMe;
    }

    [RelayCommand]
    private void CheckDraweModel(object parameter)
    {

        if (parameter is DrawerAsContentsViewModel viewModel)
        {
            var drawerviewmodel = viewModel.DrawerAsContainer;


            if(viewModel.DrawerHierarchy == 0)
            {
            //    FlyoutPlacement = PlacementMode.Right;
                drawerviewmodel.WrapPanelOrientation = Avalonia.Layout.Orientation.Horizontal;

            }else if(viewModel.DrawerHierarchy % 2 == 1)
            {     //FlyoutPlacement= PlacementMode.Bottom;
                drawerviewmodel.WrapPanelOrientation = Avalonia.Layout.Orientation.Vertical;

            }else
            {
               // FlyoutPlacement = PlacementMode.Bottom;
                drawerviewmodel.WrapPanelOrientation = Avalonia.Layout.Orientation.Horizontal;
            }
           
        }
    }
}
