using Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Collections.Specialized.BitVector32;

namespace Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String CustomerUsagePath = "C:/Users/wgaur/Desktop/TestCases/TestCases/Case1/Input/AWSCustomerUsage.csv";
            String ResourceTypesPath = "C:/Users/wgaur/Desktop/TestCases/TestCases/Case1/Input/AWSResourceTypes.csv";
            String CustomerPath = "C:/Users/wgaur/Desktop/TestCases/TestCases/Case1/Input/Customer.csv";

            String[] CustomerUsageArr = System.IO.File.ReadAllLines(CustomerUsagePath);
            String[] ResourceTypesArr = System.IO.File.ReadAllLines(ResourceTypesPath);
            String[] CustomerArr = System.IO.File.ReadAllLines(CustomerPath);

            foreach (string line in CustomerUsageArr) Console.WriteLine(line);
            Console.WriteLine();
            foreach (string line in ResourceTypesArr) Console.WriteLine(line);
            Console.WriteLine();
            foreach (string line in CustomerArr) Console.WriteLine(line);
            Console.WriteLine();

            //----------List of object of Type of Resource  --------------

            List<Resourcetype> Typelist = new List<Resourcetype>();
            for (int i = 1; i < ResourceTypesArr.Length; i++)
            {
                String[] temp = ResourceTypesArr[i].Split(',');
                String type = temp[1].Trim('"');
                String cost = temp[2].Trim('"').Trim('$');
                Resourcetype Obj = new Resourcetype(type, cost);
                Typelist.Add(Obj);
            }

            foreach (Resourcetype obj in Typelist)
            {
                Console.WriteLine(obj.instanceType + " " + obj.cost);
            }
            Console.WriteLine();





            //--------------   List Of Customers Objects  ---------------------------------------------------------

            List<Customer> Clist = new List<Customer>();
            for (int i = 1; i < CustomerArr.Length; i++)
            {
                String[] temp = CustomerArr[i].Split(',');
                String name = temp[2].Trim('"');
                //Console.WriteLine(name);
                String id = temp[1].Trim('"');
                id = id.Replace("-", "");
                //Console.WriteLine(id);
                Customer Obj = new Customer(name, id);
                Clist.Add(Obj);
            }
            foreach (Customer Obj in Clist)
            {
                Console.Write(Obj.name + " ");
                Console.WriteLine(Obj.Cid);
            }
            Console.WriteLine();





            //------------------List of resource usage-----------------------------

            List<ResorceUsage> UsageList = new List<ResorceUsage>();
            for (int i = 1; i < CustomerUsageArr.Length; i++)
            {
                string[] temp = CustomerUsageArr[i].Split(',');
                string Cid = temp[1].Trim('"');
                string Eid = temp[2].Trim('"');
                string Etype = temp[3].Trim('"');
                string Start_time = temp[4].Trim('"');
                string End_time = temp[5].Trim('"');
                ResorceUsage Obj = new ResorceUsage(Cid, Eid, Etype, Start_time, End_time);
                //Console.WriteLine("HEllo");
                //Console.WriteLine(Obj.Cid + " " + Obj.Eid + " " + Obj.Etype + " " + Obj.Start_time + " " + Obj.End_time + " " + Obj.S_time + " " + Obj.E_time);

                UsageList.Add(Obj);
            }

            foreach (ResorceUsage Obj in UsageList)
            {
                Console.WriteLine(Obj.Cid + " " + Obj.Eid + " " + Obj.Etype + " " + Obj.Start_time + " " + Obj.End_time + " " + Obj.S_time + " " + Obj.E_time);

            }

            // ---------------------saperation of data according to user-------

            List<List<List<String>>> customer = new List<List<List<String>>>();

            for (int i = 0; i < Clist.Count; i++)
            {
                List<List<string>> user = new List<List<string>>();
                for (int j = 0; j < UsageList.Count; j++)
                {
                    if (Clist[i].Cid.Equals(UsageList[j].Cid))
                    {


                        List<string> usage = new List<string>();
                        usage.Add(UsageList.ElementAt(j).Cid);
                        usage.Add(UsageList.ElementAt(j).Etype);
                        usage.Add(UsageList.ElementAt(j).Eid);
                        usage.Add(UsageList.ElementAt(j).S_time[0]);
                        usage.Add(UsageList.ElementAt(j).S_time[1]);
                        usage.Add(UsageList.ElementAt(j).S_time[2]);
                        usage.Add(UsageList.ElementAt(j).S_time[3]);
                        usage.Add(UsageList.ElementAt(j).S_time[4]);
                        usage.Add(UsageList.ElementAt(j).S_time[5]);
                        usage.Add(UsageList.ElementAt(j).E_time[0]);
                        usage.Add(UsageList.ElementAt(j).E_time[1]);
                        usage.Add(UsageList.ElementAt(j).E_time[2]);
                        usage.Add(UsageList.ElementAt(j).E_time[3]);
                        usage.Add(UsageList.ElementAt(j).E_time[4]);
                        usage.Add(UsageList.ElementAt(j).E_time[5]);
                        user.Add(usage);
                    }
                }
                customer.Add(user);

            }
            Console.WriteLine();

            for (int i = 0; i < customer.Count; i++)
            {
                Console.WriteLine(customer[i].ElementAt(0).ElementAt(0));
                Console.WriteLine(" " + customer.ElementAt(i).ElementAt(0).ElementAt(0));
                for (int j = 0; j < customer[i].Count; j++)
                {
                    for (int k = 0; k < customer[i].ElementAt(j).Count; k++)
                    {
                        Console.Write("   " + customer[i].ElementAt(j).ElementAt(k).ToString());
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }



            for (int i = 0; i < customer.Count; i++)
            {
                int index = customer[i].Count; // Just because in this section indeises are changed for a second and it goes in loop
                for (int j = 0; j < index; j++)
                {
                    int diff = Int32.Parse(customer[i].ElementAt(j).ElementAt(10)) - Int32.Parse(customer[i].ElementAt(j).ElementAt(4));
                    int diff1 = Int32.Parse(customer[i].ElementAt(j).ElementAt(9)) - Int32.Parse(customer[i].ElementAt(j).ElementAt(3));
                    int adiff = diff + diff1 * 12;
                    if (adiff != 0)
                    {

                        int Actual_syear = Int32.Parse(customer[i].ElementAt(j).ElementAt(3));
                        int Actual_eyear = Int32.Parse(customer[i].ElementAt(j).ElementAt(9));
                        int Actual_smonth = Int32.Parse(customer[i].ElementAt(j).ElementAt(4));
                        int Actual_emonth = Int32.Parse(customer[i].ElementAt(j).ElementAt(10));


                        //-------Updation in end time of list for diffrent months
                        customer[i].ElementAt(j).Insert(10, Convert.ToString(Actual_smonth + 1));
                        customer[i].ElementAt(j).Insert(11, "01");
                        customer[i].ElementAt(j).Insert(12, "00");
                        customer[i].ElementAt(j).Insert(13, "00");
                        customer[i].ElementAt(j).Insert(14, "01");
                        //---------here indexes of the lists are increased so removed in end of this block

                        for (int k = 0; k < diff - 1; k++)
                        {
                            List<string> new_rec = new List<string>();
                            new_rec.Add(customer[i].ElementAt(j).ElementAt(0));
                            new_rec.Add(customer[i].ElementAt(j).ElementAt(1));
                            new_rec.Add(customer[i].ElementAt(j).ElementAt(2));
                            new_rec.Add(customer[i].ElementAt(j).ElementAt(3));
                            new_rec.Add(Convert.ToString(Actual_smonth + k + 1));
                            new_rec.Add("01");
                            new_rec.Add("00");
                            new_rec.Add("00");
                            new_rec.Add("00");
                            new_rec.Add(customer[i].ElementAt(j).ElementAt(9));
                            new_rec.Add(Convert.ToString(Actual_smonth + k + 2));
                            new_rec.Add("01");
                            new_rec.Add("00");
                            new_rec.Add("00");
                            new_rec.Add("00");

                            customer.ElementAt(i).Add(new_rec);
                        }

                        List<string> new_rec1 = new List<string>();
                        new_rec1.Add(customer[i].ElementAt(j).ElementAt(0));
                        new_rec1.Add(customer[i].ElementAt(j).ElementAt(1));
                        new_rec1.Add(customer[i].ElementAt(j).ElementAt(2));
                        new_rec1.Add(customer[i].ElementAt(j).ElementAt(3));
                        new_rec1.Add(Convert.ToString(Actual_emonth));
                        new_rec1.Add("01");
                        new_rec1.Add("00");
                        new_rec1.Add("00");
                        new_rec1.Add("00");
                        new_rec1.Add(customer[i].ElementAt(j).ElementAt(9));
                        new_rec1.Add(Convert.ToString(Actual_emonth));
                        new_rec1.Add(customer[i].ElementAt(j).ElementAt(16));
                        new_rec1.Add(customer[i].ElementAt(j).ElementAt(17));
                        new_rec1.Add(customer[i].ElementAt(j).ElementAt(18));
                        new_rec1.Add(customer[i].ElementAt(j).ElementAt(19));
                        //-----removing increased indexes----
                        customer[i].ElementAt(j).RemoveAt(19);
                        customer[i].ElementAt(j).RemoveAt(18);
                        customer[i].ElementAt(j).RemoveAt(17);
                        customer[i].ElementAt(j).RemoveAt(16);
                        customer[i].ElementAt(j).RemoveAt(15);

                        //---- Adding new list to the main list
                        customer.ElementAt(i).Add(new_rec1);
                    }
                }
            }


            for (int i = 0; i < customer.Count; i++)
            {
                Console.WriteLine(customer[i].ElementAt(0).ElementAt(0));
                Console.WriteLine(" " + customer.ElementAt(i).ElementAt(0).ElementAt(0));
                for (int j = 0; j < customer[i].Count; j++)
                {
                    for (int k = 0; k < customer[i].ElementAt(j).Count; k++)
                    {
                        Console.Write("   " + customer[i].ElementAt(j).ElementAt(k).ToString());
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            //-----------------------------------------------------------------------------




            List<Customer_usage> cust_list = new List<Customer_usage>();
            for (int i = 0; i < customer.Count; i++)
            {
                string Cid = customer[i].ElementAt(0).ElementAt(0);
                List<usage_month> month = new List<usage_month>();
                Customer_usage use = new Customer_usage(Cid, month);
                cust_list.Add(use);
            }



            for (int i = 0; i < cust_list.Count; i++)
            {
                HashSet<string> myhash1 = new HashSet<string>();
                for (int j = 0; j < customer[i].Count; j++)
                {
                    int temp = Int32.Parse(customer[i].ElementAt(j).ElementAt(4));
                    string month = temp.ToString();
                    if (!(myhash1.Contains(month)))
                    {
                        myhash1.Add(month);

                        List<session> sl = new List<session>();
                        for (int k = 0; k < customer[i].Count; k++)
                        {
                            int temp2 = Int32.Parse(customer[i].ElementAt(k).ElementAt(4));
                            string str1 = temp2.ToString();
                            if (str1 == month)
                            {
                                string Etype = customer[i].ElementAt(k).ElementAt(1);
                                string Eid = customer[i].ElementAt(k).ElementAt(2);

                                string[] Start_time = new string[6];
                                for (int l = 3; l <= 8; l++)
                                {
                                    Start_time[l - 3] = customer[i].ElementAt(j).ElementAt(l);
                                }

                                string[] End_time = new string[6];
                                for (int l = 9; l <= 14; l++)
                                {
                                    End_time[l - 9] = customer[i].ElementAt(j).ElementAt(l);
                                }

                                session sc = new session(Etype, Eid, Start_time, End_time);
                                sl.Add(sc);
                            }
                        }
                        usage_month use = new usage_month(month, sl);
                        cust_list[i].month.Add(use);
                    }
                }

            }





            for (int i = 0; i < cust_list.Count; i++)
            {
                Console.WriteLine(cust_list[i].Cid);
                for (int j = 0; j < cust_list[i].month.Count; j++)
                {
                    Console.WriteLine(cust_list[i].month[j].month_name);
                    for (int k = 0; k < cust_list[i].month[j].session.Count; k++)
                    {
                        Console.Write(" " + cust_list[i].month[j].session[k].Etype);
                        Console.Write(" " + cust_list[i].month[j].session[k].Eid);
                        foreach (string str in cust_list[i].month[j].session[k].Start_time)
                        {
                            Console.Write(str + " ");
                        }
                        foreach (string str in cust_list[i].month[j].session[k].End_time)
                        {
                            Console.Write(str + " ");
                        }
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }














        }
    }
}
