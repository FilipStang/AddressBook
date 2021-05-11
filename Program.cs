using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //list person
            var personlist = new List<Person>();
            string strFilePath = "";
            bool menu = true;
            string[] contactInfo = new string[4];
            do
            {
                Console.WriteLine("******Welcome to my address book program*********");
                Console.WriteLine("*************************************************");
                Console.WriteLine("*Press 1 to Add an entry to the address book    *");
                Console.WriteLine("*Press 2 to Remove any entry in the address book*");
                Console.WriteLine("*Press 3 to Print the book to the screen        *");
                Console.WriteLine("*Press 4 to Save addressbook                    *");
                Console.WriteLine("*Press 5 to Exit                                *");
                Console.WriteLine("*************************************************");
                Console.Write(">");
                string choice = "USER CHOICE";
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Add new contact !");
                        Console.WriteLine("Please Enter your name");
                        string input = Console.ReadLine();
                        contactInfo[0] = input;
                        //------------------------------------------------
                        Console.WriteLine("Please Enter your address");
                        input = Console.ReadLine();
                        contactInfo[1] = input;
                        //----------------------------------------------
                        Console.WriteLine("Please Enter your Email");
                        input = Console.ReadLine();
                        contactInfo[2] = input;
                        //----------------------------------------------
                        Console.WriteLine("Please Enter your Telephone number");
                        input = Console.ReadLine();
                        contactInfo[3] = input;
                        //--------------------------------------------------
                        personlist.Add(new Person(contactInfo[0], contactInfo[1], contactInfo[2], contactInfo[3]));
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Remove contact ");
                        Console.WriteLine("Type the contact's name.");
                        string contactTobeRemoved = Console.ReadLine();
                        
                        //*https://social.msdn.microsoft.com/Forums/vstudio/en-US/c91c66f9-c1e7-4036-8a22-2101620bca7b/how-to-delete-a-line-from-the-file-using-c
                        string[] Lines = File.ReadAllLines("C:\\Users\\Filip\\source\\repos\\CskapBasic\\PROGMET\\AddressList\\AddressBook\\Entries.lis");
                        File.Delete("C:\\Users\\Filip\\source\\repos\\CskapBasic\\PROGMET\\AddressList\\AddressBook\\Entries.lis");// Deleting the file
                        using (StreamWriter sw = File.AppendText("C:\\Users\\Filip\\source\\repos\\CskapBasic\\PROGMET\\AddressList\\AddressBook\\Entries.lis"))

                        {
                            foreach (string line in Lines)
                            {
                                if (line.IndexOf(contactTobeRemoved) >= 0)
                                {
                                    //Skip the line
                                    continue;
                                }
                                else
                                {
                                    sw.WriteLine(line);
                                }
                            }
                        }
                        //-------------END*
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Here is a list of the saved entries that you have entered so far");
                        Console.WriteLine("******************************************************************************");
                        strFilePath = "C:\\Users\\Filip\\source\\repos\\CskapBasic\\PROGMET\\AddressList\\AddressBook\\Entries.lis";
                        using (StreamReader reader = new StreamReader(strFilePath))
                        {
                            string line;
                            Console.WriteLine("Name;Address;Email;Telephone");
                            Console.WriteLine("************************************");
                            while ((line = reader.ReadLine()) != null)                            // Read line by line  
                            {
                                Console.WriteLine(line);
                                Console.WriteLine("-------------------------------");
                            }
                        }
                        Console.WriteLine("******************************************************************************");
                        break;
                    case "4":
                        Console.Clear();
                        using (StreamWriter writer = new StreamWriter(@"C:\Users\Filip\source\repos\CskapBasic\PROGMET\AddressList\AddressBook\Entries.lis"))
                        {
                            for (int i = 0; i < personlist.Count; i++)
                            {
                                writer.WriteLine(personlist[i].Name + ";" + personlist[i].Address + ";" + personlist[i].Email + ";" + personlist[i].Telephone);
                            }
                        }
                        Console.WriteLine("Contact saved");
                        Console.WriteLine("******************************************************************************");
                        break;
                    case "5":
                        Console.Clear();
                        menu = false;
                        Console.WriteLine("Bye!!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You typed {0}", choice);
                        Console.WriteLine("The choice you made isn't valid, please try again.");
                        break;
                }
            }
            while (menu);

        }
    }

}

