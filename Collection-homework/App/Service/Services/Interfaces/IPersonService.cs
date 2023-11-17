using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IPersonService
    {
      
        List<Person> Save(string name,string surname,string phone);
        List<Person> Delete(string str);
       
        List<Person> FindPerson(string text);
        Person UpdatePerson(string searchText, string newNumber);
        List<Person> SortContact(int choose);
       
    }


}
