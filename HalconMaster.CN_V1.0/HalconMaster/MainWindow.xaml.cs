using System.Windows;
using HalconMaster.ViewModels;
using XPrism.Core.DataContextWindow;

namespace HalconMaster;

[XPrismViewModel(nameof(MainWindow),typeof(MainWindowViewModel),nameof(MainWindowViewModel))]
public partial class MainWindow : XPrismWindow {
    public MainWindow() {
        InitializeComponent();
    }
}