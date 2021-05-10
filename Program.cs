using System;
using System.Collections.Generic;
using System.IO;

namespace AddressBook
{
    class Program
    {

        public static void DeleteLinesFromFile(string strLineToDelete)
        {
            //https://stackoverflow.com/questions/1245243/delete-specific-line-from-a-text-file
            string strFilePath = "C:\\Users\\Filip\\source\repos\\CskapBasic\\PROGMET\\AddressList\\AddressBook\\TextFile1.txt";
            string strSearchText = strLineToDelete;
            string strOldText;
            string n = "";
            StreamReader sr = File.OpenText(strFilePath);
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (!strOldText.Contains(strSearchText))
                {
                    n += strOldText + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(strFilePath, n);
        }

        static void Main(string[] args)
        {
            //list person
            var personlist = new List<Person>();
            string name = "NAME";
            string address = "ADDRESS";
            string email = "EMAIL";
            string telephone = "TELEPHONE";
            bool menu = true;
            //                                                                              
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
                string choice = "USER CHOICE";
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Add new contact !");
                        Console.WriteLine("Please Enter your name");
                        string input = Console.ReadLine();
                        name = input;
                        //------------------------------------------------
                        Console.WriteLine("Please Enter your address");
                        input = Console.ReadLine();
                        address = input;
                        //----------------------------------------------
                        Console.WriteLine("Please Enter your Email");
                        input = Console.ReadLine();
                        email = input;
                        //----------------------------------------------
                        Console.WriteLine("Please Enter your Telephone number");
                        input = Console.ReadLine();
                        telephone = input;
                        //--------------------------------------------------
                        personlist.Add(new Person(name, address, telephone, email));
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Remove contact ");
                        Console.WriteLine("Type the contact's name.");
                        string contactName = Console.ReadLine();
                        DeleteLinesFromFile(contactName);

                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Here is a list of the stored contacts that you have entered so far");
                        Console.WriteLine("******************************************************************************");
                        #region OLD
                        //foreach (Person p in personlist)
                        //{
                        //    Console.WriteLine("Name: " + p.Name + "\n" +
                        //                      "Address: " + p.Address + "\n" +
                        //                      "Telephone number: " + p.Telephone + "\n" +
                        //                      "Email: " + p.Email + "\n");
                        //    Console.WriteLine("------------------");
                        //} 
                        #endregion
                        string strFilePath = "C:\\Users\\Filip\\source\\repos\\CskapBasic\\PROGMET\\AddressList\\AddressBook\\TextFile1.txt";
                        using (StreamReader reader = new StreamReader(strFilePath))
                        {
                            string line;
                            // Read line by line  
                            Console.WriteLine("Name;Address;Telephone;Email");
                            Console.WriteLine("************************************");
                            while ((line = reader.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                                Console.WriteLine("-------------------------------");
                            }
                        }

                        Console.WriteLine("******************************************************************************");
                        break;
                    case "4":
                        Console.Clear();
                        StreamWriter writer = new StreamWriter(@"C:\Users\Filip\source\repos\CskapBasic\PROGMET\AddressList\AddressBook\TextFile1.txt"); // Create a new file.
                        writer.Write(name + ";" + address + ";" + telephone + ";" + email + "\n");
                        writer.Close(); 
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
