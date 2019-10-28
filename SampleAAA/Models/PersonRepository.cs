using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAAA.Models
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext dbContext;

        public PersonRepository(PersonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        void IPersonRepository.AddPerson(Person person)
        {
            dbContext.People.Add(person);
            dbContext.SaveChanges();
        }

        void IPersonRepository.DeletePerson(int id)
        {
            dbContext.People.Remove(dbContext.People.FirstOrDefault(c => c.PersonId == id));
            dbContext.SaveChanges();
        }

        void IPersonRepository.EditPerson(Person person)
        {
            Person p = dbContext.People.FirstOrDefault(c => c.PersonId == person.PersonId);
            if (p != null)
            {
                p.Name = person.Name;
                p.Family = person.Family;
                p.Email = person.Email;
                dbContext.SaveChanges();
            }
        }

        List<Person> IPersonRepository.GetPeople()
        {
            return dbContext.People.ToList();
        }

        Person IPersonRepository.SearchPersonById(int id)
        {
            Person p = dbContext.People.FirstOrDefault(c => c.PersonId == id);
            return p;

        }
    }
}
