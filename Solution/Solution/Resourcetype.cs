using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    internal class Resourcetype
    {
        public String instanceType;
        public String cost;

        public Resourcetype() { }
        public Resourcetype(string instanceType, string cost)
        {
            this.instanceType = instanceType;
            this.cost = cost;
        }

        public List<Resourcetype> getResourceObj(String[] ResourceTypesArr)
        {
            List<Resourcetype> list = new List<Resourcetype>();
            for (int i = 1; i < ResourceTypesArr.Length; i++)
            {
                String[] temp = ResourceTypesArr[i].Split(',');
                String type = temp[1].Trim('"');
                String cost = temp[2].Trim('"').Trim('$');
                Resourcetype Obj = new Resourcetype(type, cost);
                list.Add(Obj);
            }
            return list;
        }

        public void printR_Obj_list(List<Resourcetype> Typelist)
        {
            foreach (Resourcetype obj in Typelist)
            {
                Console.WriteLine(obj.instanceType + " " + obj.cost);
            }
            Console.WriteLine();
        }

    }
}
