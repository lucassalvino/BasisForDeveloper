using System;
using System.Collections.Generic;
using System.Text;
using BasisForDeveloper.Logs;
using System.Threading;
using System.Threading.Tasks;

namespace BasisForDeveloper.CustomTaskDefinition
{
    public class CustomTask
    {
        public CustomTask()
        {
            Name = this.GetType().ToString();
        }

        protected Boolean ExecuteTask;

        public String Name { get; set; }

        public Boolean GetExecuteTask()
        {
            return ExecuteTask;
        }

        public virtual void SetExecuteTask(Boolean value)
        {
            ExecuteTask = value;
        }

        public void Run()
        {
            TreatLogs.AddLog($"[INFO] Init Routine Before Execute Task: {Name}");
            BeforeExecuteTaskDefinition();
            Thread t = new Thread(taskDefinition);
            t.Start();
            TreatLogs.AddLog($"[INFO] Init Routine After Execute Task: {Name}");
            AfterExecuteTaskDefinition();
        }

        public void RunTaskAsync()
        {
            TreatLogs.AddLog($"[INFO] Init Routine Before Asyn Execute Task: {Name}");
            BeforeExecuteTaskDefinition();
            Task.Run(()=> taskDefinition());
            TreatLogs.AddLog($"[INFO] Init Routine After Asyn Execute Task: {Name}");
            AfterExecuteTaskDefinition();
        }

        public virtual void taskDefinition()
        {
            throw new NotImplementedException();
        }

        public virtual void BeforeExecuteTaskDefinition()
        {
        }

        public virtual void AfterExecuteTaskDefinition()
        {
        }
    }
}
