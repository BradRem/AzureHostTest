using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Mock
{
    public class PersonDal : IPersonDal
    {
        public PersonDto Fetch(int id)
        {
            var person = MockDb.MockDb.Persons.Where(x => x.Id == id).Single();
            return new PersonDto { Id = person.Id, FirstName = person.FirstName, LastName = person.LastName };
        }

        public int Insert(PersonDto person)
        {
            var newId = MockDb.MockDb.Persons.Max(r => r.Id) + 1;
            var newItem = new MockDb.PersonData { Id = newId, FirstName = person.FirstName, LastName = person.LastName };
            MockDb.MockDb.Persons.Add(newItem);
            return newId;
        }

        public void Update(PersonDto person)
        {
            var updatedItem = MockDb.MockDb.Persons.Where(x => x.Id == person.Id).Single();
            updatedItem.FirstName = person.FirstName;
            updatedItem.LastName = person.LastName;
        }

        public void Delete(int id)
        {
            var item = MockDb.MockDb.Persons.Where(r => r.Id == id).FirstOrDefault();
            if (item != null)
                MockDb.MockDb.Persons.Remove(item);
            else
                throw new DataNotFoundException("Person");
        }
    }
}
