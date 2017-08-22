using System;
    class BankAccountHolder
    {
        static void Main(string[] args)
        {
            string firstName = "Ivan";
            string middleName = "Ivanov";
            string lastName = "Georgiev";
            decimal bankBalance = 13976.65m;
            string iban = "BG12340STS12345678900";
            string bicCode = "ABC1234DFT6";
            long accountNumber = 1234123456785678;
            Console.WriteLine(firstName + " " + middleName + " " + lastName);
            Console.WriteLine(" " + bankBalance + " " + iban + " " + bicCode + " " + accountNumber);

        }
    }
    /*
     A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, BIC code and 3 credit card numbers associated with the account. Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.

     */