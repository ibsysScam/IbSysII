
using System.Windows.Controls;

namespace UIFeautures
{
    public class UIFeatures
    {

        public void EnableNextTab(TabItem item, TabControl MainTabControl){
            item.IsEnabled = true;
            MainTabControl.SelectedIndex += 1;

        }

    }

}