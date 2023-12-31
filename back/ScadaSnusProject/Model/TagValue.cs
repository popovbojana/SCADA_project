﻿using System.ComponentModel.DataAnnotations;

namespace ScadaSnusProject.Model;

public class TagValue
{
    [Key]
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public double Value { get; set; }
    public int TagId { get; set; }
    public Tag? Tag { get; set; }

    public TagValue(int id, DateTime timestamp, double value, int tagId)
    {
        Id = id;
        Timestamp = timestamp;
        Value = value;
        TagId = tagId;
    }
    public TagValue(DateTime timestamp, double value, int tagId)
    {
        Timestamp = timestamp;
        Value = value;
        TagId = tagId;
    }
    
}