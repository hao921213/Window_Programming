using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace E94111091_HW1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            Double money =10000;

            while (true) {
                Console.WriteLine("(0):查看餘額");
                Console.WriteLine("(1):提款");
                Console.WriteLine("(2):存款");
                Console.WriteLine("(3):轉帳");
                Console.WriteLine("(8):退出");
                Console.Write("請輸入要使用的功能:");
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("請輸入整數\n");
                    continue;
                }
                

                if (option == 0)
                {
                    Console.WriteLine("目前餘額為:{0}\n", money);
                }

                else if (option == 1)
                {
                    int Withdraw_money;
                    Console.Write("請輸入提款金額:");
                    try
                    {
                        Withdraw_money = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("請輸入整數\n");
                        continue;
                    }
                    if (Withdraw_money < 0 || Withdraw_money > 100000)
                    {
                        Console.WriteLine("金額不在範圍內，請回到功能選單並輸入0-100000。\n");
                        continue;
                    }
                    else if (Withdraw_money > money)
                    {
                        Console.WriteLine("餘額不足，請回選單重新操作。\n");
                        continue;
                    }
                    else
                    {
                        money -= Withdraw_money;
                        Console.WriteLine("提款成功\n");
                        Console.WriteLine("提款完金額為:{0}元\n", money);
                    }
                }

                else if(option == 2)
                {
                    int Save_money;
                    Console.Write("請輸入存款金額:");
                    
                    try
                    {
                        Save_money = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("請輸入整數\n");
                        continue;
                    }
                    if (Save_money < 0 || Save_money > 100000)
                    {
                        Console.WriteLine("金額不在範圍內，請回到功能選單並輸入0-100000。\n");
                        continue;
                    }
                    else
                    {
                        money += Save_money;
                        Console.WriteLine("存款成功\n");
                        Console.WriteLine("存款完金額為:{0}元\n", money);
                    }
                }

                else if (option == 3)
                {
                    Double Transfer_money;
                    Double fee = 1.1;
                    Double total_transfer_money;
                    int account;
                    Console.Write("請輸入轉入帳號:");
                    
                    try
                    {
                        account = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("請輸入整數\n");
                        continue;
                    }
                    Console.Write("請輸入轉入金額:");
                    
                    try
                    {
                        Transfer_money = Double.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("請輸入整數\n");
                        continue;
                    }
                    total_transfer_money = fee* Transfer_money;
                    if (Transfer_money < 0 || Transfer_money > 100000)
                    {
                        Console.WriteLine("金額不在範圍內，請回到功能選單並輸入0-100000。\n");
                        continue;
                    }
                    else if (money < total_transfer_money)
                    {
                        Console.WriteLine("餘額不足，請回選單重新操作。\n");
                        continue;
                    }
                    else
                    {
                        money -= total_transfer_money;
                        money = Math.Floor(money);
                        Console.WriteLine("轉出金額(10%手續費):{0}",total_transfer_money);
                        Console.WriteLine("轉帳成功\n");
                        Console.WriteLine("轉帳完金額為(10%手續費):{0}元\n", money);
                    }
                }
                else if (option == 8)
                {
                    Console.WriteLine("結束服務，謝謝");
                    break;
                }

                else
                {
                    Console.WriteLine("請依照指示輸入。\n");
                }
            }
            





        }
    }
}
