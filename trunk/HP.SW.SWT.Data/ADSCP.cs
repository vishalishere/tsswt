using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Excel;
using ENT = HP.SW.SWT.Entities;

namespace HP.SW.SWT.Data
{
    public class ADSCP : ADBase
    {
        public static void Import(ENT.Period period, Stream stream)
        {
            string[] rowCells;

            DateTime date;

            string resourceFirstName = string.Empty;
            string resourceLastName = string.Empty;
            string resourceT = string.Empty;
            string resourceFullName = string.Empty;
            List<string> missingResources = new List<string>();

            string ticketNumber = string.Empty;
            List<string> missingTickets = new List<string>();

            string scpProjectID = string.Empty;
            string scpProjectDescription = string.Empty;
            string scpProjectType = string.Empty;

            bool insert = true;
            using (SwT swt = Context)
            {
                swt.SCP.DeleteAllOnSubmit(from scp in swt.SCP where scp.IdpEriod == period.ID select scp);
                using (IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream))
                {
                    foreach (DataRow row in excelReader.AsDataSet().Tables[0].Rows)
                    {
                        insert = true;
                        if (row.IsNull(0) || row[0].ToString().ToUpperInvariant().IndexOf("APELLIDO") >= 0)
                        {
                            insert = false;
                        }
                        rowCells = row[0].ToString().Split('|');

                        if (rowCells[5].ToUpperInvariant().IndexOf("TOTAL") >= 0)
                        {
                            insert = false;
                        }

                        resourceLastName = rowCells[0];
                        resourceFirstName = rowCells[1];
                        resourceT = rowCells[2];

                        if (swt.Resource.Where(r => r.T == resourceT).Count() == 0)
                        {
                            resourceFullName = resourceLastName + "," + resourceFirstName + " (" + resourceT + ")";
                            if (!missingResources.Contains(resourceFullName))
                            {
                                missingResources.Add(resourceFullName);
                            }
                            insert = false;
                        }

                        ticketNumber = rowCells[10];
                        if (swt.Ticket.Where(t => t.Number == ticketNumber).Count() == 0)
                        {
                            if (!missingTickets.Contains(ticketNumber))
                            {
                                missingTickets.Add(ticketNumber);
                            }
                            insert = false;
                        }

                        scpProjectID = rowCells[7];
                        scpProjectDescription = rowCells[6];
                        if (swt.SCPProject.Where(sp => sp.IDScppRoject == scpProjectID).Count() == 0)
                        {
                            swt.SCPProject.InsertOnSubmit(new SCPProject
                            {
                                IDScppRoject = scpProjectID, 
                                Description = scpProjectDescription
                            });
                        }

                        if (insert)
                        {
                            date = new DateTime(1900, 1, 1).AddDays(Int64.Parse(row[12].ToString()) - 2);
                            swt.SCP.InsertOnSubmit(new SCP
                            {
                                IdpEriod = period.ID,
                                T = resourceT,
                                IDScppRoject = scpProjectID,
                                Number = ticketNumber,
                                Date = date,
                                Hours = decimal.Parse(rowCells[13])
                            });
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