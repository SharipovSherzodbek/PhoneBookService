using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Collections.Generic;

namespace Lessim
{   
    class PhoneService
    {
        List<string> phoneList = new List<string>();
        List<string> nameList = new List<string>();
        public void PhoneBook()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("\n\tHere is some options:");
                    Console.WriteLine("1.Add contacts");
                    Console.WriteLine("2.Delete contacts");
                    Console.WriteLine("3.Edit contacts");
                    Console.WriteLine("4.View all contacts");
                    Console.WriteLine("5.View contacts with names");
                    Console.WriteLine("6.Save contacts to file");
                    Console.WriteLine("7.Exit");

                    int option;
                    if (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Error: Please enter a valid integer!");
                        continue;
                    }

                    switch (option)
                    {
                        case 1:
                            AddContact();
                            break;
                        case 2:
                            DeleteContact();
                            break;
                        case 3:
                            EditContact();
                            break;
                        case 4:
                            ViewContacts();
                            break;
                        case 5:
                            ViewContactsWithNames();
                            break;
                        case 6:
                            SaveContactsToFile();
                            break;
                        case 7:
                            Console.WriteLine("Exiting program...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice! Please enter a number between 1 and 6");
                            break;
                    }
                }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }

        private void AddContact()
        {
            Console.Clear();
            Console.WriteLine("Enter contact number...");
            string contacts = Console.ReadLine();

            Console.WriteLine("Enter name...");
            string addName = Console.ReadLine();

            if (string.IsNullOrEmpty(contacts) || string.IsNullOrEmpty(addName))
            {
                Console.WriteLine("Error: Contact number and name cannot be empty!");
                return;
            }

            phoneList.Add(contacts);
            nameList.Add(addName);
            Console.WriteLine("Contact added successfully!");
        }

        private void DeleteContact()
        {
            Console.Clear();
            if (phoneList.Count > 0)
            {
                Console.WriteLine("Choose the contact to delete:");
                ViewContactsWithNames();

                int index;
                if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > phoneList.Count)
                {
                    Console.WriteLine("Please enter a valid integer!");
                    return;
                }
                phoneList.RemoveAt(index - 1);
                nameList.RemoveAt(index - 1);
                Console.WriteLine("Contact deleted successfully!");
            }
            else
            {
                Console.WriteLine("You have no saved contacts");
            }
        }
        private void EditContact()
        {
            Console.Clear();
            if (phoneList.Count > 0)
            {
                Console.WriteLine("Choose the contact to edit...");
                ViewContactsWithNames();

                int index;
                if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > phoneList.Count)
                {
                    Console.WriteLine("Please enter a valid integer!");
                    return;
                }
                Console.WriteLine("Edit a name....");
                string editedName = Console.ReadLine();

                if (string.IsNullOrEmpty(editedName))
                {
                    Console.WriteLine("Eror: Name cannot be empty!");
                }
                nameList[index - 1] = editedName;


                Console.WriteLine("Edit a contact...");
                string editedContact = Console.ReadLine();

                if (string.IsNullOrEmpty(editedContact))
                {
                    Console.WriteLine("Eror: Name cannot be empty!");
                }
                phoneList[index - 1] = editedContact;
                Console.WriteLine("Contact edited successfully!");
            }
            else
            {
                Console.WriteLine("You have no saved contacts!");
            }
        }

        private void ViewContacts()
        {
            Console.Clear();
            if (phoneList.Count > 0)
            {
                Console.WriteLine("Here is your contacts:");

                for (int i = 0; i < phoneList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{phoneList[i]}");
                }
            }
            else
            {
                Console.WriteLine("You have no saved contacts");
            }

        }

        private void ViewContactsWithNames()
        {
            Console.Clear();
            if (phoneList.Count > 0)
            {
                Console.WriteLine("Here is your contacts:");

                for (int i = 0; i < phoneList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{nameList[i]} -> {phoneList[i]}");
                }
            }
            else
            {
                Console.WriteLine("You have no saved contacts");
            }
        }
        private void SaveContactsToFile()
        {
            Console.Clear();
            List<string> contactsWithName = new List<string>();

            for (int i = 0; i < nameList.Count; i++)
            {
                contactsWithName.Add("Name: " + nameList[i] + "\tPhone number: " + phoneList[i]);
            }

            string filePath = @"E:\Coding\Visual Studio\SavingFile\contacts.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string contact in contactsWithName)
                {
                    writer.WriteLine(contact);
                }
            }
            Console.WriteLine("Contacts saved successfully!");
        }
    }      
    
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to PhoneBook Service!");

            PhoneService phoneService = new PhoneService();
            phoneService.PhoneBook();

        }
    }
}