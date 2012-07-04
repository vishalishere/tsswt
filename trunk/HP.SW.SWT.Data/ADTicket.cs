﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADTicket : ADBase
    {
        #region Get

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
                                  Resource = t.Resource == null ? null : new ENT.Resource
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
                                  UserCreated = ADUser.Get(t.IDUserCreate),
                                  DateLastModified = t.DateLastModified,
                                  UserLastModified = ADUser.Get(t.IDUserLastModified),
                                  DateDeleted = t.DateDelete,
                                  UserDeleted = t.IDUserDelete.HasValue ? ADUser.Get(t.IDUserDelete.Value) : null,
                                  Tasks = (from ta in t.Task
                                           select new ENT.Task
                                           {
                                               ID = ta.IdtAsk,
                                               TicketNumber = ta.TicketNumber,
                                               Number = ta.TaskNumber,
                                               Phase = (ENT.TaskPhase)ta.Phase,
                                               Description = ta.Description,
                                               EstimatedHours = ta.EstimatedHours,
                                               DonePercentage = ta.DonePercentage
                                           }),
                                  Comments = (from tc in t.TicketComment
                                              select new ENT.TicketComment
                                              {
                                                  Comment = tc.Comment,
                                                  User = ADUser.Get(tc.IDUser),
                                                  Date = tc.Date,
                                              }),
                                 IsRework = t.IsRework,
                                 IsCertifiable = t.IsCertifiable
                                   
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
                                 Resource = t.Resource == null ? null : new ENT.Resource
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
                                 UserCreated = ADUser.Get(t.IDUserCreate),
                                 DateLastModified = t.DateLastModified,
                                 UserLastModified = ADUser.Get(t.IDUserLastModified),
                                 DateDeleted = t.DateDelete,
                                 UserDeleted = t.IDUserDelete.HasValue ? ADUser.Get(t.IDUserDelete.Value) : null,
                                 Tasks = (from ta in t.Task
                                          select new ENT.Task
                                          {
                                              ID = ta.IdtAsk,
                                              TicketNumber = ta.TicketNumber,
                                              Number = ta.TaskNumber,
                                              Phase = (ENT.TaskPhase)ta.Phase,
                                              Description = ta.Description,
                                              EstimatedHours = ta.EstimatedHours,
                                              DonePercentage = ta.DonePercentage
                                          }),
                                 Comments = (from tc in t.TicketComment
                                             select new ENT.TicketComment
                                             {
                                                 Comment = tc.Comment,
                                                 User = ADUser.Get(tc.IDUser),
                                                 Date = tc.Date,
                                             }),
                                IsRework = t.IsRework,
                                IsCertifiable = t.IsCertifiable
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
                                  Resource = ticket.Resource == null ? null : new ENT.Resource
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
                                  UserCreated = ADUser.Get(ticket.IDUserCreate),
                                  DateLastModified = ticket.DateLastModified,
                                  UserLastModified = ADUser.Get(ticket.IDUserLastModified),
                                  DateDeleted = ticket.DateDelete,
                                  UserDeleted = ticket.IDUserDelete.HasValue ? ADUser.Get(ticket.IDUserDelete.Value) : null,
                                  Tasks = (from ta in ticket.Task
                                           select new ENT.Task
                                           {
                                               ID = ta.IdtAsk,
                                               TicketNumber = ta.TicketNumber,
                                               Number = ta.TaskNumber,
                                               Phase = (ENT.TaskPhase)ta.Phase,
                                               Description = ta.Description,
                                               EstimatedHours = ta.EstimatedHours,
                                               DonePercentage = ta.DonePercentage
                                           }),
                                  Comments = (from tc in ticket.TicketComment
                                              select new ENT.TicketComment
                                              {
                                                  Comment = tc.Comment,
                                                  User = ADUser.Get(tc.IDUser),
                                                  Date = tc.Date,
                                              }),
                                  IsRework = ticket.IsRework,
                                  IsCertifiable = ticket.IsCertifiable
                              };
            }
            return res;
        }
        
        #endregion

        public static void Insert(ENT.Ticket ticket, ENT.User currentUser)
        {
            using (SwT context = Context)
            {
                Ticket dbTicket = new Ticket
                {
                    AssignedTo = ticket.Resource.T,
                    Category = (int)ticket.Category,
                    ConsumedHours = 0,
                    DateCreate = DateTime.Now,
                    DateLastModified = DateTime.Now,
                    DeliveryDate = ticket.DeliveryDate,
                    Description = ticket.Description,
                    IdcLuster = ticket.Cluster.ID,
                    IDUserCreate = currentUser.ID,
                    IDUserLastModified = currentUser.ID,
                    Number = ticket.Number,
                    Priority = (int)ticket.Priority,
                    RealDeliveryDate = ticket.RealDeliveryDate,
                    StartDate = ticket.StartDate,
                    Status = (int)ticket.Status,
                    System = ticket.System,
                    Title = ticket.Title,
                    IsRework = ticket.IsRework,
                    IsCertifiable = ticket.IsCertifiable
                };

                if (!string.IsNullOrEmpty(ticket.NewComment))
                {
                    dbTicket.TicketComment.Add(new TicketComment
                    {
                        Date = DateTime.Now,
                        IDUser = currentUser.ID,
                        Comment = ticket.NewComment
                    });
                }

                context.Ticket.InsertOnSubmit(dbTicket);
                context.SubmitChanges();
            }
        }

        public static void Update(ENT.Ticket ticket, ENT.User currentUser)
        {
            using (SwT context = Context)
            {
                Ticket dbTicket = (from t in context.Ticket
                                   where t.Number == ticket.Number
                                   select t).FirstOrDefault();

                if (dbTicket == null)
                {
                    throw new Exception("El ticket ha sido eliminado. Por favor vuelvalo a crear.");
                }

                dbTicket.Category = (int)ticket.Category;
                dbTicket.ConsumedHours = ticket.ConsumedHours ?? 0;
                dbTicket.DateLastModified = DateTime.Now;
                dbTicket.DeliveryDate = ticket.DeliveryDate;
                dbTicket.Description = ticket.Description;
                dbTicket.IdcLuster = ticket.Cluster.ID;
                dbTicket.IDUserLastModified = currentUser.ID;
                dbTicket.Priority = (int)ticket.Priority;
                dbTicket.RealDeliveryDate = ticket.RealDeliveryDate;
                dbTicket.AssignedTo = ticket.Resource.T;
                dbTicket.StartDate = ticket.StartDate;
                dbTicket.Status = (int)ticket.Status;
                dbTicket.System = ticket.System;
                dbTicket.Title = ticket.Title;
                dbTicket.IsRework = ticket.IsRework;
                dbTicket.IsCertifiable = ticket.IsCertifiable;

                if (!string.IsNullOrEmpty(ticket.NewComment))
                {
                    dbTicket.TicketComment.Add(new TicketComment
                    {
                        Date = DateTime.Now,
                        IDUser = currentUser.ID,
                        Comment = ticket.NewComment
                    });
                }

                context.SubmitChanges();
            }
        }

        public static void Delete(string ticketNumber, ENT.User user)
        {
            using (SwT swt = Context)
            {
                Ticket ticket = (from t in swt.Ticket
                                 where t.Number == ticketNumber
                                 select t).FirstOrDefault();

                if (ticket == null)
                {
                    throw new Exception("El ticket ya fue eliminado.");
                }

                if (ticket != null)
                {
                    ticket.IDUserDelete = user.ID;
                    ticket.DateDelete = DateTime.Now;
                }

                swt.SubmitChanges();
            }
        }
    }
}