using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ScadaSnusProject.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AlarmPriority
    {
        Low,
        Medium,
        High
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AlarmType
    {
        Lower,
        Higher
    }

    public class Alarm
    {
        [Key]
        public int Id { get; set; }
        public double Value { get; set; }
        public int TagId { get; set; }
        public virtual Tag? Tag { get; set; }
        public AlarmType Type { get; set; }
        public AlarmPriority Priority { get; set; }
        
    }
}