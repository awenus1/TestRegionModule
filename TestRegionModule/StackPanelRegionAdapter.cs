using Prism.Regions;
using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace TestRegionModule
{
    internal class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }
            if (regionTarget == null)
            {
                throw new ArgumentNullException(nameof(regionTarget));
            }

            region.Views.CollectionChanged += (sender, args) =>
            {
                if (args.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var view in args.NewItems)
                    {
                        if (view is UIElement uiElement)
                        {
                            regionTarget.Children.Add(uiElement);
                        }
                    }
                }
                else if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var view in args.OldItems)
                    {
                        if (view is UIElement uiElement)
                        {
                            regionTarget.Children.Remove(uiElement);
                        }
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
