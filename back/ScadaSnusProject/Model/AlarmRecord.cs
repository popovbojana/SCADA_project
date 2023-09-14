using System;
using System.ComponentModel.DataAnnotations;

namespace ScadaSnusProject.Model
{
    public class AlarmRecord

    {
    public Guid Id{ get; set; }
    public DateTime Timestamp { get; set; }
    public int TagId { get; set; }
    public virtual Tag Tag { get; set; }
    }
}