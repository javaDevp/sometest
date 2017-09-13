using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz.Impl;
using Topshelf;
using System.Threading;
using Common.Logging;
using Quartz.Impl.Calendar;

namespace Quartz.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog  log = LogManager.GetLogger<Program>();
            log.Debug("开始...");
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<MyJob>().
                WithIdentity("MyJob", "MyGroup").
                UsingJobData("name", "jimmy").
                UsingJobData("Age", 13).
                Build();

            ITrigger trigger = TriggerBuilder.Create().
                WithIdentity("MyTrigger", "MyGroup")
                .StartNow()
                .WithCronSchedule("1/5 * * ? * *")
                //.WithSimpleSchedule(x=> { x.RepeatForever();
                //    x.WithInterval(TimeSpan.FromSeconds(1));
                //})
                .Build();

            scheduler.ScheduleJob(job, trigger);

            //HolidayCalendar cal = new HolidayCalendar();
            //cal.AddExcludedDate(new DateTime());
            //scheduler.AddCalendar("", cal, false);
            Console.ReadKey();
        }

        private static void SelfHost()
        {
            
            HostFactory.Run(x =>
            {
                x.SetDescription("这里是描述，我看下有啥用");
                x.SetDisplayName("这里是显示");
                x.SetServiceName("服务名");

                x.Service<ServiceRunner>();
            });
        }
    }
}
