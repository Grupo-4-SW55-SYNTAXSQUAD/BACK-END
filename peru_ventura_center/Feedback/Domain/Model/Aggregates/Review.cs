
namespace peru_ventura_center.Feedback.Domain.Model.Aggregates
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public Activity Activity { get; set; }
        public int ActivityId { get; set; }

        public Review()
        {
            Score = 0;
            Comment = string.Empty;
            Activity = new Activity();
        }
        public Review(int Score, string Comment, int ActivityId)
        {
            this.Score = Score;
            this.Comment = Comment;
            this.ActivityId = ActivityId;
        }
    }
}
