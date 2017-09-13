Configuration:
1.Programmatically via providing NameValueCollection parameter to scheduler factory
2.Via standard youapp.exe.config configuration file using quartz-element
3.quartz.config file in your application’s root directory

The key interfaces and classes of the Quartz API are:
1.IScheduler - the main API for interacting with the scheduler.
2.IJob - an interface to be implemented by components that you wish to have executed by the scheduler.
3.IJobDetail - used to define instances of Jobs.
4.ITrigger - a component that defines the schedule upon which a given Job will be executed.
5.JobBuilder - used to define/build JobDetail instances, which define instances of Jobs.
6.TriggerBuilder - used to define/build Trigger instances.

Quartz ships with a handful of different trigger types, but the most commonly used types are SimpleTrigger (interface ISimpleTrigger) and CronTrigger (interface ICronTrigger).
SimpleTrigger is handy if you need ‘one-shot’ execution (just single execution of a job at a given moment in time), or if you need to fire a job at a given time, and have it repeat N times, with a delay of T between executions.
CronTrigger is useful if you wish to have triggering based on calendar-like schedules - such as “every Friday, at noon” or “at 10:15 on the 10th day of every month.”

The keys of Jobs and Triggers (JobKey and TriggerKey) allow them to be placed into ‘groups’ which can be useful for organizing your jobs and triggers into categories such as “reporting jobs” and “maintenance jobs”.

Durability - if a job is non-durable, it is automatically deleted from the scheduler once there are no longer any active triggers associated with it. In other words, non-durable jobs have a life span bounded by the existence of its triggers.

RequestsRecovery - if a job “requests recovery”, and it is executing during the time of a ‘hard shutdown’ of the scheduler (i.e. the process it is running within crashes, or the machine is shut off), then it is re-executed when the scheduler is started again. In this case, the JobExecutionContext.Recovering property will return true.