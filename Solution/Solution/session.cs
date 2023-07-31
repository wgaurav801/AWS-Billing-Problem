using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    internal class session
    {
        public string Etype;
        public string Eid;
        public string[] Start_time;
        public string[] End_time;
        public session() { }
        public session(string Etype, string Eid, string[] Start_time, string[] End_time)
        {
            this.Etype = Etype;
            this.Eid = Eid;
            this.Start_time = Start_time;
            this.End_time = End_time;
        }

        public int calculate_hours(string[] Start_time, string[] End_time)
        {
            int[] St = new int[Start_time.Length];
            int[] Et = new int[End_time.Length];
            for (int i = 0; i < St.Length; i++) St[i] = Int32.Parse(Start_time[i]);
            for (int i = 0; i < Et.Length; i++) Et[i] = Int32.Parse(End_time[i]);

            DateTime stime = new DateTime(St[0], St[1], St[2], St[3], St[4], St[5]);
            DateTime etime = new DateTime(Et[0], Et[1], Et[2], Et[3], Et[4], Et[5]);
            TimeSpan ts = etime - stime;
            double totalSecond = ts.TotalSeconds;

            double totalhours = Math.Ceiling(totalSecond / 3600);
            return 0;
        }
    }
}
