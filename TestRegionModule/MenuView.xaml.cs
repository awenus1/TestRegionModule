using System.Windows.Controls;

namespace TestRegionModule
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : StackPanel
    {
        public MenuView(MenuViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
