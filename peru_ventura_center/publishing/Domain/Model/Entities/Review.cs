using peru_ventura_center.Publishing.Domain.Model.Aggregates;

namespace peru_ventura_center.Publishing.Domain.Model.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public Activity Activity { get; set; }
        public int ActivityId { get; set; }

        public Review(int Score, string Comment, int ActivityId)
        {
            this.Score = Score;
            this.Comment = Comment;
            this.ActivityId = ActivityId;
        }
    }
}
