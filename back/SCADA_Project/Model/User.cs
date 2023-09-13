using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADA_Project.Model
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    

    }
}