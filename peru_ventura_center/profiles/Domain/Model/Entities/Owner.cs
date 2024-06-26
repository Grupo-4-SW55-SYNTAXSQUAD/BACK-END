using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.Publishing.Domain.Model.Entities;

namespace peru_ventura_center.profiles.Domain.Model.Entities
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Promotion Promotion { get; set; }
        public int? PromotionId { get; set; }

        public Owner() { 
            OwnerId = 0;
            UserId = 0;
        }
        public Owner(int UserId)
        {
            this.UserId = UserId;
            PromotionId = null;
        }
        public Owner(int UserId, int PromotionId)
        {
            this.UserId = UserId;
            this.PromotionId = PromotionId;
        }
        public Owner(CreateOwnerCommand command)
        {
            UserId= command.UserId;
            PromotionId= command.PromotionId;
        }
    }
}
