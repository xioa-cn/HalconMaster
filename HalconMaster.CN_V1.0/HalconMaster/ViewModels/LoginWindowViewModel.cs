using System.Windows;
using CommunityToolkit.Mvvm.Input;
using HalconMaster.Common.Model;
using HalconMaster.Common.Model.LoginModels;
using HalconMaster.Common.ORM.EFDbContext.SystemDb;
using HalconMaster.StartupDir;
using Microsoft.EntityFrameworkCore;
using XPrism.Core.Events;

namespace HalconMaster.ViewModels;

public partial class LoginWindowViewModel
    : BindableBase
{
    private readonly ISystemRepository _systemRepository;

    public LoginWindowViewModel(IEventAggregator eventAggregator, ISystemRepository systemRepository) : base(
        eventAggregator)
    {
        this._systemRepository = systemRepository;
        this._eventAggregator.GetEvent<LoginEvent>()
            .Subscribe<string, Task>(ReLogin, ThreadOption.UIThread, true, "ReLogin");
    }

    private async Task ReLogin(LoginModel arg)
    {
    }

    [RelayCommand]
    private async Task MainShow(Window window)
    {
        var user = await _systemRepository.DbSet.FirstOrDefaultAsync(e => e.Name == "HalconMaster");
        Console.WriteLine("Name:" + user.Name);
        Startup.MainStartup(window);
    }
}