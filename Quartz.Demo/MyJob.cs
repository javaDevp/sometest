using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz.Demo
{
    public class MyJob : IJob
    {
        public int Age { private get; set; }
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                JobKey key = context.JobDetail.Key;
                string name = context.JobDetail.JobDataMap.GetString("name");
                Console.WriteLine("{1} {3}: welcome to china, {0} your Age is {2}", name, key.Name, Age, DateTime.Now.Second);
            }
            catch (Exception ex)
            {
                throw new JobExecutionException();
            }
        }
    }
}
