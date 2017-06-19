
using System.Windows.Controls;

namespace UIFeautures
{
    public class UIFeatures
    {

        public void EnableNextTab(TabItem item, TabControl MainTabControl, bool switchTab = true){
            item.IsEnabled = true;
            if (switchTab)
                MainTabControl.SelectedIndex += 1;

        }

    }

}