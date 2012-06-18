using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using ENT = HP.SW.SWT.Entities;
using HP.SW.SWT.Extensions;
using Excel;
using System.Data;

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
            using (SwT swt = Context)
            {
                Data.ExcelRow dbExcelRow = new Data.ExcelRow
                {
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
                    IdpEriod = Data.ADPeriod.Get(excelRow.Date).ID
                };
                swt.ExcelRow.InsertOnSubmit(dbExcelRow);

                swt.SubmitChanges();

                return dbExcelRow.IdeXcelRow;
            }
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

            var dbMonthlyHoursReal = (from er in Context.ExcelRow
                                      where er.IdpEriod == period.ID && er.SCPt == resource.T
                                      select er);

            if (resourceAssignment == null && dbMonthlyHoursReal.Count() == 0)
            {
                return null;
            }

            IEnumerable<ENT.ResourceAssignmentDay> monthlyHoursReal = new List<ENT.ResourceAssignmentDay>();
            if (dbMonthlyHoursReal.Count() > 0)
            {
                monthlyHoursReal = dbMonthlyHoursReal.ToList().GroupBy(er => er.Date.Date).OrderBy(g => g.Key).ToList().ConvertAll<ENT.ResourceAssignmentDay>
                                                                                (g => new ENT.ResourceAssignmentDay
                                                                                      {
                                                                                          Date = g.Key.Date,
                                                                                          Hours = g.Sum(h => h.ScphOurs ?? 0)
                                                                                      });
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
                        res.Add(new ENT.ResourceRealDay { Date = d, IsReal = false, HoursInDay = 0 });
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

        public static decimal GetRework(ENT.Period period)
        {
            decimal res = 0;
            foreach (var ticket in (from t in Context.Ticket
                                    where t.IsRework == 1
                                    select t))
            {
                res += (from er in Context.ExcelRow
                        where er.IdpEriod == period.ID && er.ScptIcket == ticket.Number && er.ScphOurs.HasValue
                        select er.ScphOurs).SumOrZero();
            }
            return res;
        }

        public static decimal GetNonCertifiable(ENT.Period period)
        {
            decimal res = 0;
            foreach (var ticket in (from t in Context.Ticket
                                    where t.IsCertifiable == 0
                                    select t))
            {
                res += (from er in Context.ExcelRow
                        where er.IdpEriod == period.ID && er.ScptIcket == ticket.Number && er.ScphOurs.HasValue
                        select er.ScphOurs).SumOrZero();
            }
            return res;
        }

        public static void GetNonScheduledAbsencesAndLeverage(ENT.Period period, out decimal nonScheduledAbsences, out decimal leverage)
        {
            nonScheduledAbsences = 0;
            leverage = 0;

            decimal realHours;
            foreach (ENT.ResourceAssignment resourceAssignment in ADResourceAssignment.Get(period))
            {
                foreach (ENT.ResourceAssignmentDay day in resourceAssignment.Days.Where(d => d.Date < DateTime.Now.Date))
                {
                    realHours = (from er in Context.ExcelRow
                                 where er.SCPt == resourceAssignment.Resource.T && er.Date == day.Date && er.ScphOurs.HasValue
                                 select er.ScphOurs).SumOrZero();

                    if (realHours < day.Hours)
                    {
                        nonScheduledAbsences += day.Hours - realHours;
                    }
                    else if (realHours > day.Hours)
                    {
                        leverage += realHours - day.Hours;
                    }
                }
            }
        }

        public static void Import(ENT.Period period, ENT.Resource resource, Stream stream)
        {
            DateTime date;
            string ticketNumber = string.Empty;
            List<string> missingTickets = new List<string>();
            using (SwT swt = Context)
            {
                swt.ExcelRow.DeleteAllOnSubmit(from er in swt.ExcelRow where er.IdpEriod == period.ID && er.T == resource.T select er);
                using (IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream))
                {
                    foreach (DataRow row in excelReader.AsDataSet().Tables[0].Rows)
                    {
                        if (!row.IsNull(1) && row[1].ToString().ToUpperInvariant().IndexOf("FECHA") < 0)
                        {
                            ticketNumber = row[6].ToString();
                            if (!string.IsNullOrEmpty(ticketNumber) && ticketNumber != "NO_FACT")
                            {
                                if (swt.Ticket.Where(t => t.Number == ticketNumber).Count() == 0)
                                {
                                    if (!missingTickets.Contains(ticketNumber))
                                    {
                                        missingTickets.Add(ticketNumber);
                                    }
                                }
                                else
                                {
                                    date = new DateTime(1900, 1, 1).AddDays(Int64.Parse(row[1].ToString()) - 2);
                                    swt.ExcelRow.InsertOnSubmit(new ExcelRow
                                    {
                                        Date = date,
                                        StartHour = date.AddSeconds(double.Parse(row[2].ToString()) * 60 * 60 * 24),
                                        EndHour = row.IsNull(3) ? (DateTime?)null : date.AddSeconds(double.Parse(row[3].ToString()) * 60 * 60 * 24),
                                        Ticket = row[5].ToString(),
                                        ScptIcket = ticketNumber,
                                        Description = row[7].ToString(),
                                        ScpcHarged = (sbyte)(row.IsNull(9) ? 0 : (row[9].ToString().ToUpperInvariant() == "SI" ? 1 : 0)),
                                        SCPt = row[10].ToString(),
                                        ScphOurs = row.IsNull(11) ? (decimal?)null : decimal.Parse(row[11].ToString()),
                                        IdpEriod = period.ID,
                                        T = resource.T
                                    });
                                }
                            }
                        }
                    }

                    excelReader.Close();
                }
                swt.SubmitChanges();
            }

            if (missingTickets.Count() > 0)
            {
                throw new Exception("Los siguientes registros no se han podido cargar, porque el ticket no existe: "
                    + missingTickets.Aggregate((string agg, string mt) => agg += ", " + mt));
            }
        }
    }
}