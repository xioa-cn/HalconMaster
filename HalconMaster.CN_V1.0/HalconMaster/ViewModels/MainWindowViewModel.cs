using HalconMaster.Common.Model;
using XPrism.Core.DI;
using XPrism.Core.Events;
using XPrism.Core.Navigations;

namespace HalconMaster.ViewModels;

[AutoRegister(typeof(MainWindowViewModel), ServiceLifetime.Singleton, nameof(MainWindowViewModel))]
public class MainWindowViewModel : BindableBase {
    public MainWindowViewModel(IEventAggregator eventAggregator) : base(eventAggregator) {
    }
}