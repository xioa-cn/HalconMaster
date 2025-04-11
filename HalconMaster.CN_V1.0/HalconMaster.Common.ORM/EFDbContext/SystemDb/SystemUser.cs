using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HalconMaster.Common.Model.ORMModels;

namespace HalconMaster.Common.ORM.EFDbContext.SystemDb;

[Table("SYSTEM_USER")]
public class SystemUser : SysEntity
{
    [Key] [Display(Name = "ID")] public int Id { get; set; }

    [Display(Name = "名称")]
    [MaxLength(50)]
    [Required(AllowEmptyStrings = false)]
    public string? Name { get; set; }
}