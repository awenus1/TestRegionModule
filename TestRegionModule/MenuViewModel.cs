using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace TestRegionModule
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            GenerateMenu();
        }
        public ObservableCollection<UIElement> Items { get; set; } = new ObservableCollection<UIElement>();

        void GenerateMenu()
        {
            Items.Add(new Button { Content = "Button1" });
            Items.Add(new Button { Content = "Button2" });
        }
    }
}
