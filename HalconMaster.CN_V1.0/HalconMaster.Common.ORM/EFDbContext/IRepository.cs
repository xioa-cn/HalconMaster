using HalconMaster.Common.Model.ORMModels;
using Microsoft.EntityFrameworkCore;

namespace HalconMaster.Common.ORM.EFDbContext;

public interface IRepository<TEntity> where TEntity : BaseEntity {
    BaseDbContext DbContext { get; }
    public DbSet<TEntity> DbSet { get; }
}