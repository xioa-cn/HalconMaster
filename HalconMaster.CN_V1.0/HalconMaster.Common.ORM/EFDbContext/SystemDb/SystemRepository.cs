namespace HalconMaster.Common.ORM.EFDbContext.SystemDb;

public class SystemRepository(SysDbContext dbContext) : RepositoryBase<SystemUser>(dbContext), ISystemRepository;