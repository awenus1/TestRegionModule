using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Sage.PL.App.Interfaces;
using Sage.PL.Common.Interfaces;
using Sage.PL.Navigation.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace TestRegionModule
{
    [Module(ModuleName = "TestRegionModule")]
    public class TestRegionModule : IPostInitializableModule
    {
        private readonly IUnityContainer unityContainer;
        private readonly IShowMessage showMessage;
        private readonly IAppNavigator appNavigator;
        private IRegionManager regionManager;
        private readonly IShellNavigator shellNavigator;
        public TestRegionModule(IUnityContainer unityContainer, IAppNavigator appNavigator
            , IShowMessage showMessage, IShellNavigator shellNavigator)
        {
            this.unityContainer = unityContainer;
            this.appNavigator = appNavigator;
            this.showMessage = showMessage;
            this.shellNavigator = shellNavigator;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            this.regionManager = containerProvider.Resolve<IRegionManager>();
            RegionAdapterMappings regionAdapterMappings = containerProvider.Resolve<RegionAdapterMappings>();
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), containerProvider.Resolve<StackPanelRegionAdapter>());

            regionManager.RegisterViewWithRegion("RegionName", typeof(MenuView));

            shellNavigator.AddNavigationItem("Regiony", "RegionTest", () => ShowRegionsViewExecuted(), () => true, () => true, 1202);
        }
        public void PostInitialize()
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        private void ShowRegionsViewExecuted()
        {
            try
            {
                appNavigator.ShowViewAsync(() => unityContainer.Resolve<MainWindowView>(), new OpenViewParams()
                {
                    ViewType = typeof(MainWindowView).ToString(),
                    OpenFullScreen = true,
                    OpenMaximized = false,
                    OpenNewIfExists = false,
                    OpenUsingLastFrameParams = true,
                    ProgressDelay = 1,
                    ShowProgressControl = true,
                    Size = new Size(500, 220),
                    Title = "Regiony"
                });

            }
            catch (Exception ex)
            {
                showMessage.ShowError(ex.Message);
            }
        }
    }
}
