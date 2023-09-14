namespace ScadaSnusProject.Model
{
    public class TagRecord
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public double? LowLimit { get; set; }
        public double? HighLimit { get; set; }
    }
}