﻿using System;
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
                                  Title = t.Title,
                                  Description = t.Description,
                                  Resource = new ENT.Resource
                                  {
                                      T = t.Resource.T,
                                      Name = t.Resource.Name,
                                      Cluster = t.Resource.Cluster.ShortDescription,
                                  },
                                  Status = (ENT.TicketStatus)t.Status,
                                  Priority = (ENT.TicketPriority)t.Priority,
                                  Category = (ENT.TicketCategory)t.Category,
                                  Cluster = new ENT.Cluster
                                    {
                                        ID = t.Cluster.IdcLuster,
                                        ShortDescription = t.Cluster.ShortDescription,
                                        Description = t.Cluster.Description,
                                    },
                                  System = t.System,
                                  StartDate = t.StartDate,
                                  DeliveryDate = t.DeliveryDate,
                                  RealDeliveryDate = t.RealDeliveryDate,
                                  ConsumedHours = t.ConsumedHours,
                                  DateCreated = t.DateCreate,
                                  UserCreated = new ENT.User
                                  {
                                      ID = t.User.IduSer,
                                      Logon = t.User.UserLogon,
                                      Name = t.User.Name
                                  },
                                  DateLastModified = t.DateLastModified,
                                  UserLastModified = new ENT.User
                                  {
                                      ID = t.User2.IduSer,
                                      Logon = t.User2.UserLogon,
                                      Name = t.User2.Name
                                  },
                                  DateDeleted = t.DateDelete,
                                  UserDeleted = t.User1 == null ? null : new ENT.User
                                  {
                                      ID = t.User1.IduSer,
                                      Logon = t.User1.UserLogon,
                                      Name = t.User1.Name
                                  },
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

            pagingOptions.Count = dataTickets.Count;

            return (from t in dataTickets
                     select new ENT.Ticket
                              {
                                  Number = t.Number,
                                  Title = t.Title,
                                  Description = t.Description,
                                  Resource = new ENT.Resource
                                  {
                                      T = t.Resource.T,
                                      Name = t.Resource.Name,
                                      Cluster = t.Resource.Cluster.ShortDescription,
                                  },
                                  Status = (ENT.TicketStatus)t.Status,
                                  Priority = (ENT.TicketPriority)t.Priority,
                                  Category = (ENT.TicketCategory)t.Category,
                                  Cluster = new ENT.Cluster
                                  {
                                      ID = t.Cluster.IdcLuster,
                                      ShortDescription = t.Cluster.ShortDescription,
                                      Description = t.Cluster.Description,
                                  },
                                  System = t.System,
                                  StartDate = t.StartDate,
                                  DeliveryDate = t.DeliveryDate,
                                  RealDeliveryDate = t.RealDeliveryDate,
                                  ConsumedHours = t.ConsumedHours,
                                  DateCreated = t.DateCreate,
                                  UserCreated = new ENT.User
                                  {
                                      ID = t.User.IduSer,
                                      Logon = t.User.UserLogon,
                                      Name = t.User.Name
                                  },
                                  DateLastModified = t.DateLastModified,
                                  UserLastModified = new ENT.User
                                  {
                                      ID = t.User2.IduSer,
                                      Logon = t.User2.UserLogon,
                                      Name = t.User2.Name
                                  },
                                  DateDeleted = t.DateDelete,
                                  UserDeleted = t.User1 == null ? null : new ENT.User
                                  {
                                      ID = t.User1.IduSer,
                                      Logon = t.User1.UserLogon,
                                      Name = t.User1.Name
                                  },
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
                                  Title = ticket.Title,
                                  Description = ticket.Description,
                                  Resource = new ENT.Resource
                                  {
                                      T = ticket.Resource.T,
                                      Name = ticket.Resource.Name,
                                      Cluster = ticket.Resource.Cluster.ShortDescription,
                                  },
                                  Status = (ENT.TicketStatus)ticket.Status,
                                  Priority = (ENT.TicketPriority)ticket.Priority,
                                  Category = (ENT.TicketCategory)ticket.Category,
                                  Cluster = new ENT.Cluster
                                  {
                                      ID = ticket.Cluster.IdcLuster,
                                      ShortDescription = ticket.Cluster.ShortDescription,
                                      Description = ticket.Cluster.Description,
                                  },
                                  System = ticket.System,
                                  StartDate = ticket.StartDate,
                                  DeliveryDate = ticket.DeliveryDate,
                                  RealDeliveryDate = ticket.RealDeliveryDate,
                                  ConsumedHours = ticket.ConsumedHours,
                                  DateCreated = ticket.DateCreate,
                                  UserCreated = new ENT.User
                                  {
                                      ID = ticket.User.IduSer,
                                      Logon = ticket.User.UserLogon,
                                      Name = ticket.User.Name
                                  },
                                  DateLastModified = ticket.DateLastModified,
                                  UserLastModified = new ENT.User
                                  {
                                      ID = ticket.User2.IduSer,
                                      Logon = ticket.User2.UserLogon,
                                      Name = ticket.User2.Name
                                  },
                                  DateDeleted = ticket.DateDelete,
                                  UserDeleted = ticket.User1 == null ? null : new ENT.User
                                  {
                                      ID = ticket.User1.IduSer,
                                      Logon = ticket.User1.UserLogon,
                                      Name = ticket.User1.Name
                                  },
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
        //    Ticket dbTicket = (from t in Context.Ticket
        //                     where t.Number == ticket.Number
        //                     select t);

        //    dbTicket.AssignedTo = ticket.Resource.T;
        //        origTidbTicketcket.Title = viewTicket.Title;
        //        dbTicket.Resource = Data.ADResource.Get(viewTicket.Resource.T);
        //        ticket.Status = viewTicket.Status;
        //        ticket.Priority = viewTicket.Priority;
        //        ticket.Description = viewTicket.Description;
        //        ticket.Category = viewTicket.Category;
        //        if (!string.IsNullOrEmpty(viewTicket.NewComment))
        //        {
        //            ticket.Comments.
        //        ticket.com


        //    <%: Html.TextAreaFor(model => model.NewComment, new { rows = 4 })%>
        //<td><%: Html.TextBoxFor(model => model.DeliveryDate)%></td>
        //<td><%: Html.DropDownListFor(model => model.Cluster.ID, (IEnumerable<SelectListItem>)ViewData["Clusters"], "--seleccione--")%></td>
        //<td><%: Html.TextBoxFor(model => model.System)%></td>
        //<td><%: String.Format("{0:F1}", Model.EstimatedHours)%></td>
        //<td><%: String.Format("{0:P0}", Model.DonePercentage / 100)%></td>
        //<td><%: Html.TextBoxFor(model => model.RealDeliveryDate)%></td>
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