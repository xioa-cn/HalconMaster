using CommunityToolkit.Mvvm.ComponentModel;
using HalconMaster.Common.Model;

namespace HalconMaster.NavigationModule.ViewModels;

public partial class MainViewModel:BindableBase {
    [ObservableProperty] private string _title = nameof(MainViewModel);
}