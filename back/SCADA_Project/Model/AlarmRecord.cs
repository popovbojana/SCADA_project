using System;
using System.ComponentModel.DataAnnotations;

namespace SCADA_Project.Model
{
    public class AlarmRecord : IBaseEntity

    {
    public Guid Id{ get; set; }
    public DateTime Timestamp { get; set; }
    public int TagId { get; set; }
    public virtual Tag Tag { get; set; }
    }
}