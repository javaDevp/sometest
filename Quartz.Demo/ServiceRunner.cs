using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz.Impl;
using Topshelf;

namespace Quartz.Demo
{
    public class ServiceRunner : ServiceControl
    {
        private IScheduler scheduler;

        public ServiceRunner()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler();
        }

        #region ServiceControl
        public bool Start(HostControl hostControl)
        {
            scheduler.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            scheduler.Shutdown(true);
            return true;
        }
        #endregion
    }
}
