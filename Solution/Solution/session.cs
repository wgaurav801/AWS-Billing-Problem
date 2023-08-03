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



        public List<Customer_usage> Sep_User_month(List<List<List<String>>> customer1)
        {
            List<Customer_usage> cust_list = new List<Customer_usage>();
            for (int i = 0; i < customer1.Count; i++)
            {
                string Cid = customer1[i].ElementAt(0).ElementAt(0);
                List<usage_month> month = new List<usage_month>();
                Customer_usage use = new Customer_usage(Cid, month);
                cust_list.Add(use);
            }



            for (int i = 0; i < cust_list.Count; i++)
            {
                HashSet<string> myhash1 = new HashSet<string>();
                for (int j = 0; j < customer1[i].Count; j++)
                {
                    int temp = Int32.Parse(customer1[i].ElementAt(j).ElementAt(4));
                    string month = temp.ToString();
                    if (!(myhash1.Contains(month)))
                    {
                        myhash1.Add(month);

                        List<session> sl = new List<session>();
                        for (int k = 0; k < customer1[i].Count; k++)
                        {
                            int temp2 = Int32.Parse(customer1[i].ElementAt(k).ElementAt(4));
                            string str1 = temp2.ToString();
                            if (str1 == month)
                            {
                                string Etype = customer1[i].ElementAt(k).ElementAt(1);
                                string Eid = customer1[i].ElementAt(k).ElementAt(2);

                                string[] Start_time = new string[6];
                                for (int l = 3; l <= 8; l++)
                                {
                                    Start_time[l - 3] = customer1[i].ElementAt(j).ElementAt(l);
                                }

                                string[] End_time = new string[6];
                                for (int l = 9; l <= 14; l++)
                                {
                                    End_time[l - 9] = customer1[i].ElementAt(j).ElementAt(l);
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
            return cust_list;
        }


        public void Print_MainList(List<Customer_usage> cust_list)
        {
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
