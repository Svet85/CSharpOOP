using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] accountsInfo = Console.ReadLine().Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            for (int i = 0; i < accountsInfo.Length; i += 2)
            {
                int accountNumber = int.Parse(accountsInfo[i]);
                double accountSum = double.Parse(accountsInfo[i + 1]);
                accounts.Add(accountNumber, accountSum);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmd = input.Split();

                try
                {
                    AccountManipulation(cmd, accounts);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                input = Console.ReadLine();
            }
        }

        public static void AccountManipulation(string[] cmd, Dictionary<int, double> accounts)
        {
            string action = cmd[0];
            int accNum = int.Parse(cmd[1]);
            double sum = double.Parse(cmd[2]);

            if (action == "Deposit")
            {
                if (!accounts.ContainsKey(accNum))
                {
                    throw new ArgumentException("Invalid account!");
                }

                accounts[accNum] += sum;
            }
            else if (action == "Withdraw")
            {
                if (!accounts.ContainsKey(accNum))
                {
                    throw new ArgumentException("Invalid account!");
                }

                if (accounts[accNum] < sum)
                {
                    throw new ArgumentException("Insufficient balance!");
                }

                accounts[accNum] -= sum;
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }


            Console.WriteLine($"Account {accNum} has new balance: {accounts[accNum]:f2}");
        }
    }
}
