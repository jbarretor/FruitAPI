using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Fruit
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public long Type { get; set; }
        public string Description { get; set; }
    }
}
