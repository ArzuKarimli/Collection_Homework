using App.Controller;
using Domain.Models;
using System.Diagnostics;


while (true)
{
    Console.WriteLine("CONTACT");

    Console.WriteLine("1.Save Phone Number");
    Console.WriteLine("2.Delete Phone Number");
    Console.WriteLine("3.Update Phone Number");
    Console.WriteLine("4.Contacts Listing (A-Z, Z-A selection)");
    Console.WriteLine("5.Search in Contacts");
    string selection = Console.ReadLine();
    PersonController personController = new PersonController();

    switch (selection)
    {
        case "1":
            personController.SaveNewPerson();
            break;
        case "2":
            personController.DeletePerson();

            break;
        case "3":
            personController.UpdateContact();
            break;
        case "4":
            personController.SortContact();
            break;
        case "5":
            personController.FindPerson();
            break;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
    Console.WriteLine("Press any key to continue...");
}
