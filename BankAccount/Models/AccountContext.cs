using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BankAccount.Models
{
    public class AccountContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
    public class AccountDbInitializer : DropCreateDatabaseAlways<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            Account a1 = new Account { Email = "fdbj@ds.net",Password="1234", Role="admin"};
            Account a2 = new Account { Email = "fdsdj@ds.net", Password = "123", Role = "user", Balance = 12, DateofRegistration = new DateTime (2014,2,11) };
            Account a3 = new Account { Email = "sdfsdj@ds.net", Password = "12343", Role = "user", Balance = 122, DateofRegistration = new DateTime(2014, 2, 10)};
            Account a4 = new Account { Email = "wdj@ds.net", Password = "1234", Role = "user", Balance = 100, DateofRegistration = new DateTime(2016, 4, 3) };
            Account a5 = new Account { Email = "sdf@ds.net", Password = "12343", Role = "user", Balance = 0, DateofRegistration = new DateTime(2015, 10, 2) };
            Account a6 = new Account { Email = "sdfsdj@ds.net", Password = "12343", Role = "user", Balance = 122, DateofRegistration = new DateTime(2014, 10, 2) };
            Account a7 = new Account { Email = "sdfsdj@e.net", Password = "12", Role = "user", Balance = 1, DateofRegistration = new DateTime(2013, 10, 2) };
            Account a8 = new Account { Email = "dcx@drt.net", Password = "12343", Role = "user", Balance = 156, DateofRegistration = new DateTime(2011, 10, 2) };
            Account a9 = new Account { Email = "esdj@ds.net", Password = "12222", Role = "user", Balance = 45, DateofRegistration = new DateTime(2014, 3, 3) };
            Account a10 = new Account { Email = "dffhjk@ds.net", Password = "41233", Role = "user", Balance = 89, DateofRegistration = new DateTime(2016, 12, 8) };
            Account a11 = new Account { Email = "sdfsdj@wwwq.net", Password = "34123", Role = "user", Balance = 221, DateofRegistration = new DateTime(2015, 11, 7) };
            Account a12 = new Account { Email = "jjkd@ds.net", Password = "143", Role = "user", Balance = 1232, DateofRegistration = new DateTime(2015, 11, 12) };
            Account a13 = new Account { Email = "sddfewq@ds.net", Password = "41323", Role = "user", Balance = 122, DateofRegistration = new DateTime(2012, 6, 4) };
            context.Accounts.Add(a1);
            context.Accounts.Add(a2);
            context.Accounts.Add(a3);
            context.Accounts.Add(a4);
            context.Accounts.Add(a5);
            context.Accounts.Add(a6);
            context.Accounts.Add(a7);
            context.Accounts.Add(a8);
            context.Accounts.Add(a9);
            context.Accounts.Add(a10);
            context.Accounts.Add(a11);
            context.Accounts.Add(a12);
            context.Accounts.Add(a13);

            Transaction t1 = new Transaction { Sum = 12, DateofPay=new DateTime (2014,12,2), AdminName= "fdbj@ds.net", Account=a2 };
            Transaction t2 = new Transaction { Sum = 122, DateofPay = new DateTime(2014, 2, 10), AdminName = "fdbj@ds.net", Account = a3 };
            Transaction t3 = new Transaction { Sum = 100, DateofPay = new DateTime(2016, 12, 7), AdminName = "fdbj@ds.net", Account = a4 };
            Transaction t4 = new Transaction { Sum = 1, DateofPay = new DateTime(2014, 12, 2), AdminName = "fdbj@ds.net", Account = a7 };
            Transaction t5 = new Transaction { Sum = 221, DateofPay = new DateTime(2016, 12, 2), AdminName = "fdbj@ds.net", Account = a11 };
            context.Transactions.AddRange(new List<Transaction> {t1, t2, t3, t4, t5 });

            base.Seed(context);
        }
    }
}