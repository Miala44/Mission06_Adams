using System.ComponentModel.DataAnnotations;

namespace Mission06_Adams.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
