using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        delegate void Handler(object sender, AccountEventArgs e);

        class AccountEventArgs
        {
            public string Message { get; }
            public int Sum { get; }
            public AccountEventArgs(string message, int sum)
            {
                Message = message;
                Sum = sum;
            }
        }

        class Account
        {
            private int _sum;
            public event Handler added;
            public event Handler adding;
            public event Handler withDrawn;
            public Account(int sum) => this._sum = sum;
            public void Put(int sum) {
                adding?.Invoke(this, new AccountEventArgs($"На ваш счет поступает сумма {sum} рублей", sum));
                _sum += sum;
                added?.Invoke(this, new AccountEventArgs($"На ваш счет поступило {sum} рублей", sum));
            }
            public void WithDraw(int sum) => withDrawn?.Invoke(this, _sum >= sum ? new AccountEventArgs($"С вашего счета списано {sum} рублей", sum) :
                                                                        new AccountEventArgs("На вашем счете недостаточно средств", sum));
        }

        static void Main(string[] args)
        {
            Account account = new Account(200);
            account.added += Message;
            account.withDrawn += Message;
            account.Put(300);
            account.Put(400);
            account.WithDraw(400);
            account.WithDraw(1000);
            account.WithDraw(2000);
            Console.ReadKey();
        }

        static void Message(object sender, AccountEventArgs e) => Console.WriteLine(e.Message);
  
    }
}
