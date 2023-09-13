using System;
using System.ComponentModel.DataAnnotations;

namespace SCADA_Project.Model
{
    public class Tag : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IOAddress { get; set; }
        public double Value { get; set; }
        public bool isDeleted { get; set; }

    }
}