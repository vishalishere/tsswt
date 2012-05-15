using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Web.Mvc;

using HP.SW.SWT.Extensions;

namespace HP.SW.SWT.Entities
{
    public static class DateHelper
    {
        public static DateTime CurrentWorkingDate
        {
            get
            {
                return NextWorkingSlot(DateTime.Now);
            }
        }

        public static DateTime NextWorkingDay(DateTime dateTime)
        {
            return AddWorkingDays(dateTime, 1);
        }

        public static DateTime NextWorkingSlot(DateTime dateTime)
        {
            DateTime res;
            if (!IsWorkingDay(dateTime))
            {
                res = BeginWorkingDay(NextWorkingDay(dateTime));
            }
            else
            {
                res = dateTime.AddMinutes(dateTime.Minute > 30 ? 60 - dateTime.Minute : 30 - dateTime.Minute);
            }

            if (res.Hour == 13)
            {
                res = HalfWorkingDay(dateTime);
            }
            else if (res.Hour == 18)
            {
                res = BeginWorkingDay(res.AddDays(1));
            }
            return res;
        }

        public static DateTime BeginWorkingDay(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 9, 0, 0);
        }

        public static DateTime HalfWorkingDay(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 14, 0, 0);
        }

        public static DateTime EndWorkingDay(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 18, 0, 0);
        }

        public static XDocument holidays = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Holiday.xml"));
        private static bool IsWorkingDay(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            else
            {
                return !(from day in holidays.Descendants("holiday")
                         where day.Attribute("date").Value == date.ToString("yyyyMMdd")
                         select day).Any();
            }
        }

        public static DateTime AddWorkingDays(DateTime initialDate, int days)
        {
            DateTime res = initialDate;
            int i = 0;
            while (i < days)
            {
                res = res.AddDays(1);

                if (DateHelper.IsWorkingDay(res))
                {
                    i++;
                }
            }

            return res;
        }

        public static DateTime AddWorkingHours(DateTime initialDate, decimal hours)
        {
            DateTime res = NextWorkingSlot(initialDate);
            if (hours > 0)
            {
                decimal pendingAddHours = hours;
                if (res.Minute == 30)
                {
                    res = res.AddMinutes(30);
                    pendingAddHours = hours - (decimal)0.5;
                }

                decimal firstDayHours = (DateHelper.EndWorkingDay(res) - res).Hours;
                if (firstDayHours < 4)
                {
                    firstDayHours++;
                }
                else if (firstDayHours == 9)
                {
                    firstDayHours--;
                }

                if (firstDayHours > pendingAddHours)
                {
                    res = res.AddHours((double)pendingAddHours);
                    pendingAddHours = 0;
                }
                else
                {
                    res = BeginWorkingDay(res.AddDays(1));
                    pendingAddHours -= firstDayHours;
                }

                int pendingAddDays = (int)Math.Truncate(pendingAddHours / 8);
                if (pendingAddDays == pendingAddHours / 8)
                {
                    // Si la cantidad de horas a agregar es múltiplo de 8,
                    // hay que moverse solo n-1 días y dejar las 8 horas extra
                    // para agregarse a ese día.
                    pendingAddDays--;
                }
                res = DateHelper.AddWorkingDays(res, pendingAddDays);
                pendingAddHours -= pendingAddDays * 8;

                if (pendingAddHours > 0)
                {
                    if (pendingAddHours != (int)pendingAddHours)
                    {
                        // implica que hay media hora para sumar.
                        res = res.AddMinutes(30);
                        pendingAddHours -= (decimal)0.5;
                    }

                    if (pendingAddHours > 4)
                    {
                        pendingAddHours++;
                    }
                    res = res.AddHours((double)pendingAddHours);
                }
            }

            return res;
        }
    }
}