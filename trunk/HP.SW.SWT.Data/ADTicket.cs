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

            return (from ticket in Context.Ticket
                    where all || ticket.Cluster.ShortDescription == cluster
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
                        Tasks = (from task in ticket.Task
                                 select new ENT.Task
                                 {
                                     //Description = task.Description,
                                     //EstimatedHours = task.EstimatedHours,
                                     //DonePercentage = task.DonePercentage
                                 })
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
