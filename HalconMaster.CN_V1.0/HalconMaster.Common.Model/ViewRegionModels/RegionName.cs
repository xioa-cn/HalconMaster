namespace HalconMaster.Common.Model.ViewRegionModels;

public static class RegionName {
    public static string MainRegion { get; private set; }
    public static string HomeRegion { get; private set; }


    static RegionName() {
        MainRegion = nameof(MainRegion);
        HomeRegion = nameof(HomeRegion);
    }
}