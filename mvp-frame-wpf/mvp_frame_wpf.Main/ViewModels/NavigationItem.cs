﻿using DevExpress.Mvvm;
using mvp_frame_wpf.Common;
using System;

namespace mvp_frame_wpf.Main.ViewModels
{
  [Serializable]
  public class NavigationItem : INavigationItem, ISupportState<NavigationItem>
  {
    public string Caption { get; set; }
    public NavigationItem() { }
    public NavigationItem(string caption)
    {
      Caption = caption;
    }

    #region Serialization
    NavigationItem ISupportState<NavigationItem>.SaveState()
    {
      return this;
    }
    void ISupportState<NavigationItem>.RestoreState(NavigationItem state)
    {
      Caption = state.Caption;
    }
    #endregion
  }
}
