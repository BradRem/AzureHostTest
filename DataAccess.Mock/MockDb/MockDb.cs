using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Mock.MockDb
{
  public static class MockDb
  {
    public static List<PersonData> Persons { get; private set; }

    static MockDb()
    {
      Persons = new List<PersonData> 
      {
        new PersonData { Id = 5, FirstName = "Rocky", LastName = "Lhotka" },
        new PersonData { Id = 2, FirstName = "Jerod", LastName = "Asvidian" },
        new PersonData { Id = 1, FirstName = "Marnie", LastName = "Johanessen" },
        new PersonData { Id = 3, FirstName = "Andrew", LastName = "Smith" }
      };
    }
  }
}
