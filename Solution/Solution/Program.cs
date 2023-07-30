using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

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
            for(int i = 1;i< CustomerUsageArr.Length; i++)
            {
                string[] temp= CustomerUsageArr[i].Split(',');
                string Cid = temp[1].Trim('"');
                string Eid = temp[2].Trim('"');
                string Etype = temp[3].Trim('"');
                string Start_time = temp[4].Trim('"'); 
                string End_time = temp[5].Trim('"'); 
                ResorceUsage Obj= new ResorceUsage(Cid,Eid,Etype,Start_time,End_time);
                //Console.WriteLine("HEllo");
                //Console.WriteLine(Obj.Cid + " " + Obj.Eid + " " + Obj.Etype + " " + Obj.Start_time + " " + Obj.End_time + " " + Obj.S_time + " " + Obj.E_time);

                UsageList.Add(Obj);
            }

            foreach(ResorceUsage Obj in UsageList)
            {
                Console.WriteLine(Obj.Cid + " " + Obj.Eid + " " + Obj.Etype + " " + Obj.Start_time + " " + Obj.End_time + " " + Obj.S_time + " " + Obj.E_time);
                Console.WriteLine("HElllooooooo");
            }

            Console.WriteLine();    
            Console.WriteLine(UsageList.ElementAt(3).End_time + " "+UsageList.ElementAt(3).E_time[0]);    

            



















        }
    }
}
