using System;
    class Company
    {
        class Manager
        {
            private string firstName;
            private string lastName;
            private int age;
            private int phoneNumber;

            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }

            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }

            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            public int PhoneNumber
            {
                get { return phoneNumber; }
                set { phoneNumber = value; }
            }
        }
        static void Main()
        {
            Console.Title = "Exericises 3.";

            uint companyPhoneNumber;

            Console.Write("Enter company name: ");
            string companyName = Console.ReadLine();

            Console.Write("Enter adress: ");
            string companyAdress = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string comPN = Console.ReadLine();
            uint.TryParse(comPN, out companyPhoneNumber);

            Console.Write("Enter web site: ");
            string companyWebSite = Console.ReadLine();

            Manager projecManager = new Manager();
            Console.Write("Enter first name of the manager: ");
            projecManager.FirstName = Console.ReadLine();

            Console.Write("Enter last name of the manager: ");
            projecManager.LastName = Console.ReadLine();

            Console.Write("Ënter Age of the manager: ");
            projecManager.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter phone number: ");
            projecManager.PhoneNumber = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Company info:");
            Console.WriteLine("Company name: {0} Address: {1} Phone number: {2} Web site: {3} \n\rManager's info: Manager's name: {4} {5} Age: {6} Phone number: {7}",companyName, companyAdress, companyPhoneNumber, companyWebSite, projecManager.FirstName, projecManager.LastName, projecManager.Age, projecManager.PhoneNumber );
        }
    }
/*
A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. Write a program that reads the information about a company and its manager and prints them on the console.
*/