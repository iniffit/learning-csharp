using System;
using System.Collections.Generic;

// namespace provides a way to logically organize code
namespace classes
{
    //public class BankAccount defines the class or type you're creating
    public class BankAccount
    {
        // data member that kicks off the account number sequence. 
        // it's private, so only code inside this class can access it
        // it's static, so it's shared by all BankAccount objects
        private static int accountNumberSeed = 1234567890;

        // public strings, decimal, voids are five members of the BankAccount
        // class these first three are properties - code validates/enforces rules
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        // this is a constructor - a member used to initialize objects of the class type.
        // has same name as the class.
        public BankAccount(string name, decimal intialBalance)
        {
            this.Owner = name;
            MakeDeposit(intialBalance, DateTime.Now, "Initial Balance");

            this.Balance = intialBalance;
            
            // incremints account number up by one for each account created.
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        private List<Transaction> allTransactions = new List<Transaction>();
        
        
        // these two are methods - blocks of code that perform a single function
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient fund for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
    }
}