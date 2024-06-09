namespace peru_ventura_center.Publishing.Domain.Model.Entities
{

    public class Category
    {
        public int CategoryId { get; set; }
        public string TypeName { get; set; }

        public Category(string TypeName)
        {
            this.TypeName = TypeName;
        }
    }
}
