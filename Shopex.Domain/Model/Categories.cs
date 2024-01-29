namespace Shopex.Domain.Model
{
    public class Categories
    {
        public int category_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
        public string image_url { get; set; }
        public int? parent_id { get; set; }
        public int? order { get; set; }
        public string external_id { get; set; }
        public string external_parent_id { get; set; }
        public bool is_active { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public IEnumerable<SubCategories> subCategories { get; set; }
        public IEnumerable<SubCategories> categories { get; set; }

    }
}
