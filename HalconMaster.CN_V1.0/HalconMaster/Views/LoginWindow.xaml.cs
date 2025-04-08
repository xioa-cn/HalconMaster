using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using HalconMaster.Common.Model.StartupModels;
using HalconMaster.Common.Services.StartupServices;

namespace HalconMaster.Views;

public partial class LoginWindow : Window,IStartupLoginSuccess {
    public LoginWindow() {
        InitializeComponent();
    }

    public void LoginSuccess() {
        WeakReferenceMessenger.Default.Send(new UseIcon());
    }
}