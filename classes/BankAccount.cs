using System;

// namespace provides a way to logically organize code
namespace classes
{
    //public class BankAccount defines the class or type you're creating
    public class BankAccount
    {
        // public strings, decimal, voids are five members of the BankAccount class
        // these first three are properties - code validates/enforces rules
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get; }

        // these two are methods - blocks of code that perform a single function
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
        }
    }
}