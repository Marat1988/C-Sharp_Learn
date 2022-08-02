using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        delegate int Operation(int x, int y); //Объявление делегата
        delegate void Handler(string message);
        class Account
        {
            private int _sum;
            private Handler _del;
            public Account(int sum)
            {
                _sum = sum;
            }
            public void registerHandler(Handler del)
            {
                _del += del;
            }
            public void unRegisterHandler(Handler del)
            {
                _del -= del;
            }
            public void Put(int sum)
            {
                _sum += sum;
                if (_del != null)
                    _del($"На ваш счет поступило {sum}");
            }

            public void withDraw(int sum)
            {
                if (_sum >= sum)
                {
                    _sum -= sum;
                    if (_del != null)
                        _del($"С вашего счета снято {sum}");
                }
                else
                {
                    if (_del != null)
                        _del($"На счете недостаточно средств");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Result(3, 4, new Operation(Sum)));
            Console.WriteLine(Result(3, 4, new Operation(Mult)));
            Account account = new Account(100);
            account.registerHandler(Message);
            account.registerHandler(colorMessage);
            account.Put(150);
            account.Put(50);
            account.withDraw(100);
            account.unRegisterHandler(colorMessage);
            account.withDraw(400);
            Console.ReadKey();
        }
        static int Result(int x, int y, Operation operation) //Передача делегата в качестве параметра в функцию
        {
            return operation(x, y);
        }
        static int Sum(int x, int y)
        {
            return x + y;
        }
        static int Mult(int x, int y)
        {
            return x * y;
        }
        static void Message(string message)
        {
            Console.WriteLine(message);
        }
        static void colorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
