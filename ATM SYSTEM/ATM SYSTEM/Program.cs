using System;

namespace ATM_SYSTEM
{
    // Abstract Class
    abstract class BankAccount
    {
        protected decimal balance;

        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount); 

        public virtual void BalanceInquiry()
        {
            Console.WriteLine($"\nCurrent Balance: ₱{balance:F2}");
        }
    }

    // Derived Class
    class ATMAccount : BankAccount
    {
        public override void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Successfully deposited ₱{amount:F2}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public override void Withdraw(decimal amount)
        {
            if (balance == 0)
            {
                Console.WriteLine("Withdrawal not allowed. No available balance.");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Withdrawal exceeds available balance.");
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"Successfully withdrawn ₱{amount:F2}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ATMAccount account = new ATMAccount();
            int choice;

            do
            {
                Console.WriteLine("\n===== ATM MENU =====");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Balance Inquiry");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter deposit amount: ₱");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            account.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case 2:
                        Console.Write("Enter withdrawal amount: ₱");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        {
                            account.Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case 3:
                        account.BalanceInquiry();
                        break;

                    case 4:
                        Console.WriteLine("Thank you for using the ATM System.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1-4.");
                        break;
                }

            } while (choice != 4);
        }
    }
}