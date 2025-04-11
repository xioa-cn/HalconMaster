namespace HalconMaster.Common.ORM.EFDbContext;

public static class ConnectString
{
    private static string? _dbConnectString;

    public static string DbConnectString
    {
        get
        {
            if (_dbConnectString == null) throw new ArgumentNullException(nameof(_dbConnectString));

            return _dbConnectString;
        }
        set => _dbConnectString = value;
    }
}