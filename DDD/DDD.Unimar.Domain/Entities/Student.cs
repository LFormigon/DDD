using DDD.Unimar.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Unimar.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate{ get; set; }
        public bool IsActive { get; set; }

        public List<Discipline> Disciplines { get; set; }

        // public Address Address { get; set; }
    }
}
