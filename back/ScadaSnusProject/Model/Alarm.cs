using System;
using System.ComponentModel.DataAnnotations;
using SCADA_Project.Model;

namespace ScadaSnusProject.Model
{
    public enum AlarmPriority
    {
        LOW,
        MEDIUM,
        HIGH
    }

    public enum AlarmType
    {
        LOWER,
        HIGHER
    }

    public class Alarm : IBaseEntity
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
        public AlarmType Type { get; set; }
        public AlarmPriority Priority { get; set; }
        public bool IsActive { get; set; }


    }
}