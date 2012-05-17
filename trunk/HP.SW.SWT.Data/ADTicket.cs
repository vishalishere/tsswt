using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADTicket : ADBase
    {
        public static IEnumerable<ENT.Ticket> GetAllTickets(string cluster)
        {
            bool all = string.IsNullOrEmpty(cluster);

            return (from task in Context.Task
                    where all || task.Ticket.Cluster.ShortDescription == cluster
                    group task by new
                    {
                        Number = task.Ticket.Number,
                        Cluster = task.Ticket.Cluster.ShortDescription,
                        Resource = new ENT.Resource
                        {
                            T = task.Ticket.Resource.T,
                            Cluster = task.Ticket.Resource.Cluster.ShortDescription,
                            Name = task.Ticket.Resource.Name
                        },
                        StartDate = task.Ticket.StartDate,
                        DeliveryDate = task.Ticket.DeliveryDate,
                    } into t
                    select new ENT.Ticket
                    {
                        Number = t.Key.Number,
                        Cluster = t.Key.Cluster,
                        Resource = t.Key.Resource,
                        StartDate = t.Key.StartDate,
                        DeliveryDate = t.Key.DeliveryDate,
                    });
        }

        public static IEnumerable<ENT.Ticket> GetWorkingTickets()
        {
            return (from ticket in Context.Ticket
                    //where ticket.Attribute("working") != null && bool.Parse(ticket.Attribute("working").Value)
                    select new ENT.Ticket
                    {
                        Number = ticket.Number,
                        Cluster = ticket.Cluster.ShortDescription,
                        Resource = new ENT.Resource
                        {
                            T = ticket.Resource.T,
                            Cluster = ticket.Resource.Cluster.ShortDescription,
                            Name = ticket.Resource.Name
                        },
                        StartDate = ticket.StartDate,
                        DeliveryDate = ticket.DeliveryDate,
                        //ConsumedHours = ticket.ConsumedHours,
                        //Tasks = (from task in ticket.Task
                        //         select new ENT.Task
                        //         {
                        //             Description = task.Description,
                        //             EstimatedHours = task.EstimatedHours,
                        //             DonePercentage = task.DonePercentage
                        //         })
                    });
        }
    }
}
