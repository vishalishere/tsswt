using System.Collections.Generic;
using System.Linq;

using ENT = HP.SW.SWT.Entities;
using System;

namespace HP.SW.SWT.Data
{
    public class ADResource : ADBase
    {
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
            return GetAll().Where(r => r.T.ToUpper() == T.ToUpper()).FirstOrDefault();
        }
    }
}