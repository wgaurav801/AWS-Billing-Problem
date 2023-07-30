using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    internal class ResorceUsage
    {
        public string Cid;
        public string Eid;
        public string Etype;
        public string Start_time ;
        public string End_time ;
        public string[] S_time ;
        public string[] E_time ;

        public ResorceUsage(string Cid, string Eid, string Etype, string Start_time,string End_time ) { 
           Functions fc= new Functions();
            this.Cid = Cid;
            this.Eid = Eid;
            this.Etype = Etype;
            this.Start_time = Start_time;
            this.End_time = End_time;
            S_time = fc.date_time_spilt(Start_time);
            E_time = fc.date_time_spilt(End_time);


        }
    }
}
