﻿using System.ComponentModel.DataAnnotations;

namespace ScadaSnusProject.Model;

public class TagValue
{
    [Key]
    public int Id { get; set; }
    public string Timestamp { get; set; }
    public double Value { get; set; }
    public int TagId { get; set; }
    public Tag? Tag { get; set; }
}