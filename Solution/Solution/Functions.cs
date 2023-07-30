using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    internal class Functions
    {


        public string[] date_time_spilt(string date_time)
        {
            //date_time = date_time.Trim('"');
            string[] dt_array = date_time.Split('-', 'T', ':');

            return dt_array;
        }



    }
}
