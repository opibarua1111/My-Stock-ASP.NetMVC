using System.ComponentModel.DataAnnotations;

namespace MyStock.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string BuyPrice { get; set; }
        [Required]
        public string SellPrice { get; set; }

        public DateTime EntryDate { get; set; } = DateTime.Now;
    }
}
