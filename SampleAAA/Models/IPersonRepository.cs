using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAAA.Models
{
    public interface IPersonRepository
    {
        void AddPerson(Person person);
        void DeletePerson(int id);
        Person SearchPersonById(int id);
        List<Person> GetPeople();
        void EditPerson(Person person);
    }
}
