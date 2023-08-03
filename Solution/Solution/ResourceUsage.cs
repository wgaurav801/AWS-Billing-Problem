using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    internal class ResourceUsage
    {
    public ResourceUsage() { }
        public string Cid;
        public string Eid;
        public string Etype;
        public string Start_time ;
        public string End_time ;
        public string[] S_time ;
        public string[] E_time ;

        public ResourceUsage(string Cid, string Eid, string Etype, string Start_time,string End_time ) { 
           Functions fc= new Functions();
            this.Cid = Cid;
            this.Eid = Eid;
            this.Etype = Etype;
            this.Start_time = Start_time;
            this.End_time = End_time;
            S_time = fc.date_time_spilt(Start_time);
            E_time = fc.date_time_spilt(End_time);


        }

        public List<ResourceUsage> GetResorceUsages(string[] CustomerUsageArr)
        {
            List<ResourceUsage> list = new List<ResourceUsage>();
            for (int i = 1; i < CustomerUsageArr.Length; i++)
            {
                string[] temp = CustomerUsageArr[i].Split(',');
                string Cid = temp[1].Trim('"');
                string Eid = temp[2].Trim('"');
                string Etype = temp[3].Trim('"');
                string Start_time = temp[4].Trim('"');
                string End_time = temp[5].Trim('"');
                ResourceUsage Obj = new ResourceUsage(Cid, Eid, Etype, Start_time, End_time);
                list.Add(Obj);
            }
            return list;
        }


        public void Print_Ruse_List(List<ResourceUsage> UsageList)
        {
            foreach (ResourceUsage Obj in UsageList)
            {
                Console.WriteLine(Obj.Cid + " " + Obj.Eid + " " + Obj.Etype + " " + Obj.Start_time + " " + Obj.End_time + " " + Obj.S_time + " " + Obj.E_time);

            }
        }
    }
}
