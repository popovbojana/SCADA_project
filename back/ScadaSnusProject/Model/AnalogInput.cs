using System;

namespace ScadaSnusProject.Model
{
    public class AnalogInput : Tag
    {
        public string ScanTime { get; set; }
        public bool IsScanOn { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Unit { get; set; }
        
    }
}