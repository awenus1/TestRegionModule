using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace TestRegionModule
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : UserControl
    {
        private readonly IRegionManager _regionManager;
        public MainWindowView(IRegionManager regionManager)
        {
            InitializeComponent();
            SetRegionManager(regionManager, "RegionName");
        }

        void SetRegionManager(IRegionManager regionManager, string regionName)
        {
            if (regionManager.Regions.ContainsRegionWithName(regionName))
            {
                IRegion region = regionManager.Regions[regionName];
                regionManager.Regions.Remove(regionName);
            }
            //RegionManager.SetRegionName(regionTarget, regionName);
            //RegionManager.SetRegionManager(regionTarget, regionManager);
        }
    }
}
