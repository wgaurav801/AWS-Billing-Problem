using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    internal class splitMonth
    {
        public splitMonth() { }


        public List<List<List<String>>> SplitMonth(List<List<List<String>>> Seplist)
        {
            List<List<List<String>>> customer = Seplist;
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
            return customer;
        }

        public void Print_Sep_list(List<List<List<String>>> customer)
        {
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

            Console.WriteLine();
        }
    }
}
