using HalconMaster.Common.Model.ORMModels;

namespace HalconMaster.Common.ORM.EFDbContext;

public interface IRepository<TEntity> where TEntity : BaseEntity {
    BaseDbContext DbContext { get; }
}