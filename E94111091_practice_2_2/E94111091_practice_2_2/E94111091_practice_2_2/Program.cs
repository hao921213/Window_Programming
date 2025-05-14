using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace E94111091_practice_2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option=0;
            string[] purchase = new string[100];
            string[] money = new string[100];
            string[] amount = new string[100];
            int[] buy = new int[200];
            int[] buy_index = new int[200];
            string[] buyer = new string[200];
            Double[,] buy_record=new Double[200,200];
            Double income = 0;
            int buyer_index=0;
            int index = 0;

            int been_opened = 0;

            Random rand = new Random();

            while (true)
            {
                Console.WriteLine("歡迎來到 NCKU 卡比商店交易系統");
                Console.WriteLine("======================================");
                Console.WriteLine("(1) 開店");
                Console.WriteLine("(2) 新增訂單");
                Console.WriteLine("(3) 查詢庫存");
                Console.WriteLine("(4) 查詢總收入");
                Console.WriteLine("(5) 計算人氣商品排名");
                Console.WriteLine("(6) 關店");
                Console.WriteLine("======================================");
                Console.Write("請輸入您現在想要進行的操作: ");
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception e) {
                    Console.WriteLine("請輸入整數");
                    continue;
                  }

                if (option <= 0 || option > 6)
                {
                    Console.WriteLine("請輸入1-6");
                    continue;
                }
                

                if (option == 1 && been_opened==0)
                {
                    int quantity;
                    string temp1, temp2, temp3;
                    int has_continued = 0;


                    Console.Write("請輸入今日總共有幾種商品要販售: ");
                    try
                    {
                        quantity = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("商品數量須為整數，開店失敗");
                        continue;
                    }

                    if(quantity <= 0)
                    {
                        Console.WriteLine("商品數量需大於零，開店失敗");
                        continue;
                    }

                    Console.Write("請依序輸入每一種商品的名稱: ");
                    temp1 = Console.ReadLine();
                    string[] temp_purchase = temp1.Split(' ');
                    if (quantity != temp_purchase.Length)
                        {
                        Console.WriteLine("輸入數量錯誤，開店失敗");
                        continue;
                        }

                    Console.Write("接下來，請你依序輸入每一個商品的價格: ");
                    temp2 = Console.ReadLine();
                    string[] temp_money = temp2.Split(' ');

                    if (quantity != temp_money.Length)
                    {
                        Console.WriteLine("輸入數量錯誤，開店失敗");
                        continue;
                    }
                    else
                    {
                        int adjust = 0;
                        foreach (string temp in temp_money)
                        {
                            try
                            {
                                int.Parse(temp);
                            }
                            catch
                            {
                                Console.WriteLine("價格需為整數，開店失敗");
                                adjust = 1;
                                break;
                            }
                            if (int.Parse(temp) < 0)
                            {
                                Console.WriteLine("價格不能為負數，開店失敗");
                                adjust = 1;
                                break;
                            }
                        }
                        if (adjust == 1)
                        {
                            adjust = 0;
                            continue;
                        }
                    }

                    Console.Write("\n輸入完成! 每一種商品的價格依序為: \n");
                    for (int i = 0; i < temp_purchase.GetLength(0); i++)
                    {
                        purchase[i] = temp_purchase[i];
                        money[i] = temp_money[i];
                        Console.WriteLine($"商品{purchase[i]} : 價格{money[i]}元");
                    }

                    Console.Write("\n最後，請你依序輸入每一個商品目前的庫存數量: ");
                    temp3 = Console.ReadLine();
                    string[] temp_amount= temp3.Split(' ');

                    if (quantity != temp_amount.Length)
                    {
                        Console.WriteLine("輸入數量錯誤，開店失敗");
                        continue;
                    }
                    else
                    {
                        int adjust = 0;
                        foreach (string temp in temp_amount)
                        {
                            try
                            {
                                int.Parse(temp);
                            }
                            catch
                            {
                                Console.WriteLine("數量需為整數，開店失敗");
                                adjust = 1;
                                break;
                            }
                            if (int.Parse(temp) < 0)
                            {
                                Console.WriteLine("數量不能為負數，開店失敗");
                                adjust = 1;
                                break ;
                            }
                        }
                        if (adjust == 1)
                        {
                            adjust = 0;
                            continue;
                        }
                    }


                    Console.Write("\n輸入完成! 每一種商品的庫存數量依序為: \n");
                    for (int i = 0; i < temp_purchase.GetLength(0); i++)
                    {
                        amount[i] = temp_amount[i];
                        Console.WriteLine($"商品{purchase[i]} : 數量{amount[i]}個");
                    }

                    Console.WriteLine("\n開店程序完成，已開店\n");
                    been_opened = 1;
                    index = temp_purchase.Length;

                    continue;

                }
                else if(option==1 && been_opened == 1)
                {
                    Console.WriteLine("已經開過店，不能再開");
                    continue;
                }
                else if (option == 2)
                {
                    int has_continued= 0;
                    if (been_opened==0)
                    {
                        Console.WriteLine("尚未開店無法進行其他功能");
                        continue;
                    }
                    string temp1;
                    int check = 1;
                    Double total_money = 0;
                    int pay = 0;
                    int check2 = 0;



                    Console.Write("請依序輸入此訂單每一種類的商品各需要買幾個: ");
                    string[] buy_amount;
                    while (true)
                    {
                        temp1 = Console.ReadLine();
                        buy_amount = temp1.Split(' ');
                        if (buy_amount.Length !=index)
                        {
                            if(buy_amount.Length < index)
                            {
                                Console.WriteLine("輸入商品數量不足，請重新輸入或輸入-1結束交易");
                            }
                            else
                            {
                                Console.WriteLine("輸入商品數量太多，請重新輸入或輸入-1結束交易");
                            }
                            if (temp1 == "-1")
                            {
                                has_continued = 1;
                                Console.WriteLine("交易失敗");
                                break;
                            }
                            else
                            {
                                buy_amount = temp1.Split(' ');
                            }
                        }
                        else
                        {
                            foreach (string s in buy_amount)
                            {
                                try
                                {
                                    int.Parse(s);
                                }
                                catch
                                {
                                    Console.WriteLine("請輸入整數");

                                    has_continued = 1;
                                    break;
                                }
                            }
                            if (has_continued == 1)
                            {
                                has_continued = 0;
                                continue;
                            }
                            break;
                        }
                    }

                    if (has_continued == 1)
                    {
                        continue;
                    }

                    for (int i = 0; i < buy_amount.Length; i++)
                    {
                        int count1 = 0, count2 = 0;

                        count1 = int.Parse(amount[i]);
                        count2 = int.Parse(buy_amount[i]);

                        if (count1 < count2)
                        {
                            Console.WriteLine("\n庫存不足，此筆訂單不成立\n");
                            check = 0;
                            break;
                        }
                        else if (count1 < 0)
                        {
                            Console.WriteLine("\n輸入數量不可為負數，此筆訂單不成立\n");
                            check = 0;
                            break;
                        }
                    }

                    if (check == 1)
                    {
                        int in_loop = 0;
                        int discount=rand.Next(1,10);
                        for (int i = 0; i < buy_amount.Length; i++)
                        {
                            total_money += int.Parse(buy_amount[i]) * int.Parse(money[i]);
                        }
                        Console.Write("\n訂單成立!，總金額為: ");
                        Console.WriteLine($"{total_money}");
                        if (total_money>=1000)
                        {
                            total_money *= 0.1 * discount;
                            Console.WriteLine($"因訂單滿1000元有特惠活動，故訂單打{discount}折，最後金額為{total_money}元");
                            total_money = Math.Floor(total_money);
                        }

                        while (true)
                        {
                            if (check2 == 0)
                            {
                                Console.Write("請輸入消費者付款金額: ");
                                try
                                {
                                    pay = int.Parse(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("請輸入整數或輸入-1結束交易");
                                    continue;
                                }
                                if (pay <= 0 )
                                {
                                    if (pay == -1 && in_loop==1)
                                    {
                                        Console.WriteLine("交易失敗");
                                        break;
                                    }
                                    else
                                    {
                                        in_loop = 1;
                                        Console.WriteLine("請輸入正整數或輸入-1結束交易");
                                        continue;
                                    }
                                }                                
                            }
                            if (pay < total_money)
                            {
                                Console.Write("\n付款金額不足，請再輸入一次 (或輸入 -1 直接取消此筆訂單): ");
                                pay = int.Parse(Console.ReadLine());
                                if (pay == -1)
                                {
                                    break;
                                }
                                else
                                {
                                    if (pay >= total_money)
                                    {
                                        check2 = 1;
                                        break;
                                    }
                                    else
                                    {
                                        check2 = -1;
                                    }
                                }
                            }
                            else
                            {
                                check2 = 1;
                                break;
                            }
                        }
                        if (check2 == 1)
                        {
                            string temp_buyer;
                            for (int i = 0; i < buy_amount.Length; i++)
                            {
                                amount[i] = (int.Parse(amount[i]) - int.Parse(buy_amount[i])).ToString();
                                buy[i] = int.Parse(buy_amount[i]);
                            }
                            Console.Write("\n付款完成! 請找零消費者共 ");
                            Console.WriteLine($"{pay - total_money}");
                            income += total_money;

                            Console.Write("請輸入消費者名稱:");
                            while (true)
                            {
                                int adjust = 0;
                                temp_buyer = Console.ReadLine();
                                foreach(char c in temp_buyer)
                                {
                                    if((c>='a'  &&  c<='z') || (c>='A' && c <= 'Z'))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if(c == ' ')
                                        {
                                            continue ;
                                        }
                                        else
                                        {
                                            adjust = 1;
                                            break ;
                                        }
                                    }
                                }
                                if (adjust == 1)
                                {
                                    Console.Write("輸入格式錯誤，請重新輸入");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            if (!buyer.Contains(temp_buyer))
                            {
                                Console.WriteLine("新消費者登入成功\n");
                                buyer[buyer_index]=temp_buyer;
                                buy_record[buyer_index,0] =total_money;
                                buy_index[buyer_index] = 1;
                                Console.WriteLine($"消費者:{temp_buyer},歷史資訊:");
                                Console.WriteLine($"此消費者歷史訂單紀錄中，最大金額為:{total_money}");
                                Console.WriteLine($"近期交易1:{total_money}");
                                Console.WriteLine("近期交易2:0");
                                Console.WriteLine("近期交易3:0");
                                buyer_index++;
                            }
                            else
                            {
                                Console.WriteLine("會員登入成功\n");
                                int temp_index=Array.IndexOf(buyer, temp_buyer);
                                Double max = buy_record[temp_index,0];
                                buy_record[temp_index, buy_index[temp_index]] =total_money;
                                buy_index[temp_index]++;
                                for (int i = 0; i < buy_index[temp_index]; i++)
                                {
                                    if (max < buy_record[temp_index, i])
                                    {
                                        max=buy_record[temp_index, i];
                                    }
                                }
                                Console.WriteLine($"消費者:{temp_buyer},歷史資訊:");
                                Console.WriteLine($"此消費者歷史訂單紀錄中，最大金額為:{max}");
                                if (buy_index[temp_index] >=3)
                                {
                                    int temp=buy_index[temp_index];
                                    Console.WriteLine($"近期交易1:{buy_record[temp_index, temp-1]}");
                                    Console.WriteLine($"近期交易2:{buy_record[temp_index, temp-2]}");
                                    Console.WriteLine($"近期交易3:{buy_record[temp_index, temp-3]}");

                                }
                                else if(buy_index[temp_index] == 2)
                                {
                                    int temp = buy_index[temp_index];
                                    Console.WriteLine($"近期交易1:{buy_record[temp_index, temp-1]}");
                                    Console.WriteLine($"近期交易2:{buy_record[temp_index, temp-2]}");
                                    Console.WriteLine("近期交易3:0");
                                }
                            }
                        }
                    }
                }


                else if (option == 3)
                {
                    if (been_opened == 0)
                    {
                        Console.WriteLine("尚未開店無法進行其他功能");
                        continue;
                    }
                    int check_amount = 0;
                    for (int i = 0; i < index; i++)
                    {
                        if (int.Parse(amount[i]) <= 5)
                        {
                            check_amount = 1;
                        }
                        Console.WriteLine($"{purchase[i]} : {amount[i]}");
                    }
                    if (check_amount == 1)
                    {
                        Console.WriteLine("有商品的庫存數量不足");
                    }
                }

                else if (option == 4)
                {
                    if (been_opened == 0)
                    {
                        Console.WriteLine("尚未開店無法進行其他功能");
                        continue;
                    }

                    Console.WriteLine($"總收入為:{income}");
                }

                else if (option == 5)
                {
                    if (been_opened == 0)
                    {
                        Console.WriteLine("尚未開店無法進行其他功能");
                        continue;
                    }
                    int[] temp_count = new int[100];
                    int[] record = new int[100];
                    int record_index = 0;

                    for (int i = 0; i < 100; i++)
                    {
                        record[i] = -1;
                    }
                    for (int i = 0; i < index; i++)
                    {
                        temp_count[i] = buy[i];
                    }

                    Array.Sort(temp_count);
                    Array.Reverse(temp_count);

                    for (int i = 0; i < index; i++)
                    {
                        int temp_index = Array.IndexOf(buy, temp_count[i]);
                        while (Array.IndexOf(record, temp_index) != -1)
                        {
                            temp_index = Array.IndexOf(buy, temp_count[i], temp_index + 1);
                        }
                        record[record_index++] = temp_index;
                        Console.WriteLine($"第{i + 1}名:{purchase[temp_index]} ，銷售出{temp_count[i]}個");
                    }

                }

                else if (option == 6)
                {
                    if (been_opened == 0)
                    {
                        Console.WriteLine("尚未開店無法進行其他功能");
                        continue;
                    }
                    break;
                }

            }
        }
    }
}
