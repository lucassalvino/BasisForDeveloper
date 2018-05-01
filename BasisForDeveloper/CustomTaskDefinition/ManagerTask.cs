using System;
using System.Collections.Generic;
using System.Text;

namespace BasisForDeveloper.CustomTaskDefinition
{
    public class ManagerTask : CustomTask
    {
        private List<CustomTask> Tasks;
        public ManagerTask()
        {
            Name = "Manager Custom Tasks";
        }

        public override void SetExecuteTask(bool value)
        {
            base.SetExecuteTask(value);
            if (!ExecuteTask)
            {
                foreach (CustomTask a in Tasks)
                {
                    a.SetExecuteTask(false);
                }
            }
        }

        public void AddCustomTask(CustomTask TaskAdd)
        {
            if (Tasks == null) Tasks = new List<CustomTask>();
            if (TaskAdd == null) throw new Exception("Custom Task is not defined");
            Tasks.Add(TaskAdd);
        }

        public override void BeforeExecuteTaskDefinition()
        {
            if (Tasks == null || Tasks.Count <= 0)
            {
                throw new Exception("The tasks manager not have tasks");
            }
        }

        public override void taskDefinition()
        {
            foreach(CustomTask a in Tasks)
            {
                a.Run();
            }
        }
    }
}
