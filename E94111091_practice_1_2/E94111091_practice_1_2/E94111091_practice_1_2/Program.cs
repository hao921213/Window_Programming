using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace E94111091_practice_1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            Double money = 10000;
            Double point = 0;
            int[] record_code = new int[100];
            Double[] recode_money = new Double[100];
            int index = 0;

            int[] account=new int[100];
            Double[] account_money = new Double[100]; 
            int account_index = 10;
            int my_account_index = 0;
            for (int i = 0; i < 10; i++)
            {
                account[i] = 10000 + 1000 * i;
                account_money[i] = 10000;
            }

            int my_account = 0;

            while (true)
            {
                
                bool exist = false;
                int current_money = 10000;
                Console.Write("請輸入您的帳號:");
                try
                {
                    my_account = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("請輸入整數\n");
                    continue;
                }

                if(my_account<10000 || my_account >= 100000)
                {
                    Console.WriteLine("帳號須為五位數\n");
                    continue;
                }

                for (int i = 0; i < account.Length; i++)
                {
                    if (account[i] == my_account)
                    {
                        exist = true;
                        break;
                    }
                }
                if (exist)
                {
                    Console.WriteLine("帳號已存在\n");
                    continue;
                }
                else
                {
                    Console.WriteLine("建立帳號成功");
                    Console.WriteLine("你的帳號為:{0}",my_account);
                    Console.WriteLine("金額為:{0}",current_money);
                    account[account_index] = my_account;
                    account_money[account_index] = current_money;
                    my_account_index = account_index;
                    account_index++;

                    break;
                }

            }
            while (true)
            {
                bool exist= false;
                Console.WriteLine("(0):查看餘額");
                Console.WriteLine("(1):提款");
                Console.WriteLine("(2):存款");
                Console.WriteLine("(3):轉帳");
                Console.WriteLine("(4)愛心捐款");
                Console.WriteLine("(5)歷史紀錄");
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
                    Console.WriteLine("目前餘額為:{0}\n", account_money[my_account_index]);
                    record_code[index] = option;
                    recode_money[index] = account_money[my_account_index];
                    index += 1;
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
                    else if (Withdraw_money > account_money[my_account_index])
                    {
                        Console.WriteLine("餘額不足，請回選單重新操作。\n");
                        continue;
                    }
                    else
                    {
                        account_money[my_account_index] -= Withdraw_money;
                        Console.WriteLine("提款成功\n");
                        Console.WriteLine("提款完金額為:{0}元\n", account_money[my_account_index]);
                        record_code[index] = option;
                        recode_money[index] = account_money[my_account_index];
                        index += 1;

                    }
                }

                else if (option == 2)
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
                        account_money[my_account_index] += Save_money;
                        Console.WriteLine("存款成功\n");
                        Console.WriteLine("存款完金額為:{0}元\n", account_money[my_account_index]);
                        record_code[index] = option;
                        recode_money[index] = account_money[my_account_index];
                        index += 1;
                    }
                }

                else if (option == 3)
                {
                    Double Transfer_money;
                    Double fee = 1.1;
                    Double total_transfer_money;
                    int transfer_account;
                    int current_index = 0;
                    Console.Write("請輸入轉入帳號:");

                    try
                    {
                        transfer_account = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("請輸入整數\n");
                        continue;
                    }
                    if (transfer_account < 10000 || transfer_account >= 100000)
                    {
                        Console.WriteLine("帳號須為五位數");
                        continue;
                    }
                    if (transfer_account == my_account) 
                    {
                        Console.WriteLine("不能轉入自己的帳號");
                        continue;
                    }

                    for (int i = 0; i < account.Length; i++)
                    {
                        if (account[i] == transfer_account)
                        {
                            exist = true;
                            current_index = i;
                            break;
                        }
                    }
                    if (!exist)
                    {
                        int create=0;
                        Console.WriteLine("此帳號不存在，是否要創建此帳號(1為是，0為否)");

                        try
                        {
                            create = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("請輸入整數\n");
                            continue;
                        }

                        if (create != 0 &&  create != 1)
                        {
                            Console.WriteLine("請輸入0或1");
                            continue;
                        }
                        else if (create == 0)
                        {
                            Console.WriteLine("創建帳號失敗");
                            continue;
                        }
                        else if(create == 1)
                        {
                            Console.WriteLine("創建帳號成功");
                            account[account_index] = transfer_account;
                            account_money[account_index] = 0;
                            current_index = account_index;
                            account_index++;

                        }
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
                    total_transfer_money = fee * Transfer_money;
                    if (Transfer_money < 0 || Transfer_money > 100000)
                    {
                        Console.WriteLine("金額不在範圍內，請回到功能選單並輸入0-100000。\n");
                        continue;
                    }
                    else if (account_money[my_account_index] < total_transfer_money)
                    {
                        Console.WriteLine("餘額不足，請回選單重新操作。\n");
                        continue;
                    }
                    else  
                    {
                        int use_point;
                        Console.WriteLine("是否使用愛心點數(1為是，0為否)");
                        try
                        {
                            use_point = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("請輸入整數\n");
                            continue;
                        }

                        if (use_point != 0 && use_point != 1)
                        {
                            Console.WriteLine("請輸入0或1");
                            continue;
                        }
                        
                        else if (use_point == 0 )
                        {
                            account_money[my_account_index] -= total_transfer_money;
                            account_money[my_account_index] = Math.Floor(account_money[my_account_index]);
                            Console.WriteLine("轉出金額(10%手續費):{0}", total_transfer_money);
                            Console.WriteLine("轉帳成功\n");
                            Console.WriteLine("轉帳完金額為(10%手續費):{0}元\n", account_money[my_account_index]);
                            record_code[index] = option;
                            recode_money[index] = account_money[my_account_index];
                            index += 1;

                        }
                        else if(use_point==1)
                        {
                            if (point <= 0)
                            {
                                Console.WriteLine("無愛心點數可使用");
                                continue;
                            }
                            else
                            {
                                account_money[my_account_index] -= Transfer_money;
                                point -= 1;
                                Console.WriteLine("轉出金額(無10%手續費):{0}", Transfer_money);
                                Console.WriteLine("轉帳成功\n");
                                Console.WriteLine("轉帳完金額為:{0}元\n", account_money[my_account_index]);
                                record_code[index] = option;
                                recode_money[index] = account_money[my_account_index];
                                index += 1;
                            }
                            
                        }

                        account_money[current_index] += Transfer_money;
                    }
                }

                else if (option == 4) 
                {
                    Double donate_money=0;
                    
                    Console.Write("愛心捐款金額(每1000元則得一點愛心點數):");
                    try
                    {
                        donate_money = Double.Parse(Console.ReadLine());
                        
                    }
                    catch
                    {
                        Console.WriteLine("請輸入整數\n");
                        continue;
                    }

                    if (donate_money <0 || donate_money > 100000)
                    {
                        Console.WriteLine("金額不在範圍內，請回到功能選單並輸入0-100000。\n");
                        continue;
                    }
                    else if(account_money[my_account_index] < donate_money)
                    {
                        Console.WriteLine("餘額不足，請回選單重新操作。\n");
                        continue;
                    }
                    else
                    {
                        point = Math.Floor(donate_money / 4);
                        account_money[my_account_index] -= donate_money;
                        Console.WriteLine("捐款完後剩餘{0}元", account_money[my_account_index]);
                        record_code[index] = option;
                        recode_money[index] = account_money[my_account_index];
                        index += 1;
                    }
                        

                }
                else if (option == 5)
                {
                    for(int i = 0; i < index; i++)
                    {
                        Console.WriteLine("{0} - {1}", record_code[i], recode_money[i]);
                    }

                    record_code[index] = option;
                    recode_money[index] = account_money[my_account_index];
                    index += 1;
                }
                else if (option == 65304)
                {
                    for(int i = 0; i < account_index; i++)
                    {
                        Console.WriteLine("{0} - {1}", account[i], account_money[i]);
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
