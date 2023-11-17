using Domain.Data;
using Domain.Models;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Service.Services
{
    public class PersonService : IPersonService
    {


        public List<Person> Delete(string str)
        {
            List<Person> people = AppDbContext.People();
            Person person = people.Find(m => m.Name.ToLower().Contains(str.ToLower()) || m.Surname.ToLower().Contains(str.ToLower()));

            if (person != null)
            {
                people.Remove(person);
            } else if (person == null)
            {
                people = new List<Person>();
            }
            return people;
        }
       

        public List<Person> FindPerson(string text)
        {
           return  AppDbContext.People().FindAll(m => m.Name.ToLower().Contains(text.ToLower()) || m.Surname.ToLower().Contains(text.ToLower() )|| m.Phone.ToLower().Contains(text.ToLower()));
    
        }

       
        public List<Person> Save(string name, string surname, string phone)
        {
            List<Person> people =AppDbContext.People();
            Person newPerson = new Person(name, surname, phone);
            people.Add(newPerson);
            return people;                                                    
        }

        public List<Person> SortContact(int choice)
        {
            List<Person> people =AppDbContext.People();
            if (choice==1)
            {
                people = people.OrderBy(m => m.Name).ToList();
            }
            else if(choice==2)
            {
                people = people.OrderByDescending(m => m.Name).ToList();
            
            }
            return people;
        }

        public Person UpdatePerson(string searchText, string newNumber)
        {
            Person person = AppDbContext.People().Find(m => m.Name.ToLower().Contains(searchText.ToLower()) || m.Surname.ToLower().Contains(searchText.ToLower())); 
            person.Phone= newNumber;
            return person;
        }


    }
}
