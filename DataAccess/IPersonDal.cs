using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
  public interface IPersonDal
  {
    PersonDto Fetch(int id);
    int Insert(PersonDto person);
    void Update(PersonDto person);
    void Delete(int id);
  }
}
