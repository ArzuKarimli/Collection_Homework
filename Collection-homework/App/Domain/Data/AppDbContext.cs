using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public static class AppDbContext
    {

        public static List<Person> People()
        {
            return new List<Person> {
                new Person("Omer", "Kerimli", "055-666-55-44"),
                new Person("Arzu", "Kerimli", "051-408-79-98"),
                new Person("Ayşe", "Eliyeva", "050-555-44-33"),
                new Person("Fatma", "Esedova", "070-999-88-77"),
                new Person("Feride", "Mirzeyeva", "099-777-66-55")
            };
        }
    }
}
