using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private string _filePath;

        public FileAccountRepository(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("AccountNumber,Name,Balance,Type");
                    writer.WriteLine("11111,Free Customer,100,F");
                    writer.WriteLine("22222,Basic Customer,500,B");
                    writer.WriteLine("33333,Premium Customer,1000,P");
                }
            }

            _filePath = filePath;
        }

        public Account _account = new Account();

        public Account LoadAccount(string AccountNumber)
        {
            if(File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);

                List<Account> accounts = new List<Account>();

                
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] colomns = lines[i].Split(',');

                        Account a = new Account();

                        a.AccountNumber = colomns[0];
                        a.Name = colomns[1];
                        a.Balance = decimal.Parse(colomns[2]);

                        if (colomns[3] == "B")
                            a.Type = AccountType.Basic;
                        else if (colomns[3] == "F")
                            a.Type = AccountType.Free;
                        else
                            a.Type = AccountType.Premium;

                        accounts.Add(a);
                    }
                

                foreach(var account in accounts)
                {
                    if (AccountNumber == account.AccountNumber)
                    {
                        _account = account;

                        return account;
                    }                   
                }                
            }
            else
            {
                Console.WriteLine("Could not find file at {0}", _filePath);
            }

            return null;
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
