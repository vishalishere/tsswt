using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADExcelRow : ADBase
    {
        #region CRUD

        #region Get
        public static IEnumerable<ENT.ExcelRow> Get(Entities.User u, ENT.Period period)//Entities.Resource r, ENT.Period period)
        {
            return (from er in Context.ExcelRow
                    where er.T == u.Logon && er.Period.IdpEriod == period.ID
                    select new ENT.ExcelRow
                    {
                        Id = er.IdeXcelRow,
                        Date = er.Date,
                        StartHour = er.StartHour,
                        EndHour = er.EndHour,
                        Ticket = er.Ticket,
                        Description = er.Description,
                        SCPHours = er.ScphOurs,
                        SCPTicket = er.ScptIcket,
                        SCPT = er.SCPt,
                        SCPCharged = er.ScpcHarged, //(er.ScpcHarged == 1)
                        Resource = new Entities.Resource
                        {
                            Cluster = er.Resource1.Cluster.IdcLuster.ToString(),
                            Name = er.Resource1.Name,
                            T = er.Resource1.T
                        }
                    });
        }

        public static IEnumerable<ENT.ExcelRow> Get(ENT.Resource resource, ENT.Period period)
        {
            return (from er in Context.ExcelRow
                    where er.SCPt == resource.T && er.Period.IdpEriod == period.ID
                    select new ENT.ExcelRow
                    {
                        Id = er.IdeXcelRow,
                        Date = er.Date,
                        StartHour = er.StartHour,
                        EndHour = er.EndHour,
                        Ticket = er.Ticket,
                        Description = er.Description,
                        SCPHours = er.ScphOurs,
                        SCPTicket = er.ScptIcket,
                        SCPT = er.SCPt,
                        SCPCharged = er.ScpcHarged, //(er.ScpcHarged == 1)
                        Resource = new Entities.Resource
                        {
                            Cluster = er.Resource1.Cluster.IdcLuster.ToString(),
                            Name = er.Resource1.Name,
                            T = er.Resource1.T
                        }
                    });
        }

        public static IEnumerable<ENT.ExcelRow> Get(ENT.Resource resource, DateTime date)
        {
            return (from er in Context.ExcelRow
                    where er.T == resource.T && er.Date == date
                    select new ENT.ExcelRow
                    {
                        Id = er.IdeXcelRow,
                        Date = er.Date,
                        StartHour = er.StartHour,
                        EndHour = er.EndHour,
                        Ticket = er.Ticket,
                        Description = er.Description,
                        SCPHours = er.ScphOurs,
                        SCPTicket = er.ScptIcket,
                        SCPT = er.SCPt,
                        SCPCharged = er.ScpcHarged, //(er.ScpcHarged == 1)
                        Resource = new Entities.Resource
                        {
                            Cluster = er.Resource1.Cluster.IdcLuster.ToString(),
                            Name = er.Resource1.Name,
                            T = er.Resource1.T
                        }
                    });
        } 
        #endregion

        public static int Insert(ENT.ExcelRow excelRow)
        {
            int result = 1;

            try
            {
                using (SwT swt = Context)
                {
                    swt.ExcelRow.InsertOnSubmit(new Data.ExcelRow
                    {
                        //IdeXcelRow = maxId + 1, //excelRow.Id,
                        Date = excelRow.Date,
                        StartHour = excelRow.StartHour,
                        EndHour = excelRow.EndHour,
                        Ticket = excelRow.Ticket,
                        Description = excelRow.Description,
                        ScphOurs = excelRow.SCPHours,
                        ScptIcket = excelRow.Ticket,
                        SCPt = excelRow.SCPT,
                        ScpcHarged = excelRow.SCPCharged,
                        T = excelRow.Resource.T,
                        Period = new Data.Period { IdpEriod = 1 }
                    }
                    );

                    swt.SubmitChanges();
                }
            }
            catch (Exception Ex)
            {
                result = 0;
            }

            return result;
        }

        public static int Update(ENT.ExcelRow excelRow)
        {
            int result = 1;
            try
            {
                Data.ExcelRow eR = (HP.SW.SWT.Data.ExcelRow)from er in Context.ExcelRow
                                                            where er.IdeXcelRow == excelRow.Id
                                                                 && er.Date == excelRow.Date
                                                                 && er.Ticket == excelRow.Ticket
                                                            select er;

                //eR.IdeXcelRow = excelRow.Id;
                //eR.Date = excelRow.Date;
                eR.StartHour = excelRow.StartHour;
                eR.EndHour = excelRow.EndHour;
                eR.Ticket = excelRow.Ticket;
                eR.Description = excelRow.Description;
                eR.ScphOurs = excelRow.SCPHours;
                eR.ScptIcket = excelRow.Ticket;
                eR.SCPt = excelRow.SCPT;
                eR.ScpcHarged = excelRow.SCPCharged;

                Context.SubmitChanges();
            }
            catch (Exception Ex)
            {
                result = 0;
            }

            return result;
        }

        public static int Delete(ENT.ExcelRow excelRow)
        {
            int result = 1;

            try
            {
                Context.ExcelRow.DeleteOnSubmit(new Data.ExcelRow
                {
                    IdeXcelRow = excelRow.Id,
                    Date = excelRow.Date,
                    StartHour = excelRow.StartHour,
                    EndHour = excelRow.EndHour,
                    Ticket = excelRow.Ticket,
                    Description = excelRow.Description,
                    ScphOurs = excelRow.SCPHours,
                    ScptIcket = excelRow.Ticket,
                    SCPt = excelRow.SCPT,
                    ScpcHarged = excelRow.SCPCharged
                }
                );

                Context.SubmitChanges();
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        #endregion

        public static IEnumerable<ENT.ExcelRow> GetCurrentAssignments()
        {
            var currAss = (from er in Context.ExcelRow
                           orderby er.StartHour
                           group er by er.T into g
                           select g).ToList();

            return (from er in currAss.ConvertAll<ExcelRow>(x => x.First())
                    select new ENT.ExcelRow
                    {
                        Id = er.IdeXcelRow,
                        Date = er.Date,
                        StartHour = er.StartHour,
                        EndHour = er.EndHour,
                        Ticket = er.Ticket,
                        Description = er.Description,
                        SCPHours = er.ScphOurs,
                        SCPTicket = er.ScptIcket,
                        SCPT = er.SCPt,
                        SCPCharged = er.ScpcHarged, //(er.ScpcHarged == 1)
                        Resource = ADResource.Get(er.T)
                    });
        }

        public static IEnumerable<ENT.ResourceRealDay> GetMonthlyHoursReal(ENT.Resource resource, ENT.Period period)
        {
            ENT.ResourceAssignment resourceAssignment = Data.ADResourceAssignment.Get(resource, period);

            IEnumerable<ExcelRow> dbMonthlyHoursReal = (from er in Context.ExcelRow
                                                        where er.IdpEriod == period.ID && er.SCPt == resource.T
                                                        select er).ToList();

            IEnumerable<ENT.ResourceAssignmentDay> monthlyHoursReal = dbMonthlyHoursReal.GroupBy(er => er.Date).OrderBy(g=> g.Key).ToList().ConvertAll<ENT.ResourceAssignmentDay>
                                                                       (g => new ENT.ResourceAssignmentDay
                                                                       {
                                                                           Date = g.Key,
                                                                           Hours = g.Sum(d => d.ScphOurs ?? 0)
                                                                       });

            if (resourceAssignment == null && monthlyHoursReal.Count() == 0)
            {
                return null;
            }

            List<ENT.ResourceRealDay> res = new List<ENT.ResourceRealDay>();
            ENT.ResourceAssignmentDay rad;
            for (DateTime d = period.StartDate.Date; d <= period.EndDate.Value.Date; d = d.AddDays(1))
            {
                if (d < DateTime.Now.Date)
                {
                    rad = monthlyHoursReal.Where(r => r.Date == d).FirstOrDefault();

                    if (rad == null)
                    {
                        rad = resourceAssignment.Days.Where(r => r.Date == d).First();
                        res.Add(new ENT.ResourceRealDay { Date = d, IsReal = false, HoursInDay = rad.Hours });
                    }
                    else
                    {
                        res.Add(new ENT.ResourceRealDay { Date = d, IsReal = true, HoursInDay = rad.Hours });
                    }
                }
                else
                {
                    rad = resourceAssignment.Days.Where(r => r.Date == d).First();
                    res.Add(new ENT.ResourceRealDay { Date = d, IsReal = false, HoursInDay = rad.Hours });
                }
            }
            return res;
        }
    }
}