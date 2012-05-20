using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADTicket : ADBase
    {
        public static IEnumerable<ENT.Ticket> GetWorkingTickets(string cluster)
        {
            bool all = string.IsNullOrEmpty(cluster);

            var mySqlTickets = (from t in Context.Ticket
                                where (all || t.Cluster.ShortDescription == cluster)
                                && (t.StartDate.HasValue || t.DeliveryDate.HasValue)
                                select t).ToList();

            // Hay que hacerlo en dos pasos 
            // porque no logro convertir directo de la base de datos 
            // el Data.Task en ENT.Task
            var entTickets = (from t in mySqlTickets
                              select new ENT.Ticket
                              {
                                  Number = t.Number,
                                  Cluster = t.Cluster.ShortDescription,
                                  Resource = new ENT.Resource
                                   {
                                       T = t.Resource.T,
                                       Name = t.Resource.Name,
                                       Cluster = t.Resource.Cluster.ShortDescription
                                   },
                                  StartDate = t.StartDate,
                                  DeliveryDate = t.DeliveryDate,
                                  Tasks = (from ta in t.Task
                                           select new ENT.Task
                                           {
                                               Description = ta.Description,
                                               EstimatedHours = ta.EstimatedHours.Value,
                                               DonePercentage = ta.DonePercentage.Value,
                                           })
                              });

            return (from t in entTickets
                    where t.DonePercentage < 100
                    select t);
        }
    }
}