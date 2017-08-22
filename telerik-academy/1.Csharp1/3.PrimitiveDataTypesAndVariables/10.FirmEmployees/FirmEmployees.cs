using System;
    class FirmEmployees
    {
        static void Main()
        {
            //first, family name,age,gender,id,employeeNumber
            string firstName = "Ivan";
            string familyName = "Ivanov";
            byte age = 18;
            char gender = 'm';
            int idNumber = 6401234;
            int employeeNumber = 127561234;
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Family name: " + familyName);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("gender: " + gender);
            Console.WriteLine("ID number: " + idNumber);
            Console.WriteLine("Employee number" + employeeNumber);
        }
    }
    /*
     A marketing firm wants to keep record of its employees. Each record would have the following characteristics – first name, family name, age, gender (m or f), ID number, unique employee number (27560000 to 27569999). Declare the variables needed to keep the information for a single employee using appropriate data types and descriptive names.

     */