using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPhoneTask
{
    abstract class Phone
    {
        protected int AccountIndex = 0;
        protected int ValidCallCount = 0;
        public string CurrentAccount { get; private set; }
        public string DeviceName { get; set; }
        public int Memory { get; set; }
        public string[] Accounts { get; set; }

        protected Phone(string deviceName)
        {
            DeviceName = deviceName;
        }

        public abstract void Call(string phoneNumber);

        public abstract void AddAccount(string accountName);

        public void PrintAllAccounts()
        {
            if (AccountIndex == 0)
            {
                Console.WriteLine("No user accounts to display");

                return;
            }

            for (int i = 0; i < AccountIndex; i++)
            {
                Console.WriteLine(Accounts[i]);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"JPhone is called ’{DeviceName}’, it has {Memory}GB of memoryand {AccountIndex} user accounts.");
            Console.WriteLine($"Valid call count:{ValidCallCount}");
            Console.WriteLine($"Current user account:{CurrentAccount}");
        }

        public void SetCurrentAccount(string currentAccount)
        {
            CurrentAccount = currentAccount;
        }

        public void DeleteAccount(string accountName)
        {

            //Ceyhun, Elvin, Kevin, Melik, Ankara  (Elvin)
            for (int i = 0; i < AccountIndex; i++)
            {
                if (Accounts[i] == accountName)
                {
                    for (int j = i; j < AccountIndex - 1; j++)
                    {
                        Accounts[j] = Accounts[j + 1];
                    }
                    Accounts[AccountIndex - 1] = default;
                    AccountIndex--;
                    Console.WriteLine($"Account ’{accountName}’ was deleted");
                    return;
                }
            }

        }
    }

    class JPhone : Phone
    {
        public JPhone(string deviceName) : base(deviceName)
        {
            Memory = 32;
            Accounts = new string[3];    
        }

        public override void AddAccount(string accountName)
        {
            if (AccountIndex >= Accounts.Length)
            {
                Console.WriteLine("You cannot add more accounts, limit is reached");

                return;
            }

            Accounts[AccountIndex++] = accountName;
            Console.WriteLine($"Account ’{accountName}’ was added");
        }

        public override void Call(string phoneNumber)
        {
            if (phoneNumber.Length >= 6 && phoneNumber.Length <= 8)
            {
                if (phoneNumber.StartsWith("4") || phoneNumber.StartsWith("6"))
                {
                    Console.WriteLine($"Calling to the number {phoneNumber}");
                    ValidCallCount++;
                    return;
                }
            }

            Console.WriteLine("Invalid number");
        }
    }

    class JPhonePro : Phone
    {
        public string ServiceTag {  get; set; }

        public JPhonePro(string deviceName, string serviceTag = "12345") : base(deviceName)
        {
            Memory = 64;
            Accounts = new string[5];
            ServiceTag = serviceTag;
        }

        public override void AddAccount(string accountName)
        {
            if (AccountIndex >= Accounts.Length)
            {
                Console.WriteLine("You cannot add more accounts, limit is reached");

                return;
            }

            Accounts[AccountIndex++] = accountName;
            Console.WriteLine($"Account ’{accountName}’ was added");
        }

        public override void Call(string phoneNumber)
        {
            if (phoneNumber.Length >= 6 && phoneNumber.Length <= 9)
            {
                if (phoneNumber.StartsWith("4") || phoneNumber.StartsWith("6"))
                {
                    Console.WriteLine($"Calling to the number {phoneNumber}");
                    ValidCallCount++;
                    return;
                }
            }

            Console.WriteLine("Invalid number");
        }

        public void PrintServiceTag()
        {
            Console.WriteLine($"Service tag is {ServiceTag}");
        }
    }
}
