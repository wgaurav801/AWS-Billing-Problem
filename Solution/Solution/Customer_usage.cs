using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    internal class Customer_usage
    {
        public string Cid;
        public List<usage_month> month;

        public Customer_usage(string Cid, List<usage_month> month)
        {
            this.Cid = Cid;
            this.month = month;

        }
    }
}
