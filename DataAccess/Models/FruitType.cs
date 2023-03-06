using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class FruitType
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
