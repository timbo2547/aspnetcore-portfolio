using System.Collections.Generic;

namespace TimPortfolioApp.Models
{
    public class Category
    {
        public Category()
        {
            SampleItems = new List<SampleItem>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<SampleItem> SampleItems { get; set; }
    }
}