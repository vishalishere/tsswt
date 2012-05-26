using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADTask : ADBase
    {
        #region Get

        public static IEnumerable<ENT.Task> GetAll(string ticketNumber)
        {
            return (from t in Context.Task
                    where t.TicketNumber == ticketNumber
                    orderby t.Phase, t.TaskNumber
                    select new ENT.Task
                    {
                        ID = t.IdtAsk,
                        TicketNumber = t.TicketNumber,
                        Number = t.TaskNumber,
                        Phase = (ENT.TaskPhase)t.Phase,
                        Description = t.Description,
                        EstimatedHours = t.EstimatedHours,
                        DonePercentage = t.DonePercentage
                    });
        }

        public static ENT.Task Get(int id)
        {
            return (from t in Context.Task
                    where t.IdtAsk == id
                    select new ENT.Task
                    {
                        ID = t.IdtAsk,
                        TicketNumber = t.TicketNumber,
                        Number = t.TaskNumber,
                        Phase = (ENT.TaskPhase)t.Phase,
                        Description = t.Description,
                        EstimatedHours = t.EstimatedHours,
                        DonePercentage = t.DonePercentage
                    }).FirstOrDefault();
        }

        #endregion

        public static void Insert(string ticketNumber, ENT.Task task)
        {
            using (SwT context = Context)
            {
                Task dbTask = new Task
                {
                    TicketNumber = ticketNumber,
                    Phase = (int)task.Phase,
                    TaskNumber = task.Number,
                    Description = task.Description,
                    EstimatedHours = task.EstimatedHours,
                    DonePercentage = 0,
                };

                context.Task.InsertOnSubmit(dbTask);
                context.SubmitChanges();
            }
        }

        public static void Update(int id, ENT.Task task)
        {
            using (SwT context = Context)
            {
                Task dbTask = (from t in context.Task
                               where t.IdtAsk == id
                               select t).FirstOrDefault();

                if (dbTask == null)
                {
                    throw new Exception("La tarea ha sido eliminada. Por favor vuelvalo a crear.");
                }

                dbTask.Description = task.Description;
                dbTask.DonePercentage = task.DonePercentage;
                dbTask.EstimatedHours = task.EstimatedHours;
                dbTask.Phase = (int)task.Phase;
                dbTask.TaskNumber = task.Number;
                dbTask.TicketNumber = task.TicketNumber;
            
                context.SubmitChanges();
            }
        }

        public static void Delete(int id)
        {
            using (SwT context = Context)
            {
                Task dbTask = (from t in context.Task
                               where t.IdtAsk == id
                               select t).FirstOrDefault();

                if (dbTask == null)
                {
                    throw new Exception("La tarea ya ha sido eliminada.");
                }

                context.Task.DeleteOnSubmit(dbTask);

                context.SubmitChanges();
            }
        }

        public static void Up(int id)
        {
            using (SwT swt = Context)
            {
                int phase = (from t in swt.Task
                             where t.IdtAsk == id
                             select t.Phase).FirstOrDefault();

                IEnumerable<Task> phaseTasks = (from t in swt.Task
                                                where t.Phase == phase
                                                select t);

                int taskNumber = phaseTasks.Where(t => t.IdtAsk == id).FirstOrDefault().TaskNumber;

                phaseTasks.Where(t => t.TaskNumber == taskNumber - 1).FirstOrDefault().TaskNumber++;
                phaseTasks.Where(t => t.IdtAsk == id).FirstOrDefault().TaskNumber--;

                swt.SubmitChanges();
            }
        }

        public static void Down(int id)
        {
            using (SwT swt = Context)
            {
                int phase = (from t in swt.Task
                             where t.IdtAsk == id
                             select t.Phase).FirstOrDefault();

                IEnumerable<Task> phaseTasks = (from t in swt.Task
                                                where t.Phase == phase
                                                select t);

                int taskNumber = phaseTasks.Where(t => t.IdtAsk == id).FirstOrDefault().TaskNumber;

                phaseTasks.Where(t => t.TaskNumber == taskNumber + 1).FirstOrDefault().TaskNumber--;
                phaseTasks.Where(t => t.IdtAsk == id).FirstOrDefault().TaskNumber++;

                swt.SubmitChanges();
            }
        }
    }
}
