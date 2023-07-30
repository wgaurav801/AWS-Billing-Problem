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
        public Resourcetype(string instanceType, string cost)
        {
            this.instanceType = instanceType;
            this.cost = cost;
        }
    }
}
