using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    internal class usage_month
    {
        public string month_name;
        public List<session> session;

        public usage_month(string month, List<session> session)
        {
            this.month_name = month;
            this.session = session;
        }
    }
}
