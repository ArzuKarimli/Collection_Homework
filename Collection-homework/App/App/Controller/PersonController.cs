using Domain.Models;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Controller
{
    internal class PersonController
    {
        private readonly IPersonService _personService;
        public PersonController()
        {
            _personService = new PersonService();
        }

        public void SaveNewPerson()
        {
            Console.WriteLine("Name :");
            string name=Console.ReadLine();
          
            Console.WriteLine("Surname :");
            string surname = Console.ReadLine();

            Console.WriteLine("Phone number :");
            string phone=Console.ReadLine();

            foreach(var person in _personService.Save(name, surname, phone))
            {
                Console.WriteLine($"{person.Name} {person.Surname}-{person.Phone}");
            }

        }

        public void DeletePerson()
        {
            Console.WriteLine("Enter name or surname to delete:");
            string text = Console.ReadLine();
            List<Person> updatedList=_personService.Delete(text);
            if(updatedList.Count>0) 
            {
                foreach (var person in updatedList)
                {
                    Console.WriteLine($"{person.Name} {person.Surname} - {person.Phone}");
                }
            }
            else
            {
                Console.WriteLine("No data matching the criteria you were looking for was found in the guide.");
                Console.WriteLine("Please make a choice:");
                Console.WriteLine("1.To end deletion");
                Console.WriteLine("2.Try To Again");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("You have finished deleting.");
                        break;
                    case "2":
                        DeletePerson();
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }


        public void FindPerson()
        {
            Console.WriteLine("Search :");
            string text = Console.ReadLine();
            var datas = _personService.FindPerson(text);
           if(datas != null)
            {
                foreach(var data in datas)
                {
                    Console.WriteLine($"{data.Name} {data.Surname}-{data.Phone}");
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }


        public void UpdateContact()
        {
            Console.WriteLine("Enter Name or Surname: ");
            string text = Console.ReadLine();
            Console.WriteLine("Write new number :");
            string number=Console.ReadLine();
            var updatePerson = _personService.UpdatePerson(text,number);
            Console.WriteLine($"{updatePerson.Name} {updatePerson.Surname}-{updatePerson.Phone}");

        }


        public void SortContact()
        {
            Console.WriteLine("1.Sort the contact-A-Z:");
            Console.WriteLine("2.Sort the contact-Z-A:");
            Result: string result= Console.ReadLine();
            int selection;
            bool isSuccess=int.TryParse( result, out selection);

            if (selection >= 3)
            {
                Console.WriteLine("You don't have such a choice, please make the right choice.");
                goto Result;
            }


            if (isSuccess )
            {
                foreach (var person in _personService.SortContact(selection))
                {
                    Console.WriteLine($"{person.Name} {person.Surname}-{person.Phone}");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection");
            }
          
        }
    }
}
