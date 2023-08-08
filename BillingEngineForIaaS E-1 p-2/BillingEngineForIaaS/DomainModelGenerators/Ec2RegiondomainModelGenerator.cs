﻿using BillingEngine.Models.Ec2;
using BillingEngine.Parsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingEngineForIaaS.DomainModelGenerators
{
    public class Ec2RegiondomainModelGenerator
    {

        public List<Ec2Region> GenerateEc2Region(List<ParsedEc2Region> parsedEc2Regions)
        {
            return parsedEc2Regions.Select(rec => generateEc2region(rec)).ToList();
        }

        private Ec2Region generateEc2region(ParsedEc2Region region)
        {
            return new Ec2Region(region.RegionName, region.FreeTierEligibleInstanceType);
        }
    }

    
}
