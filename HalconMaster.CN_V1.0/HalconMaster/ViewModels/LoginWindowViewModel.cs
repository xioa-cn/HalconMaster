using HalconMaster.Common.Model;
using XPrism.Core.Events;

namespace HalconMaster.ViewModels;

public partial class LoginWindowViewModel : BindableBase {
    public LoginWindowViewModel(IEventAggregator eventAggregator) : base(eventAggregator) {
    }
}