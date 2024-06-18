namespace peru_ventura_center.Feedback.Domain.Model.Aggregates
{

    public class Category
    {
        public int CategoryId { get; set; }
        public string TypeName { get; set; }

        public Category(string TypeName)
        {
            this.TypeName = TypeName;
        }
        public Category()
        {
            TypeName = string.Empty;
        }
    }
}
