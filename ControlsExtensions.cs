using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MySelfProject
{
    public static class ControlsExtensions
    {
        public static void AddChild(this DockPanel dock, UIElement uIElement, Dock posi)
        {
            dock.Children.Add(uIElement);
            DockPanel.SetDock(uIElement, posi);
        }


    }
}
