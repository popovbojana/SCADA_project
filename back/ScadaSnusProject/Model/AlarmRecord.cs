using System;
using System.ComponentModel.DataAnnotations;
using SCADA_Project.Model;

namespace ScadaSnusProject.Model
{
    public class AlarmRecord : IBaseEntity

    {
    public Guid Id{ get; set; }
    public DateTime Timestamp { get; set; }
    public int TagId { get; set; }
    public virtual Tag Tag { get; set; }
    }
}