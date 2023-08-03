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

            //----------List of object of Type of Resource  --------------
            Resourcetype Rt = new Resourcetype();
            List<Resourcetype> Typelist = Rt.getResourceObj(ResourceTypesArr);
            Rt.printR_Obj_list(Typelist);


            //--------------   List Of Customer Objects  ---------------------------------------------------------
            Customer Cust = new Customer();
            List<Customer> Clist = Cust.getCustomerObj(CustomerArr);
            Cust.PrintC_Obj_list(Clist);

            //------------------List of resource usage-----------------------------
            ResourceUsage R_use = new ResourceUsage();
            List<ResourceUsage> UsageList = R_use.GetResorceUsages(CustomerUsageArr);



            // ---------------------saperation of data according to user--------------------

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

            //--------------------spliting month-------------

            splitMonth Sm = new splitMonth();
            List<List<List<String>>> customer1 = Sm.SplitMonth(customer);
            Sm.SplitMonth(customer1);
            //-----------------------------------------------------------------------------


            session sc = new session();
            List<Customer_usage> cust_list = sc.Sep_User_month(customer1);
            sc.Print_MainList(cust_list);






        }
    }
}
