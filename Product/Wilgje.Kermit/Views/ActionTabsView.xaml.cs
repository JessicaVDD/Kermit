using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Willow.Kermit.Views
{
    /// <summary>
    /// Interaction logic for ActionTabsView.xaml
    /// </summary>
    public partial class ActionTabsView : UserControl
    {
        public ActionTabsView()
        {
            InitializeComponent();
        }

        private void TabName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
            }
        }
    }
}
