using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace E94111091_practice_2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            string[] purchase = new string[100];
            string[] money = new string[100];
            string[] amount = new string[100];
            int[] buy= new int[100];
            int income = 0;
            int index = 0;
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
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    int quantity;
                    string temp1, temp2, temp3;

                    Console.Write("請輸入今日總共有幾種商品要販售: ");
                    quantity = int.Parse(Console.ReadLine());

                    Console.Write("請依序輸入每一種商品的名稱: ");
                    temp1 = Console.ReadLine();
                    string[] temp_purchase = temp1.Split(' ');

                    Console.Write("接下來，請你依序輸入每一個商品的價格: ");
                    temp2 = Console.ReadLine();
                    string[] temp_money = temp2.Split(' ');

                    Console.Write("\n輸入完成! 每一種商品的價格依序為: \n");
                    for (int i = 0; i < temp_purchase.GetLength(0); i++)
                    {
                        purchase[i] = temp_purchase[i];
                        money[i] = temp_money[i];
                        Console.WriteLine($"{purchase[i]} : {money[i]}");
                    }

                    Console.Write("\n最後，請你依序輸入每一個商品目前的庫存數量: ");
                    temp3 = Console.ReadLine();
                    string[] temp_amount = temp3.Split(' ');

                    Console.Write("\n輸入完成! 每一種商品的庫存數量依序為: \n");
                    for (int i = 0; i < temp_purchase.GetLength(0); i++)
                    {
                        amount[i] = temp_amount[i];
                        Console.WriteLine($"{purchase[i]} : {amount[i]}");
                    }

                    Console.WriteLine("\n開店程序完成，已開店\n");

                    index = temp_purchase.Length;

                    continue;

                }
                else if (option == 2)
                {
                    string temp1;
                    int check = 1;
                    int total_money = 0;
                    int pay = 0;
                    int check2 = 0;

                    Console.Write("請依序輸入此訂單每一種類的商品各需要買幾個: ");
                    temp1 = Console.ReadLine();
                    string[] buy_amount = temp1.Split(' ');

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
                    }

                    if (check == 1)
                    {
                        for (int i = 0; i < buy_amount.Length; i++)
                        {
                            total_money += int.Parse(buy_amount[i]) * int.Parse(money[i]);
                        }
                        Console.Write("\n訂單成立!，總金額為: ");
                        Console.WriteLine($"{total_money}");

                        while (true)
                        {
                            if (check2 == 0)
                            {
                                Console.Write("請輸入消費者付款金額: ");
                                pay = int.Parse(Console.ReadLine());
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
                                    if (pay > total_money)
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
                            for (int i = 0; i < buy_amount.Length; i++)
                            {
                                amount[i] = (int.Parse(amount[i]) - int.Parse(buy_amount[i])).ToString();
                                buy[i] = int.Parse(buy_amount[i]);
                            }
                            Console.Write("\n付款完成! 請找零消費者共 ");
                            Console.WriteLine($"{pay - total_money}");
                            income += total_money;
                        }
                    }
                }


                else if (option == 3)
                {
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
                    Console.WriteLine($"總收入為:{income}");
                }

                else if (option == 5)
                {
                    int[] temp_count = new int[100];
                    int[] record = new int[100];
                    int record_index=0;

                    for(int i = 0; i < 100; i++)
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
                        while(Array.IndexOf(record, temp_index) != -1)
                        {
                            temp_index = Array.IndexOf(buy, temp_count[i], temp_index+1);
                        }
                        record[record_index++]= temp_index;
                        Console.WriteLine($"第{i + 1}名:{purchase[temp_index]} ，銷售出{temp_count[i]}個");
                    }

                }

                else if (option == 6)
                {
                    break;
                }

                }
            }
        }
    }
