using HalconMaster.Common.Model.StartupModels;

namespace HalconMaster.StartupDir;

public partial class Startup {
    public ApplicationStartupMode StartupCommandLine(string[]? args) {
        return ApplicationStartupMode.Normal;
    }
}