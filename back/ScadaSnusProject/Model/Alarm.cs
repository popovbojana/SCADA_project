using System;
using System.ComponentModel.DataAnnotations;

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

    public class Alarm
    {
        [Key]
        public int Id { get; set; }
        public double Value { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
        public AlarmType Type { get; set; }
        public AlarmPriority Priority { get; set; }
        public bool IsActive { get; set; }
        public string ActivatedTime { get; set; }

        // public Alarm(double value, int tagId, AlarmType type, AlarmPriority priority, bool isActive, string activatedTime)
        // {
        //     Value = value;
        //     TagId = tagId;
        //     Type = type;
        //     Priority = priority;
        //     IsActive = isActive;
        //     ActivatedTime = activatedTime;
        // }
    }
}