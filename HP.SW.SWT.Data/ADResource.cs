using System.Collections.Generic;
using System.Linq;

using ENT = HP.SW.SWT.Entities;
using System;

namespace HP.SW.SWT.Data
{
    public class ADResource : ADBase
    {
        #region SP constants
        private const string UpdateExcelRow_SP = "`swt`.`update_excelrow_sp`";
        #endregion

        #region parameter constants
        private const string paramIdExcelRow = "p_id";
        private const string paramDate = "p_date";
        private const string paramStartHour = "p_starthour";
        private const string paramEndHour = "p_endhour";
        private const string paramTicket = "p_ticket";
        private const string paramDescription = "p_description";
        private const string paramSCPHours = "p_scphours";
        private const string paramSCPTicket = "p_scpticket";
        private const string paramSCPT = "p_scpt";
        private const string paramSCPCharged = "p_scpcharged";
        #endregion

        public static IEnumerable<ENT.Resource> GetAll()
        {
            return (from r in Context.Resource
                    select new ENT.Resource
                    {
                        T = r.T,
                        Cluster = r.Cluster.ShortDescription,
                        Name = r.Name
                    });
        }

        public static ENT.Resource Get(string T)
        {
            return (from r in Context.Resource
                    where r.T == T
                    select new ENT.Resource
                    {
                        T = r.T,
                        Cluster = r.Cluster.ShortDescription,
                        Name = r.Name
                    }).FirstOrDefault();
        }

        public static IEnumerable<ENT.ExcelRow> GetExcel(Entities.User u, ENT.Period period)//Entities.Resource r, ENT.Period period)
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
                        Resource = new Entities.Resource { Cluster = er.Resource1.Cluster.IdcLuster.ToString(),       
                                                      Name = er.Resource1.Name,
                                                      T = er.Resource1.T }
                    });
        }

        public static int UpdateExcelRow(ENT.ExcelRow excelRow)
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

        public static int AddExcelRow(ENT.ExcelRow excelRow)
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

        public static int DeleteExcelRow(ENT.ExcelRow excelRow)
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
    }
}