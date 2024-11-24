using Alspec.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alspec.Models.Data
{
    public static  class JobData
    {
        public static List<Job> JobList = new List<Job>
        {
            new Job{Id="1", Title="Job 1",Description="Alspec Product" },
            new Job{Id="2", Title="Job 2",Description="Alspec Product2" }
        };

    }
}
