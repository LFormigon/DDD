using DDD.Unimar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDb.Interfaces
{
    public interface IDisciplineRepository
    {
        //CRUD
        public List<Discipline> GetDisciplines();
        public Discipline GetDiscipline(int id);
        public void InsertDiscipline(Discipline discipline);
        public void UpdateDiscipline(Discipline discipline);
        public void DeleteDiscipline(Discipline discipline);
    }
}
