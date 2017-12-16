using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_EF1.Models
{
    public class StudentDBModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int GroupId { get; set; }
        public string Status { get; set; }
    }
}
