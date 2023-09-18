using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Unimar.Domain.Entities
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public bool IsAvailable { get; set; }
        public bool EAD { get; set; }
    }
}
