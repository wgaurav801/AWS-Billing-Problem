using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    internal class Customer
    {
        public String name;
        public String Cid;

        public Customer() { }
        public Customer(string name, string id)
        {
            this.name = name;
            this.Cid = id;
        }

        public List<Customer> getCustomerObj(String[] CustomerArr)
        {
            List<Customer> list = new List<Customer>();
            for (int i = 1; i < CustomerArr.Length; i++)
            {
                String[] temp = CustomerArr[i].Split(',');
                String name = temp[2].Trim('"');
                //Console.WriteLine(name);
                String id = temp[1].Trim('"');
                id = id.Replace("-", "");
                //Console.WriteLine(id);
                Customer Obj = new Customer(name, id);
                list.Add(Obj);
            }

            return list;
        }



        public void PrintC_Obj_list(List<Customer> Clist)
        {
            foreach (Customer Obj in Clist)
            {
                Console.WriteLine(Obj.name + " " + Obj.Cid);
            }
            Console.WriteLine();
        }
    }
}
