using System.Globalization;

namespace LocksAndMonitor
{
    internal class Account
    {
        private decimal Balance { get; set; }
        private Random Rdm { get; set; } = new ();

        public Account(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        void Withdraw(decimal amount)
        {
            // use a monitor to lock the object
            Monitor.Enter(this);

            if (Balance < amount)
            {
                Console.WriteLine("Withdrawal not authorized: Insufficient funds. Trying to withdraw {1,6:C} Balance: {0,6:C}", Balance.ToString("C2", new CultureInfo("en-US")), amount.ToString("C2", new CultureInfo("en-US")));
                return;
            }

            Console.WriteLine($"Task {Task.CurrentId} is about to withdraw {amount.ToString("C", new  CultureInfo("en-US"))}");

            try
            {
                if (Balance >= amount)
                {
                    Console.WriteLine("Withdrawal authorized: {0,6:C}", amount.ToString("C2", new CultureInfo("en-US")));
                    
                    Console.WriteLine("Balance before withdrawal: {0,6:C}", Balance.ToString("C2", new CultureInfo("en-US")));

                    Balance -= amount;

                    Console.WriteLine("Balance after withdrawal: {0,6:C}", Balance.ToString("C2", new CultureInfo("en-US")));
                    
                    Console.WriteLine("--------------------------");
                }
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        public void RandomWithdrawal()
        {
            for (int i = 0; i < 100; i++)
            {
               Withdraw(Rdm.Next(1, 100));
            }
        }
    }
}
