using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
                                && !t.DateDelete.HasValue
                                select t).ToList();

            // Hay que hacerlo en dos pasos 
            // porque no logro convertir directo de la base de datos 
            // el Data.Task en ENT.Task
            var entTickets = (from t in mySqlTickets
                              select new ENT.Ticket
                              {
                                  Number = t.Number,
                                  Cluster = t.Cluster.ShortDescription,
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

        public static IEnumerable<ENT.Ticket> GetAll(ENT.TicketFilterOptions filterOptions, ENT.PagingOptions pagingOptions)
        {
            var dataTickets = (from t in Context.Ticket
                               where !t.DateDelete.HasValue
                               select t).ToList();
            //.Where((Expression<Func<Ticket, bool>>)filterOptions.GetExpression()).OrderBy(pagingOptions.GetExpression());

            return (from t in dataTickets
                    select new ENT.Ticket
                    {
                        Number = t.Number,
                        Cluster = t.Cluster.ShortDescription,
                        StartDate = t.StartDate,
                        DeliveryDate = t.DeliveryDate,
                        Tasks = (from ta in t.Task
                                 select new ENT.Task
                                 {
                                     Description = ta.Description,
                                     EstimatedHours = ta.EstimatedHours.Value,
                                     DonePercentage = ta.DonePercentage.Value,
                                 }),
                        Comments = (from tc in t.TicketComment
                                    select new ENT.TicketComment
                                    {
                                        Comment = tc.Comment,
                                        User = new ENT.User
                                        {
                                            ID = tc.User.IduSer,
                                            Logon = tc.User.UserLogon,
                                            Name = tc.User.Name
                                        },
                                        Date = tc.Date,
                                    })
                    });
        }

        public static ENT.Ticket Get(string ticketNumber)
        {
            Ticket ticket = (from t in Context.Ticket
                             where t.Number == ticketNumber
                             select t).FirstOrDefault();

            ENT.Ticket res = null;
            if (ticket != null)
            {
                res = new ENT.Ticket
                {
                    Number = ticket.Number,
                    Cluster = ticket.Cluster.ShortDescription,
                    StartDate = ticket.StartDate,
                    DeliveryDate = ticket.DeliveryDate,
                    Tasks = (from ta in ticket.Task
                             select new ENT.Task
                             {
                                 Description = ta.Description,
                                 EstimatedHours = ta.EstimatedHours.Value,
                                 DonePercentage = ta.DonePercentage.Value,
                             }),
                    Comments = (from tc in ticket.TicketComment
                                select new ENT.TicketComment
                                {
                                    Comment = tc.Comment,
                                    User = new ENT.User
                                    {
                                        ID = tc.User.IduSer,
                                        Logon = tc.User.UserLogon,
                                        Name = tc.User.Name
                                    },
                                    Date = tc.Date,
                                })
                };
            }
            return res;
        }

        public static void Update(ENT.Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public static void Delete(string ticketNumber, ENT.User user)
        {
            using (SwT swt = Context)
            {
                Ticket ticket = (from t in swt.Ticket
                                 where t.Number == ticketNumber
                                 select t).FirstOrDefault();

                if (ticket != null)
                {
                    ticket.IduSerDelete = user.ID;
                    ticket.DateDelete = DateTime.Now;
                }
            }
        }
    }
}