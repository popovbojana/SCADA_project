using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScadaSnusProject.Model
{
    /*public class User : IBaseEntity*/
    public class User

    {
        /*public Int Id { get; set; }*/
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}