using System;

namespace SCADA_Project.Model
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}