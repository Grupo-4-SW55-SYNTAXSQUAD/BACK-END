using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace peru_ventura_center.profiles.Domain.Model.Entities
{
    public partial class UserAudit : IEntityWithCreatedUpdatedDate
    {
        
        [Column("CreatedAt")]
        public DateTimeOffset? CreatedDate { get; set; }

        [Column("UpdatedAt")]
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
