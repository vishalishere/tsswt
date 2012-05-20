using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using ENT = HP.SW.SWT.Entities;

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

        public static IEnumerable<ENT.ExcelRow> GetExcel(string T, ENT.Period period)
        {
            return (from er in Context.ExcelRow
                    where er.T == T && er.Period.IdpEriod == period.ID
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
                        SCPCharged = er.ScpcHarged //(er.ScpcHarged == 1)
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

                //try
                //{
                //    MySql.Data.MySqlClient.MySqlParameter[] pars = new MySql.Data.MySqlClient.MySqlParameter[10];
                //    pars[0] = new MySql.Data.MySqlClient.MySqlParameter(paramIdExcelRow, MySql.Data.MySqlClient.MySqlDbType.Int32, 32, System.Data.ParameterDirection.Input, false, 2, 1, "IDExcelRow", System.Data.DataRowVersion.Current, excelRow.Id);
                //    pars[1] = new MySql.Data.MySqlClient.MySqlParameter(paramDate, MySql.Data.MySqlClient.MySqlDbType.DateTime, 10, System.Data.ParameterDirection.Input, false, 2, 1, "Date", System.Data.DataRowVersion.Current, excelRow.Date);
                //    pars[2] = new MySql.Data.MySqlClient.MySqlParameter(paramStartHour, MySql.Data.MySqlClient.MySqlDbType.DateTime, 10, System.Data.ParameterDirection.Input, false, 2, 1, "StartHour", System.Data.DataRowVersion.Current, excelRow.StartHour);
                //    pars[3] = new MySql.Data.MySqlClient.MySqlParameter(paramEndHour, MySql.Data.MySqlClient.MySqlDbType.DateTime, 10, System.Data.ParameterDirection.Input, false, 2, 1, "EndHour", System.Data.DataRowVersion.Current, excelRow.EndHour);
                //    pars[4] = new MySql.Data.MySqlClient.MySqlParameter(paramTicket, MySql.Data.MySqlClient.MySqlDbType.String, 15, System.Data.ParameterDirection.Input, false, 2, 1, "Ticket", System.Data.DataRowVersion.Current, excelRow.Ticket);
                //    pars[5] = new MySql.Data.MySqlClient.MySqlParameter(paramDescription, MySql.Data.MySqlClient.MySqlDbType.String, 4000, System.Data.ParameterDirection.Input, false, 0, 0, "Description", System.Data.DataRowVersion.Current, excelRow.Description);
                //    pars[6] = new MySql.Data.MySqlClient.MySqlParameter(paramSCPHours, MySql.Data.MySqlClient.MySqlDbType.Decimal);
                //    pars[7] = new MySql.Data.MySqlClient.MySqlParameter(paramSCPTicket, MySql.Data.MySqlClient.MySqlDbType.String);
                //    pars[8] = new MySql.Data.MySqlClient.MySqlParameter(paramSCPT, MySql.Data.MySqlClient.MySqlDbType.String);
                //    pars[9] = new MySql.Data.MySqlClient.MySqlParameter(paramSCPCharged, MySql.Data.MySqlClient.MySqlDbType.Int32);

                //    Context.ExecuteQuery<Data.ExcelRow>(UpdateExcelRow_SP, pars);

                //}
                //catch
                //{
                //    result = 0;
                //    throw;
                //}
            }
            catch
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
                //int maxId = Context.ExcelRow.Max(x => x.IdeXcelRow);   //VER
                //Add
                //Context.ExcelRow.Attach(new Data.ExcelRow {
                //                                            //IdeXcelRow = maxId + 1, //excelRow.Id,
                //                                            Date = excelRow.Date,
                //                                            StartHour = excelRow.StartHour,
                //                                            EndHour = excelRow.EndHour,
                //                                            Ticket = excelRow.Ticket,
                //                                            Description = excelRow.Description,
                //                                            ScphOurs = excelRow.SCPHours,
                //                                            ScptIcket = excelRow.Ticket,
                //                                            SCPt = excelRow.SCPT,
                //                                            ScpcHarged = excelRow.SCPCharged 
                //                                          }
                //);

                Context.ExcelRow.InsertOnSubmit(new Data.ExcelRow
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