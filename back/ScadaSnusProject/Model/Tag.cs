using System.ComponentModel.DataAnnotations;

namespace ScadaSnusProject.Model
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IOAddress { get; set; }
        public double Value { get; set; }
    }
}